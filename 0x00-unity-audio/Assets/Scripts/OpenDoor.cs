using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public Transform _transform;
    private Vector3 _destination;
    public bool opening;
    // Start is called before the first frame update
    void Start()
    {
        opening = false;
        _destination = _transform.position + new Vector3(0, 8, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (opening == true)
        {
            StartCoroutine(Open());
        }
    }

    IEnumerator Open() 
    {
        while (_transform.position != _destination)
        {
            _transform.position = Vector3.MoveTowards(_transform.position, _destination, Time.deltaTime/100);
            yield return null;
        }
        opening = false;
        yield break;
    }
    
}
