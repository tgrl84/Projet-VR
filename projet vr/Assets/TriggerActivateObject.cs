using UnityEngine;

public class TriggerActivateObject : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Door _door;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Key")
        {
            _door.Open();
        }
    }
}
