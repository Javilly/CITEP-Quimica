using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class LineDrawer : MonoBehaviour
{
    [SerializeField]
    private GameObject linePrefab;

    [SerializeField]
    private Connection[] geometryElements;

    [SerializeField]
    private Sprite lineImage;

    [SerializeField]
    private RectTransform item;

    [SerializeField]
    private RectTransform item2;

    void Start()
    {
        // Vector3[] first = new Vector3[4];
        // item.GetComponent<RectTransform>().GetWorldCorners(first);
        // print(first[0]);

        // Vector3[] second = new Vector3[4];
        // item2.GetComponent<RectTransform>().GetWorldCorners(second);
        // print(second[0]);

        // GameObject newLine2 = Instantiate(linePrefab, new Vector3(0, 0, -6), Quaternion.identity);
        // LineRenderer lineRenderer2 = newLine2.GetComponent<LineRenderer>();

        // lineRenderer2.positionCount = 2;

        // Vector3[] positionsArray = new Vector3[2];

        // positionsArray[0] = new Vector3(first[0].x, first[0].y, -1);
        // positionsArray[1] = new Vector3(second[0].x, second[0].y, -1);

        // lineRenderer2.SetPositions(positionsArray);

        for (int i = 0; i < geometryElements.Length; i++)
        {
            GameObject newLine = Instantiate(linePrefab, new Vector3(0, 0, 0), Quaternion.identity);
            newLine.transform.SetParent(transform);
            LineRenderer lineRenderer = newLine.GetComponent<LineRenderer>();

            lineRenderer.positionCount = 2;
            lineRenderer.SetPositions(geometryElements[i].GetPositions());
        }
    }
}

[System.Serializable]
public class Connection
{
    [SerializeField]
    public GameObject pointA;

    [SerializeField]
    public GameObject pointB;

    public Vector3[] GetPositions()
    {
        Vector3[] positionsArray = new Vector3[2];
        Vector3[] first = new Vector3[4];
        pointA.GetComponent<RectTransform>().GetWorldCorners(first);
        positionsArray[0] = new Vector3(first[0].x, first[0].y, -5);

        Vector3[] second = new Vector3[4];
        pointB.GetComponent<RectTransform>().GetWorldCorners(second);
        positionsArray[1] = new Vector3(second[0].x, second[0].y, -5);

        return positionsArray;
    }
}
