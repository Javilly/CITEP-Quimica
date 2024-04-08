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

    private float originalSeparation = 0f;
    private float actualSeparation = 0f;
    private Vector2 firstTouchOriginalPos;
    private Vector2 secondTouchOriginalPos;

    [SerializeField]
    float scalationMultiplier = 0.1f;

    void Update()
    {
        if (Input.touches.Length == 1)
        {
            Touch touch = Input.touches[0];
            Ray camRay = cam.ScreenPointToRay(touch.position);
            RaycastHit raycastHit;
            if (Physics.Raycast(camRay, out raycastHit, 10))
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
            Touch touchOne = Input.touches[0];
            Touch touchTwo = Input.touches[1];

            Ray camRayOne = cam.ScreenPointToRay(touchOne.position);
            RaycastHit raycastHitOne;

            if (Physics.Raycast(camRayOne, out raycastHitOne, 10))
            {
                if (touchOne.phase == TouchPhase.Began)
                {
                    firstTouchOriginalPos = touchOne.position;
                }
                if (touchOne.phase == TouchPhase.Moved)
                {
                    if (originalSeparation > 0)
                    {
                        actualSeparation = Vector2.Distance(touchOne.position, touchTwo.position);
                    }
                }
            }

            Ray camRayTwo = cam.ScreenPointToRay(touchTwo.position);
            RaycastHit raycastHitTwo;
            if (Physics.Raycast(camRayTwo, out raycastHitTwo, 10))
            {
                if (touchTwo.phase == TouchPhase.Began)
                {
                    secondTouchOriginalPos = touchTwo.position;
                }
                if (touchTwo.phase == TouchPhase.Moved)
                {
                    if (originalSeparation > 0)
                    {
                        actualSeparation = Vector2.Distance(touchOne.position, touchTwo.position);
                    }
                }
            }

            originalSeparation = Vector2.Distance(firstTouchOriginalPos, secondTouchOriginalPos);

            if (originalSeparation != actualSeparation)
            {
                float scaleMultiplier = actualSeparation / originalSeparation * scalationMultiplier;

                transform.localScale = new Vector3(
                    transform.localScale.x * scaleMultiplier,
                    transform.localScale.y * scaleMultiplier,
                    transform.localScale.z * scaleMultiplier
                );
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
