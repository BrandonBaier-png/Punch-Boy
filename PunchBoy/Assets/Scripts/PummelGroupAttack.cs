using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PummelAnimationBehavior : MonoBehaviour
{

    SpikeCoordinates spikeCoordinates;
    private float waitTime = 0.5f;
    List<PummelBehavior> PummelList;

    public IEnumerator attack()
    {
        /*Debug.Log("loop started");*/
        for (int i = 0; i < PummelList.Count; i++)
        {
            /* Debug.Log("deploying spikes-> " + spikeList[i]);*/
            StartCoroutine(spikeList[i].DeployPummel());
        }
        /*Debug.Log("starting coroutine");*/
        yield return new WaitForSeconds(waitTime);
    }

    // Start is called before the first frame update
    public void Awake()
    {
        PummelCoordinates = GameObject.Find("Pummel2dObject").GetComponent<PummelCoordinates>();
        spikeList = new List<PummelBehavior>();
        Debug.Log(spikeCoordinates.ToString());

    }

    public GroupAttack add(int x, int y)
    {
        SpikeBehavior spike1 = PummelCoordinates.getSpike(x, y).GetComponent<SpikeBehavior>();
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
