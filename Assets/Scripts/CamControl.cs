using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamControl : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 1f;
    public Vector3 offset;

    // this code is silly because it requires the camera be given itself in the inspector
    // please someone find a fix :/
    // Also if anyone decompiles this Hi!
    public Camera m_OrthographicCamera;
    public bool ScrollToZoom;
    public float ScrollSensitivity = 1f;

    public float ZoomLimitLow = 3;
    public float ZoomLimitHigh = 20;


    private void Update() {
       
    }

    private void LateUpdate()
    {
        if (target == null)
            return;
        
        // Scroll to zoom

        if (Input.GetAxis("Mouse ScrollWheel") != 0f  ) // forward
        {
            float zoomDelta = Input.GetAxis("Mouse ScrollWheel");
            float newZoom = m_OrthographicCamera.orthographicSize + zoomDelta;
            m_OrthographicCamera.orthographicSize = Mathf.Clamp(newZoom, ZoomLimitLow, ZoomLimitHigh);
        }


        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }



}
