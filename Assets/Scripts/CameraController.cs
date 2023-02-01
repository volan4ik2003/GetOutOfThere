using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float panSpeed = 20f;
    [SerializeField] private float panBorderThickness = 10f;
    [SerializeField] private Vector2 panLimit;
    [SerializeField] private Camera cam;
    [SerializeField] private float zoomSpeed = 10f;
    [SerializeField] private float camOrthSizeMax = 67f, camOrthSizeMin = 10f;
    [SerializeField] private float TopCamLimit = 120f, downCamLimit = 5f, leftCamLimit = -120f, rightCamLimit = 120f;
    float horBound;
    float vertBound;
    float leftBound, rightBound, upBound, downBound;

    private void Start()
    {
        cam.orthographicSize = camOrthSizeMin + 0.1f;
        
    }

    void Update()
    {
        vertBound = cam.orthographicSize;
        horBound = cam.orthographicSize / Screen.height * Screen.width;
        leftBound = transform.position.x - horBound;
        rightBound = transform.position.x + horBound;
        upBound = transform.position.y + vertBound;
        downBound = transform.position.y - vertBound;

        Debug.Log(rightBound);

        Vector3 pos = transform.position;

        if (upBound < TopCamLimit)
        {
            if (Input.mousePosition.y >= Screen.height - panBorderThickness)
            {
                pos.y += panSpeed * Time.deltaTime;
            }
        }
        else
        { 
            pos.y -= panSpeed * Time.deltaTime;
        }

        if (downBound > downCamLimit)
        {
            if (Input.mousePosition.y < panBorderThickness)
            {
                pos.y -= panSpeed * Time.deltaTime;
            }
        }
        else 
        { 
            pos.y += panSpeed * Time.deltaTime;
        }

        if (leftBound > leftCamLimit)
        {
            if (Input.mousePosition.x >= Screen.width - panBorderThickness)
            {
                pos.x += panSpeed * Time.deltaTime;
            }
        }
        else {
            pos.x += panSpeed * Time.deltaTime;
        }

        if (rightBound < rightCamLimit)
        {
            if (Input.mousePosition.x < panBorderThickness)
            {
                pos.x -= panSpeed * Time.deltaTime;
            }
        }
        else {
            pos.x -= panSpeed * Time.deltaTime;
        }
        

        pos.y = Mathf.Clamp(pos.y, panLimit.x, panLimit.y);


        if (cam.orthographic)
        {

            if (cam.orthographicSize <= camOrthSizeMax && cam.orthographicSize >= camOrthSizeMin)
            {
                cam.orthographicSize -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
            }
            else if (cam.orthographicSize <= camOrthSizeMin)
            {
                cam.orthographicSize = camOrthSizeMin + 0.1f;
            }
            else if (cam.orthographicSize >= camOrthSizeMax)
            {
                cam.orthographicSize = camOrthSizeMax - 0.1f;
            }

        }

        transform.position = pos;
    }
}
