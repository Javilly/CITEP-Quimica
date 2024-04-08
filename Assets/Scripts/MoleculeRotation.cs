using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoleculeRotation : MonoBehaviour
{
    [SerializeField]
    private float PCRotationSpeed = 10f;

    [SerializeField]
    private float MobileRotationSpeed = 0.3f;

    [SerializeField]
    private Camera cam;

    [SerializeField]
    private float originalSeparation = 0f;

    [SerializeField]
    private Vector3 initialScale;

    private Vector3 min = new Vector3(0.8f, 0.8f, 0.8f);
    private Vector3 max = new Vector3(2.5f, 2.5f, 2.5f);

    void Update()
    {
        if (Input.touches.Length == 1)
        {
            Touch touch = Input.touches[0];
            Ray camRay = cam.ScreenPointToRay(touch.position);
            RaycastHit raycastHit;
            if (Physics.Raycast(camRay, out raycastHit, 100))
            {
                if (touch.phase == TouchPhase.Moved)
                {
                    transform.Rotate(
                        touch.deltaPosition.y * MobileRotationSpeed,
                        -touch.deltaPosition.x * MobileRotationSpeed,
                        0,
                        Space.World
                    );
                }
            }
        }

        if (Input.touches.Length == 2)
        {
            var touchZero = Input.GetTouch(0);
            var touchOne = Input.GetTouch(1);

            if (
                touchZero.phase == TouchPhase.Ended
                || touchZero.phase == TouchPhase.Canceled
                || touchOne.phase == TouchPhase.Ended
                || touchOne.phase == TouchPhase.Canceled
            )
            {
                return;
            }

            if (touchZero.phase == TouchPhase.Began || touchOne.phase == TouchPhase.Began)
            {
                originalSeparation = Vector2.Distance(touchZero.position, touchOne.position);
                initialScale = transform.localScale;
            }
            else
            {
                var currentDistance = Vector2.Distance(touchZero.position, touchOne.position);

                if (Mathf.Approximately(originalSeparation, 0))
                    return;

                var factor = currentDistance / originalSeparation;

                Vector3 newScale = new Vector3();
                newScale.x = Mathf.Clamp(initialScale.x * factor, min.x, max.x);
                newScale.y = Mathf.Clamp(initialScale.y * factor, min.y, max.y);
                newScale.z = Mathf.Clamp(initialScale.z * factor, min.z, max.z);
                transform.localScale = newScale;
            }
        }
    }

    void OnMouseDrag()
    {
        float rotX = Input.GetAxis("Mouse X") * PCRotationSpeed;
        float rotY = Input.GetAxis("Mouse Y") * PCRotationSpeed;

        Vector3 right = Vector3.Cross(
            cam.transform.up,
            transform.position - cam.transform.position
        );
        Vector3 up = Vector3.Cross(transform.position - cam.transform.position, right);
        transform.rotation = Quaternion.AngleAxis(-rotX, up) * transform.rotation;
        transform.rotation = Quaternion.AngleAxis(rotY, right) * transform.rotation;
    }
}
