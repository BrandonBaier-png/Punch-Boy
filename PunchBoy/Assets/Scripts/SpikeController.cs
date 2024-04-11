using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(playSpikes());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator playSpikes()
    {

        Debug.Log("getComps start");
        SpikeCoordinates spikeCoordinates = gameObject.GetComponent<SpikeCoordinates>();
        
        //the first row of 4 spikes    
        spikeCoordinates.getSpike(0, 0).GetComponent<SpikeBehavior>();
        spikeCoordinates.getSpike(0, 1).GetComponent<SpikeBehavior>();
        spikeCoordinates.getSpike(0, 2).GetComponent<SpikeBehavior>();
        spikeCoordinates.getSpike(0, 3).GetComponent<SpikeBehavior>();

        SpikeBehavior spikeBehavior = gameObject.GetComponent<SpikeBehavior>(); //the coordinates were supposed to go somewhere around here.
        Debug.Log("getComps end");

        yield return new WaitForSeconds(2);
 
        StartCoroutine(spikeBehavior.DeploySpike());
        Debug.Log("deploy called");

        yield return null;
    }
}