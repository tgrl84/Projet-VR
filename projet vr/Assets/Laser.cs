using UnityEngine;

public class Laser : MonoBehaviour
{
    public Transform startPoint;
    public Transform endPoint;
    public GameObject laserPrefab; // Prefab du cylindre représentant le laser
    public Door door;

    private GameObject laserInstance;

    void Start()
    {
        if (laserPrefab != null)
        {
            laserInstance = Instantiate(laserPrefab, startPoint.position, Quaternion.identity);
        }
    }

    void Update()
    {
        Vector3 start = startPoint.position;
        Vector3 end = endPoint.position;

        RaycastHit hit;
        if (Physics.Raycast(start, (end - start), out hit))
        {
            if (hit.collider.gameObject.tag != "laser")
            {
                Debug.Log("Laser hit: " + hit.collider.gameObject.name);
                end = hit.point;
                door.Open();
            }
            else
            {
                door.Close();
            }
        }

        if (laserInstance != null)
        {
            UpdateLaser(start, end);
        }
    }

    void UpdateLaser(Vector3 start, Vector3 end)
    {
        laserInstance.transform.position = (start + end) / 2;
        laserInstance.transform.LookAt(end);
        float distance = Vector3.Distance(start, end);
        laserInstance.transform.localScale = new Vector3(0.1f, 0.1f, distance);
    }
}
