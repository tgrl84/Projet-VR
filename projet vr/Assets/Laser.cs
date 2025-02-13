using UnityEngine;

public class Laser : MonoBehaviour
{
    public Transform startPoint;
    public Transform endPoint;
    public LineRenderer lineRenderer;

    void Start()
    {
        if (lineRenderer == null)
        {
            lineRenderer = gameObject.AddComponent<LineRenderer>();
        }
        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;
        lineRenderer.positionCount = 2;
        lineRenderer.startColor = Color.red;
        lineRenderer.endColor = Color.red;
    }

    void Update()
    {
        Vector3 start = startPoint.position;
        Vector3 end = endPoint.position;

        lineRenderer.SetPosition(0, start);
        lineRenderer.SetPosition(1, end);

        RaycastHit hit;
        if (Physics.Raycast(start, (end - start), out hit))
        {
            if (hit.collider.gameObject.tag != "Player")
            {
                Debug.Log("Laser hit: " + hit.collider.gameObject.name);
            }
        }
    }
}
