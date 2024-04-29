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
    float pummelCooldown = 0;
    int rounds = 0;
    private float height = 5f;
    public int secondsBetweenAttack = 2;

    public AudioSource spikeAudio;

    public override IEnumerator attackPattern()
    {
        print("Pummel attackPattern Override has been called");
        StartCoroutine(CallPummelAttack());
        return base.attackPattern();
    }

    IEnumerator CallPummelAttack()
    {
        

        print("Pummel CallPummelAttack has been called");
        while (rounds < 5)
        {
            rounds++;
            StartCoroutine(PummelAttack());
            StartCoroutine(AudioController());

            yield return new WaitForSeconds(1.5f);
        }


    }

    IEnumerator PummelAttack()
    {

        PummelGroupAttack g1 = gameObject.AddComponent<PummelGroupAttack>();
        PummelGroupAttack g2 = gameObject.AddComponent<PummelGroupAttack>();
        PummelGroupAttack g3 = gameObject.AddComponent<PummelGroupAttack>();
        PummelGroupAttack g4 = gameObject.AddComponent<PummelGroupAttack>();
        /* Stage grid with each containing 4 elements
         * ROTATE CLOCKWISE TO MATCH
         * 
         * Quad 1 | Quad 2
         * ----------------
         * Quad 3 | Quad 4
         */

        GroupAttack quad1 = gameObject.AddComponent<GroupAttack>();
        GroupAttack quad2 = gameObject.AddComponent<GroupAttack>();
        GroupAttack quad3 = gameObject.AddComponent<GroupAttack>();
        GroupAttack quad4 = gameObject.AddComponent<GroupAttack>();

        //this might need to be different, secondsBetweenAttack may be wrong
        quad1.add(0, 0).add(0, 1).add(1, 0).add(1, 1).setWaitTime(secondsBetweenAttack);
        quad2.add(2, 0).add(2, 1).add(3, 0).add(3, 1).setWaitTime(secondsBetweenAttack);
        quad3.add(0, 2).add(0, 3).add(1, 2).add(1, 3).setWaitTime(secondsBetweenAttack);
        quad4.add(2, 2).add(2, 3).add(3, 2).add(3, 3).setWaitTime(secondsBetweenAttack);

        g1.add(0);
        g2.add(1);
        g3.add(2);
        g4.add(3);

        print("PUMMEL HAS BEEN CALLED");
        if (GameObject.Find("punchBoy").transform.position.x <= 1 && GameObject.Find("punchBoy").transform.position.x >= 0)
        {
            // QUAD 3
            if (GameObject.Find("punchBoy").transform.position.z <= 1 && GameObject.Find("punchBoy").transform.position.z >= 0)
            {
                StartCoroutine(quad2.attack());
                yield return new WaitForSeconds(1);
                //Instantiate(PummelPrefab, new Vector3(.5f, height, .5f), Quaternion.identity);
                //Instantiate(Pummel2d, new Vector3(-14.06f, 3.64f, 0f), Quaternion.identity);
                StartCoroutine(g3.attack());
            }
            // QUAD 1
            else if (GameObject.Find("punchBoy").transform.position.z <= 3 && GameObject.Find("punchBoy").transform.position.z >= 2)
            {
                StartCoroutine(quad1.attack());
                yield return new WaitForSeconds(1);
                //Instantiate(PummelPrefab, new Vector3(.5f, height, 2.5f), Quaternion.identity);
                //Instantiate(Pummel2d, new Vector3(-12.94f, 3.5f, 0f), Quaternion.identity);
                StartCoroutine(g1.attack());
            }
        }
        else if (GameObject.Find("punchBoy").transform.position.x <= 3 && GameObject.Find("punchBoy").transform.position.x >= 2)
        {
            // QUAD 4
            if (GameObject.Find("punchBoy").transform.position.z <= 1 && GameObject.Find("punchBoy").transform.position.z >= 0)
            {
                StartCoroutine(quad4.attack());
                yield return new WaitForSeconds(1);
                //Instantiate(PummelPrefab, new Vector3(2.5f, height, .5f), Quaternion.identity);
                //Instantiate(Pummel2d, new Vector3(-12.94f, 3.7f, 0f), Quaternion.identity);
                StartCoroutine(g4.attack());
            }
            // QUAD 2
            else if (GameObject.Find("punchBoy").transform.position.z <= 3 && GameObject.Find("punchBoy").transform.position.z >= 2)
            {
                StartCoroutine(quad3.attack());
                yield return new WaitForSeconds(1);
                //Instantiate(PummelPrefab, new Vector3(2.5f, height, 2.5f), Quaternion.identity);
                //Instantiate(Pummel2d, new Vector3(-11.5f, 3.64f, 0f), Quaternion.identity);
                StartCoroutine(g2.attack());
            }
        }

        rounds++;

    }

    public override void ResetAttack()
    {
        rounds = 0;
    }

    IEnumerator AudioController()
    {
        yield return new WaitForSeconds(0.5f);

        spikeAudio.Play();
    }
}