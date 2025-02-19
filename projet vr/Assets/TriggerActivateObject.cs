using UnityEngine;

public class TriggerActivateObject : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Door _door;
    public string _tag = "Key";

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == _tag)
        {
            _door.Open();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == _tag)
        {
            _door.Close();
        }
    }
}
