using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class GroupAttack : MonoBehaviour, Interface
{
    SpikeCoordinates spikeCoordinates;
    private float waitTime = 0.5f;
    List<SpikeBehavior> spikeList;

    public IEnumerator attack()
    {
        /*Debug.Log("loop started");*/
        for(int  i = 0; i < spikeList.Count; i++)
        {
           /* Debug.Log("deploying spikes-> " + spikeList[i]);*/
            StartCoroutine(spikeList[i].DeploySpike());
        }
        /*Debug.Log("starting coroutine");*/
        yield return new WaitForSeconds(waitTime);
    }

    // Start is called before the first frame update
    public void Awake()
    {
        spikeCoordinates = GameObject.Find("Spike Row Animation").GetComponent<SpikeCoordinates>();
        spikeList = new List<SpikeBehavior>();
        Debug.Log(spikeCoordinates.ToString());

    }

    public GroupAttack add(int x, int y)
    {
        SpikeBehavior spike1 = spikeCoordinates.getSpike(x, y).GetComponent<SpikeBehavior>();
        spikeList.Add(spike1);

        return this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GroupAttack setWaitTime(float newWaitTime)
    {
        this.waitTime = newWaitTime;
        return this;
    }

}
