using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Management;
using System.Collections;
public class WebXRButton : MonoBehaviour
{
    private Button _button;
    private bool _inVRMode;

    private void Start()
    {
        //_button = GetComponent<Button>();
        //_button.onClick.AddListener(ToggleVRMode);
        _inVRMode = false;
    }

    public void ToggleVRMode()
    {
        if (_inVRMode)
        {
            StopXR();
        }
        else
        {
            StartCoroutine(StartXR());
        }
    }

    private IEnumerator StartXR()
    {
        yield return XRGeneralSettings.Instance.Manager.InitializeLoader();
        if (XRGeneralSettings.Instance.Manager.activeLoader != null)
        {
            XRGeneralSettings.Instance.Manager.StartSubsystems();
            _inVRMode = true;
        }
    }

    private void StopXR()
    {
        if (XRGeneralSettings.Instance.Manager.activeLoader != null)
        {
            XRGeneralSettings.Instance.Manager.StopSubsystems();
            XRGeneralSettings.Instance.Manager.DeinitializeLoader();
            _inVRMode = false;
        }
    }
}