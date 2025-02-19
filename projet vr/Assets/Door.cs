using System.Collections;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Transform endSlidePos;
    public float slideDuration = 2.0f; // Durée du slide
    private Vector3 initialPosition;
    private bool isOpen = false;
    private Coroutine currentCoroutine;

    void Start()
    {
        initialPosition = transform.position;
    }

    public void Open()
    {
        if (!isOpen)
        {
            if (currentCoroutine != null)
            {
                StopCoroutine(currentCoroutine);
            }
            currentCoroutine = StartCoroutine(SlideDoor(transform.position, endSlidePos.position));
            isOpen = true;
        }
    }

    public void Close()
    {
        if (isOpen)
        {
            if (currentCoroutine != null)
            {
                StopCoroutine(currentCoroutine);
            }
            currentCoroutine = StartCoroutine(SlideDoor(transform.position, initialPosition));
            isOpen = false;
        }
    }

    private IEnumerator SlideDoor(Vector3 startPos, Vector3 endPos)
    {
        float distance = Vector3.Distance(startPos, endPos);
        float remainingDuration = (distance / Vector3.Distance(initialPosition, endSlidePos.position)) * slideDuration;
        float elapsedTime = 0f;

        while (elapsedTime < remainingDuration)
        {
            transform.position = Vector3.Lerp(startPos, endPos, elapsedTime / remainingDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = endPos;
    }
}

