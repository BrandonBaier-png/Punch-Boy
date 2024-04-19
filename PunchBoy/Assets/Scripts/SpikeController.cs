using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeController : MonoBehaviour
{

    private List<SpikeBehavior> spikeList = new List<SpikeBehavior>();
    public Animator spunchTigerAnim;
    private bool triggerAnim = false;
    private float spikeWaitTime = 0.5f;

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


        /*SpikeCoordinates spikeCoordinates = GameObject.Find("Spike Row Animation").GetComponent<SpikeCoordinates>();*/


        //fills the first row of spikes   
        g1.add(0, 0).add(0, 1).add(0, 2).add(0, 3).setWaitTime(spikeWaitTime); //can add whatever spikes needed

        //fills the second row of spikes
  
        g2.add(1, 0).add(1, 1).add(1, 2).add(1, 3).setWaitTime(spikeWaitTime);

        //fills the third row of spikes    
        g3.add(2, 0).add(2, 1).add(2, 2).add(2, 3).setWaitTime(spikeWaitTime);

        //fills the fourth row of spikes
        g4.add(3, 0).add(3, 1).add(3, 2).add(3, 3).setWaitTime(spikeWaitTime);



        //plays first row
        spunchTigerAnim.SetTrigger("Spunch");
        yield return StartCoroutine(g1.attack());
        spunchTigerAnim.ResetTrigger("Spunch");
        yield return new WaitForSeconds(spikeWaitTime);

        //plays second row
        spunchTigerAnim.SetTrigger("Spunch");
        yield return StartCoroutine(g2.attack());
        spunchTigerAnim.ResetTrigger("Spunch");
        yield return new WaitForSeconds(spikeWaitTime);

        //plays third row
        spunchTigerAnim.SetTrigger("Spunch");
        yield return StartCoroutine(g3.attack());
        spunchTigerAnim.ResetTrigger("Spunch");
        yield return new WaitForSeconds(spikeWaitTime);

        //plays fourth row
        spunchTigerAnim.SetTrigger("Spunch");
        yield return StartCoroutine(g4.attack());
        spunchTigerAnim.ResetTrigger("Spunch");


        yield return null;

    }
}