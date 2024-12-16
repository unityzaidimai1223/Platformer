using System.Collections;
using UnityEngine;

public class SpikesBehavior : MonoBehaviour
{
    public float riseHeight = 2f;       // Height the spikes rise
    public float moveSpeed = 2f;       // Speed of movement
    public float stayUpDuration = 3f;  // Time spikes stay up

    private Vector3 initialPosition;   // Starting position of the spikes
    private Vector3 raisedPosition;    // Target position when spikes rise
    private bool isMoving = false;     // Prevents multiple simultaneous triggers

    void Start()
    {
        // Save the initial position and calculate the raised position
        initialPosition = transform.position;
        raisedPosition = initialPosition + Vector3.up * riseHeight;
    }

    public void TriggerSpikes()
    {
        if (!isMoving)
        {
            StartCoroutine(MoveSpikes());
        }
    }

    private IEnumerator MoveSpikes()
    {
        isMoving = true;

        // Move spikes up
        yield return StartCoroutine(MoveToPosition(raisedPosition));

        // Wait for the duration
        yield return new WaitForSeconds(stayUpDuration);

        // Move spikes back down
        yield return StartCoroutine(MoveToPosition(initialPosition));

        isMoving = false;
    }

    private IEnumerator MoveToPosition(Vector3 targetPosition)
    {
        while (Vector3.Distance(transform.position, targetPosition) > 0.01f)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
            yield return null;
        }
    }
}
