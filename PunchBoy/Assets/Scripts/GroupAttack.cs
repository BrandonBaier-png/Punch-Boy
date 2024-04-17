using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class GroupAttack : MonoBehaviour, Interface
{
    SpikeCoordinates spikeCoordinates;

    List<SpikeBehavior> spikeList;

    public IEnumerator attack()
    {
        Debug.Log("loop started");
        for(int  i = 0; i < spikeList.Count - 1; i++)
        {
            Debug.Log("deploying spikes-> " + spikeList[i]);
            StartCoroutine(spikeList[i].DeploySpike());
        }
        Debug.Log("starting coroutine");
        yield return StartCoroutine(spikeList[spikeList.Count - 1].DeploySpike());
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
}
