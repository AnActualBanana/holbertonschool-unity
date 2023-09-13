using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class WebXRRayInteraction : MonoBehaviour
{
    public string hand = "Right";
    public float rayDistance = 100f;
    public LayerMask interactableLayers;
    public LineRenderer lineRenderer;

    private InputDevice device;

    private void Start()
    {
        List<InputDevice> devices = new List<InputDevice>();
        InputDevices.GetDevicesWithCharacteristics(hand == "Right" ? InputDeviceCharacteristics.Right : InputDeviceCharacteristics.Left, devices);

        if (devices.Count > 0)
        {
            device = devices[0];
        }
    }

    private void Update()
    {
        if (device.isValid)
        {
            bool isTriggerPressed = false;
            device.TryGetFeatureValue(CommonUsages.triggerButton, out isTriggerPressed);

            if (isTriggerPressed)
            {
                RaycastHit hit;
                Ray ray = new Ray(transform.position, transform.forward);

                if (Physics.Raycast(ray, out hit, rayDistance, interactableLayers))
                {
                    Interactable interactable = hit.collider.GetComponent<Interactable>();
                    if (interactable != null)
                    {
                        interactable.OnInteraction();
                    }
                }

                if (lineRenderer != null)
                {
                    lineRenderer.enabled = true;
                    lineRenderer.SetPosition(0, transform.position);
                    lineRenderer.SetPosition(1, hit.point);
                }
            }
            else
            {
                if (lineRenderer != null)
                {
                    lineRenderer.enabled = false;
                }
            }
        }
    }
}
