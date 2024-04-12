using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeControllerv2 : MonoBehaviour
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

    IEnumerator fillSpikeArray()
    {
        SpikeCoordinates spikeCoordinates = gameObject.GetComponent<SpikeCoordinates>();

        //the first row of 4 spikes    
        spikeList.Add(spikeCoordinates.getSpike(0, 0).GetComponent<SpikeBehavior>());
        spikeList.Add(spikeCoordinates.getSpike(0, 1).GetComponent<SpikeBehavior>());
        spikeList.Add(spikeCoordinates.getSpike(0, 2).GetComponent<SpikeBehavior>());
        spikeList.Add(spikeCoordinates.getSpike(0, 3).GetComponent<SpikeBehavior>());

        spikeList[0] = spikeCoordinates.getSpike(0, 0).GetComponent<SpikeBehavior>();
        spikeList[1] = spikeCoordinates.getSpike(0, 1).GetComponent<SpikeBehavior>();
        spikeList[2] = spikeCoordinates.getSpike(0, 2).GetComponent<SpikeBehavior>();
        spikeList[3] = spikeCoordinates.getSpike(0, 3).GetComponent<SpikeBehavior>();
        yield return null;
    }


    IEnumerator playSpikes()
    {
        /* one mthod that gets the appropritate spikes
         * one method that plays the spikes*/
        yield return StartCoroutine(fillSpikeArray());

        if (spikeList.Count > 0)
        {
            spikeList[0].DeploySpike();
            spikeList[1].DeploySpike();
            spikeList[2].DeploySpike();
            spikeList[3].DeploySpike();
        }
        else
        {
            Debug.Log("No go");
        }
        /*
                Debug.Log("getComps start");
                SpikeCoordinates spikeCoordinates = gameObject.GetComponent<SpikeCoordinates>();

                ArrayList spikeArray = new ArrayList();

                Debug.Log("getComps end");

                yield return new WaitForSeconds(2);

                //StartCoroutine(spikeBehavior.DeploySpike());
                Debug.Log("deploy called");*/

        yield return null;
    }



    //the first row of 4 spikes    

    /* SpikeBehavior spikeTest = spikeCoordinates.getSpike(0, 0).GetComponent<SpikeBehavior>();
       SpikeBehavior spikeTest2 = spikeCoordinates.getSpike(0, 1).GetComponent<SpikeBehavior>();
       SpikeBehavior spikeTest3 = spikeCoordinates.getSpike(0, 2).GetComponent<SpikeBehavior>();
       SpikeBehavior spikeTest4 = spikeCoordinates.getSpike(0, 3).GetComponent<SpikeBehavior>();*/

    //SpikeBehavior spikeBehavior = gameObject.GetComponent<SpikeBehavior>(); 

    //spikeTest.DeploySpike();

}
