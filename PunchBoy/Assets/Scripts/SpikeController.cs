using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeController : MonoBehaviour
{

    private List<SpikeBehavior> spikeList = new List<SpikeBehavior>();
    public Animator spunchTigerAnim;
    private bool triggerAnim = false;

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
        spunchTigerAnim.SetTrigger("Spunch");
        g1.add(0, 0).add(0, 1).add(0, 2).add(0, 3).setWaitTime(1); //can add whatever spikes needed

        //fills the second row of spikes
        g2.add(1, 0).add(1, 1).add(1, 2).add(1, 3).setWaitTime(1);

        //fills the third row of spikes    
        g3.add(2, 0).add(2, 1).add(2, 2).add(2, 3).setWaitTime(1);

        //fills the fourth row of spikes
        g4.add(3, 0).add(3, 1).add(3, 2).add(3, 3).setWaitTime(1);



        //plays first row
        yield return StartCoroutine(g1.attack());

        //plays second row
        yield return StartCoroutine(g2.attack());

        //plays third row
        yield return StartCoroutine(g3.attack());

        //plays fourth row
        yield return StartCoroutine(g4.attack());

        yield return null;

    }
}