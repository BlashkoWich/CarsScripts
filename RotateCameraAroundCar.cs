using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RotateCameraAroundCar : MonoBehaviour, IDragHandler, IBeginDragHandler
{
    public Transform target;
    public Vector3 offset;
    public float sensitivity = 3; // чувствительность мышки
    public float limit = 80; // ограничение вращения по Y
    public float zoom = 0.25f; // чувствительность при увеличении, колесиком мышки
    public float zoomMax = 10; // макс. увеличение
    public float zoomMin = 6; // мин. увеличение
    public float horizontalLimitMin = -44;
    public float horizontalLimitMax = -228;
    private float X, Y;

    float distanceFinger;

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (Input.touchCount == 2) return;
        X = transform.localEulerAngles.y + eventData.delta.x * sensitivity/300;
        Y += eventData.delta.y * sensitivity;
        Y = Mathf.Clamp(Y, -limit, -5);
        transform.localEulerAngles = new Vector3(-Y, X, 0);
        transform.position = transform.localRotation * offset + target.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (Input.touchCount == 2) return;
        X = transform.localEulerAngles.y + eventData.delta.x * sensitivity / 300;
        Y += eventData.delta.y * sensitivity;
        Y = Mathf.Clamp(Y, -limit, -5);
        transform.localEulerAngles = new Vector3(-Y, X, 0);
        transform.position = transform.localRotation * offset + target.position;
    }

    void Start()
    {
        limit = Mathf.Abs(limit);
        if (limit > 90) limit = 90;
        offset = new Vector3(offset.x, offset.y, -Mathf.Abs(zoomMin));
        Camera.main.transform.LookAt(target);
    }

    void Update()
    {
        if (Input.touchCount == 2) Zoom();
        else if (distanceFinger == 0) distanceFinger = 0;
        if (Input.GetMouseButton(0) || Input.GetAxis("Mouse ScrollWheel") != 0)
        {
            if (Input.GetAxis("Mouse ScrollWheel") > 0) offset.z += zoom;
            else if (Input.GetAxis("Mouse ScrollWheel") < 0) offset.z -= zoom;
            offset.z = Mathf.Clamp(offset.z, -Mathf.Abs(zoomMax), -Mathf.Abs(zoomMin));
            X = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivity;
            if (X > 44 && X < 100) X = 44;
            if (X > 100 && X < 240) X = 240;
            Y += Input.GetAxis("Mouse Y") * sensitivity;
            Y = Mathf.Clamp(Y, -limit, -5);
            transform.localEulerAngles = new Vector3(-Y, X, 0);
            transform.position = transform.localRotation * offset + target.position;
        }
    }

    void Zoom()
    {
        Vector2 finger1 = Input.GetTouch(0).position;
        Vector2 finger2 = Input.GetTouch(1).position;
        if (distanceFinger == 0) distanceFinger = Vector2.Distance(finger1, finger2);
        float delta = Vector2.Distance(finger1, finger2) - distanceFinger;
        if (delta > 0) offset.z += zoom;
        if (delta < 0) offset.z -= zoom;

    }
}