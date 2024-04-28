using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PummelGroupAttack : MonoBehaviour, Interface
{

    PummelCoordinates PummelCoordinates;
    private float waitTime = 0.5f;
    List<PummelBehavior> PummelList;

    public IEnumerator attack()
    {
        /*Debug.Log("loop started");*/
        for (int i = 0; i < PummelList.Count; i++)
        {
            /* Debug.Log("deploying spikes-> " + spikeList[i]);*/
            StartCoroutine(PummelList[i].DeployPummel());
        }
        /*Debug.Log("starting coroutine");*/
        yield return new WaitForSeconds(waitTime);
    }

    // Start is called before the first frame update
    public void Awake()
    {
        PummelCoordinates = GameObject.Find("Pummel2dObject").GetComponent<PummelCoordinates>();
        PummelList = new List<PummelBehavior>();
        Debug.Log(PummelCoordinates.ToString());

    }

    public PummelGroupAttack add(int x)
    {
        PummelBehavior pummel1 = PummelCoordinates.getPummel(x).GetComponent<PummelBehavior>();
        PummelList.Add(pummel1);

        return this;
    }



    // Update is called once per frame
    void Update()
    {

    }

    public PummelGroupAttack setWaitTime(float newWaitTime)
    {
        this.waitTime = newWaitTime;
        return this;
    }

}
