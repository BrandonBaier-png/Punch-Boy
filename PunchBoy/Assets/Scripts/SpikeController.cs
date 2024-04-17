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


        GroupAttack g1 = gameObject.AddComponent<GroupAttack>();
        GroupAttack g2 = gameObject.AddComponent<GroupAttack>();
        GroupAttack g3 = gameObject.AddComponent<GroupAttack>();
        GroupAttack g4 = gameObject.AddComponent<GroupAttack>();


        SpikeCoordinates spikeCoordinates = GameObject.Find("Spike Row Animation").GetComponent<SpikeCoordinates>();


        //the first row of spikes    
        g1.add(0, 0).add(0, 1).add(0, 2).add(0, 3); //can add whatever spikes needed
 
        //the second row of spikes
        g2.add(1, 0);
        g2.add(1, 1);
        g2.add(1, 2);
        g2.add(1, 3);

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
        yield return StartCoroutine(g1.attack());

        yield return StartCoroutine(g2.attack());
        


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

    }
}