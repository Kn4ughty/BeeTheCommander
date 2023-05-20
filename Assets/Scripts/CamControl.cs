using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamControl : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    
    public Camera m_OrthographicCamera;
    public bool ScrollToZoom;
    public float ScrollSensitivity;

    private void Update() {
       
    }

    private void LateUpdate()
    {
        if (target == null)
            return;
        
        if (Input.GetAxis("Mouse ScrollWheel") != 0f ) // forward
        {
            m_OrthographicCamera.orthographicSize += Input.GetAxis("Mouse ScrollWheel");
        }


        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }



}
