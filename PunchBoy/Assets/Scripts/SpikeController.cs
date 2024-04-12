using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeController : MonoBehaviour
{

    private List<SpikeBehavior> spikeList = new List<SpikeBehavior>();

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

        SpikeCoordinates spikeCoordinates = gameObject.GetComponent<SpikeCoordinates>(); 

        //the first row of 4 spikes    
        SpikeBehavior spikeTest = spikeCoordinates.getSpike(0, 0).GetComponent<SpikeBehavior>();
        SpikeBehavior spikeTest2 = spikeCoordinates.getSpike(0, 1).GetComponent<SpikeBehavior>();
        SpikeBehavior spikeTest3 = spikeCoordinates.getSpike(0, 2).GetComponent<SpikeBehavior>();
        SpikeBehavior spikeTest4 = spikeCoordinates.getSpike(0, 3).GetComponent<SpikeBehavior>();

       // SpikeBehavior spikeBehavior = gameObject.GetComponent<SpikeBehavior>(); 

        spikeTest.DeploySpike();
        spikeTest2.DeploySpike();
        spikeTest3.DeploySpike();
        spikeTest4.DeploySpike();

        yield return null;



        /*
         Debug.Log("getComps start");
         SpikeCoordinates spikeCoordinates = gameObject.GetComponent<SpikeCoordinates>();

         ArrayList spikeArray = new ArrayList();

         Debug.Log("getComps end");

         yield return new WaitForSeconds(2);

         //StartCoroutine(spikeBehavior.DeploySpike());
         Debug.Log("deploy called");*/

    }
}