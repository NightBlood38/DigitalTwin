using UnityEngine;
using System.Collections;

public class SorterPusher : MonoBehaviour
{
    public Scanner targetSensor;
    public float pushDistance = 4f;
    public float pushSpeed = 5.0f;
    
    public float delayBeforePush = 0.6f; 

    private Vector3 startPosition;
    private bool isPushing = false;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        if (targetSensor.isSignalActive && !isPushing)
        {
            StartCoroutine(PushRoutine());
        }
    }

    IEnumerator PushRoutine()
    {
        isPushing = true;

        yield return new WaitForSeconds(delayBeforePush);

        Vector3 endPosition = startPosition + (transform.forward * pushDistance);

        while (Vector3.Distance(transform.position, endPosition) > 0.01f)
        {
            transform.position = Vector3.MoveTowards(transform.position, endPosition, pushSpeed * Time.deltaTime);
            yield return null;
        }

        while (Vector3.Distance(transform.position, startPosition) > 0.01f)
        {
            transform.position = Vector3.MoveTowards(transform.position, startPosition, pushSpeed * Time.deltaTime);
            yield return null;
        }

        transform.position = startPosition;
        isPushing = false;
    }
}