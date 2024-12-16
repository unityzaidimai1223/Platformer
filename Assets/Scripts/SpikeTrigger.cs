using UnityEngine;

public class SpikeTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Find the spikes in the scene and trigger their behavior
            SpikesBehavior spikes = FindObjectOfType<SpikesBehavior>();
            if (spikes != null)
            {
                spikes.TriggerSpikes();
            }
        }
    }
}
