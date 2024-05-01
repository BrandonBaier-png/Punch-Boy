using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/*
 * Author - Brandon Baier / Ethan Parke
 * 
 * The logic behind 2d pummel, 
 * Designed for 3d by Ethan Parke / Altered for 2d by Brandon Baier
 * 
 */

public class SpikeInheritor : StandardBossAttack
{
    [SerializeField] private Object PummelPrefab;
    [SerializeField] private Object Pummel2d;
    int rounds = 0;
    private float height = 5f;
    public int secondsBetweenAttack = 2;
    private float pummelAnimDelay = 0.8f;

    public AudioSource spikeAudio;

    PummelGroupAttack g1;
    PummelGroupAttack g2;
    PummelGroupAttack g3;
    PummelGroupAttack g4;

    GroupAttack quad1;
    GroupAttack quad2;
    GroupAttack quad3;
    GroupAttack quad4;

    private void Start()
    {
        g1 = gameObject.AddComponent<PummelGroupAttack>();
        g2 = gameObject.AddComponent<PummelGroupAttack>();
        g3 = gameObject.AddComponent<PummelGroupAttack>();
        g4 = gameObject.AddComponent<PummelGroupAttack>();

        quad1 = gameObject.AddComponent<GroupAttack>();
        quad2 = gameObject.AddComponent<GroupAttack>();
        quad3 = gameObject.AddComponent<GroupAttack>();
        quad4 = gameObject.AddComponent<GroupAttack>();

        //this might need to be different, secondsBetweenAttack may be wrong
        quad1.add(0, 0).add(0, 1).add(1, 0).add(1, 1);//.setWaitTime(secondsBetweenAttack);
        quad2.add(2, 0).add(2, 1).add(3, 0).add(3, 1);//.setWaitTime(secondsBetweenAttack);
        quad3.add(0, 2).add(0, 3).add(1, 2).add(1, 3);//.setWaitTime(secondsBetweenAttack);
        quad4.add(2, 2).add(2, 3).add(3, 2).add(3, 3);//.setWaitTime(secondsBetweenAttack);

        g1.add(0);
        g2.add(1);
        g3.add(2);
        g4.add(3);
    }

    public override IEnumerator attackPattern()
    {
        

        StartCoroutine(PummelAttack());
        ResetAttack();
        return base.attackPattern();
        


    }

    IEnumerator PummelAttack()
    {
        /* Stage grid with each containing 4 elements
         * ROTATE CLOCKWISE TO MATCH
         * 
         * Quad 1 | Quad 2
         * ----------------
         * Quad 3 | Quad 4
         */

        

        while (rounds < 4)
        {
            StartCoroutine(pummelLogic(g1, g2, g3, g4, quad1, quad2, quad3, quad4));
            StartCoroutine(AudioController());
            tickRounds();
            yield return null;
        }

    }

    IEnumerator pummelLogic(PummelGroupAttack g1, PummelGroupAttack g2, PummelGroupAttack g3, PummelGroupAttack g4, 
                                GroupAttack quad1, GroupAttack quad2, GroupAttack quad3, GroupAttack quad4)
    {
        print("PUMMEL HAS BEEN CALLED");
        if (GameObject.Find("punchBoy").transform.position.x <= 1 && GameObject.Find("punchBoy").transform.position.x >= 0)
        {
            // QUAD 3
            if (GameObject.Find("punchBoy").transform.position.z <= 1 && GameObject.Find("punchBoy").transform.position.z >= 0)
            {
                StartCoroutine(quad2.PummelAttack());
                StartCoroutine(g3.attack());
                yield return new WaitForSeconds(pummelAnimDelay);
                //StartCoroutine(g3.attack());
            }
            // QUAD 1
            else if (GameObject.Find("punchBoy").transform.position.z <= 3 && GameObject.Find("punchBoy").transform.position.z >= 2)
            {
                StartCoroutine(quad1.PummelAttack());
                yield return new WaitForSeconds(pummelAnimDelay);
                StartCoroutine(g1.attack());
            }
        }
        else if (GameObject.Find("punchBoy").transform.position.x <= 3 && GameObject.Find("punchBoy").transform.position.x >= 2)
        {
            // QUAD 4
            if (GameObject.Find("punchBoy").transform.position.z <= 1 && GameObject.Find("punchBoy").transform.position.z >= 0)
            {
                StartCoroutine(quad4.PummelAttack());
                yield return new WaitForSeconds(pummelAnimDelay);
                StartCoroutine(g4.attack());
            }
            // QUAD 2
            else if (GameObject.Find("punchBoy").transform.position.z <= 3 && GameObject.Find("punchBoy").transform.position.z >= 2)
            {
                StartCoroutine(quad3.PummelAttack());
                yield return new WaitForSeconds(pummelAnimDelay);
                StartCoroutine(g2.attack());
            }
        }
        
    }


    private void tickRounds()
    {
        rounds++;
    }

    public override void ResetAttack()
    {
        rounds = 0;
        print("Rounds reset to 0 :3");
    }

    IEnumerator AudioController()
    {
        yield return new WaitForSeconds(0.7f);

        spikeAudio.Play();
    }
}