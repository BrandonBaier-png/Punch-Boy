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

    /*    if(Input.GetKeyDown(KeyCode.M))
        {
             StartCoroutine(playSpikes());
        }*/
    }

    IEnumerator playSpikes()
    {

        yield return new WaitForSeconds(1);


        SpikeCoordinates spikeCoordinates = GameObject.Find("Spike Row Animation").GetComponent<SpikeCoordinates>();


        //the first row of spikes    

        SpikeBehavior spike1 = spikeCoordinates.getSpike(0, 0).GetComponent<SpikeBehavior>();
        SpikeBehavior spike2 = spikeCoordinates.getSpike(0, 1).GetComponent<SpikeBehavior>();
        SpikeBehavior spike3 = spikeCoordinates.getSpike(0, 2).GetComponent<SpikeBehavior>();
        SpikeBehavior spike4 = spikeCoordinates.getSpike(0, 3).GetComponent<SpikeBehavior>();

        //the second row of spikes
        SpikeBehavior spike5 = spikeCoordinates.getSpike(1, 0).GetComponent<SpikeBehavior>();
        SpikeBehavior spike6 = spikeCoordinates.getSpike(1, 1).GetComponent<SpikeBehavior>();
        SpikeBehavior spike7 = spikeCoordinates.getSpike(1, 2).GetComponent<SpikeBehavior>();
        SpikeBehavior spike8 = spikeCoordinates.getSpike(1, 3).GetComponent<SpikeBehavior>();

        //the third row of spikes    
        SpikeBehavior spike9 = spikeCoordinates.getSpike(2, 0).GetComponent<SpikeBehavior>();
        SpikeBehavior spike10 = spikeCoordinates.getSpike(2, 1).GetComponent<SpikeBehavior>();
        SpikeBehavior spike11 = spikeCoordinates.getSpike(2, 2).GetComponent<SpikeBehavior>();
        SpikeBehavior spike12 = spikeCoordinates.getSpike(2, 3).GetComponent<SpikeBehavior>();

        //the fourth row of spikes
        SpikeBehavior spike13 = spikeCoordinates.getSpike(3, 0).GetComponent<SpikeBehavior>();
        SpikeBehavior spike14 = spikeCoordinates.getSpike(3, 1).GetComponent<SpikeBehavior>();
        SpikeBehavior spike15 = spikeCoordinates.getSpike(3, 2).GetComponent<SpikeBehavior>();
        SpikeBehavior spike16 = spikeCoordinates.getSpike(3, 3).GetComponent<SpikeBehavior>();


        //plays first row
        StartCoroutine(spike1.DeploySpike());
        StartCoroutine(spike2.DeploySpike());
        StartCoroutine(spike3.DeploySpike());
        StartCoroutine(spike4.DeploySpike());

        //waits for 2 seconds
        yield return new WaitForSeconds(2);

        //plays second row
        StartCoroutine(spike5.DeploySpike());
        StartCoroutine(spike6.DeploySpike());
        StartCoroutine(spike7.DeploySpike());
        StartCoroutine(spike8.DeploySpike());

        //waits for 2 seconds
        yield return new WaitForSeconds(2);

        //plays third row
        StartCoroutine(spike9.DeploySpike());
        StartCoroutine(spike10.DeploySpike());
        StartCoroutine(spike11.DeploySpike());
        StartCoroutine(spike12.DeploySpike());

        //waits for 2 seconds
        yield return new WaitForSeconds(2);

        //plays fourth row
        StartCoroutine(spike13.DeploySpike());
        StartCoroutine(spike14.DeploySpike());
        StartCoroutine(spike15.DeploySpike());
        StartCoroutine(spike16.DeploySpike());

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