using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpunchAttack : MonoBehaviour
{

    SpikeCoordinates getSpikePos;

    // Start is called before the first frame update
    void Start()
    {
        // Get the spike at coordinate (0, 0)
        GameObject spike00 = getSpikePos.getSpike(0, 0);

        // Check if the spike object is not null
        if (spike00 != null)
        {
            // Get the SpikeBehavior component from the spike object
            SpikeBehavior spikeBehavior = spike00.GetComponent<SpikeBehavior>();

            // Check if the component is not null (to avoid errors)
            if (spikeBehavior != null)
            {
                // Call the playAnimation method of SpikeBehavior
                spikeBehavior.playAnimation(spike00);
            }
            else
            {
                Debug.LogError("SpikeBehavior component not found on spike object at (0, 0).");
            }
        }
        else
        {
            Debug.LogError("No spike object found at (0, 0).");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}

