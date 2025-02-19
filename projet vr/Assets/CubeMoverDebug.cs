using UnityEngine;

public class CubeMoverDebug : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public float duration = 2.0f; // Durée du parcours entre A et B

    private Vector3 startPosition;
    private Vector3 endPosition;

    void Start()
    {
        startPosition = pointA.position;
        endPosition = pointB.position;
    }

    void Update()
    {
        float time = Mathf.PingPong(Time.time / duration, 1.0f);
        transform.position = Vector3.Lerp(startPosition, endPosition, time);
    }
}
