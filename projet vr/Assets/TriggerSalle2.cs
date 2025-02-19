using UnityEngine;
using System.Collections.Generic;

public class TriggerSqlle2 : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Door _door;
    public List<string> _tag = new List<string> {"Pyramid", "Cube", "Earth"};
    public string _triggerTag;
    private static int _count = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (_tag.Contains(other.tag) && other.tag == _triggerTag)
        {
            _count++;
            if (_count == _tag.Count)
            {
                _door.Open();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (_tag.Contains(other.tag) && other.tag == _triggerTag)
        {
            _count--;
            _door.Close();
        }
    }
}
