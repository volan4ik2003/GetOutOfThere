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

    void Update()
    {
        Vector3 pos = transform.position;

        if (Input.mousePosition.y >= Screen.height - panBorderThickness)
        { 
            pos.y += panSpeed * Time.deltaTime;
        }
        if (Input.mousePosition.y < panBorderThickness)
        {
            pos.y -= panSpeed * Time.deltaTime;
        }
        if (Input.mousePosition.x >= Screen.width - panBorderThickness)
        {
            pos.x += panSpeed * Time.deltaTime;
        }
        if (Input.mousePosition.x < panBorderThickness)
        {
            pos.x -= panSpeed * Time.deltaTime;
        }

        pos.y = Mathf.Clamp(pos.y, -panLimit.y, panLimit.y);

        pos.x = Mathf.Clamp(pos.x, -panLimit.x, panLimit.x);

        cam.orthographicSize -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;

        transform.position = pos;
    }
}
