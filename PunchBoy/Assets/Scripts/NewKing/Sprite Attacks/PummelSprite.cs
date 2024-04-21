using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class SpikeInheritor : StandardBossAttack
{
    [SerializeField] private Object PummelPrefab;
    [SerializeField] private Object Pummel2d;
    float pummelCooldown = 0;
    int rounds = 0;
    private float height = 5f;
    public int secondsBetweenAttack = 2;

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
            PummelAttack();

            yield return new WaitForSeconds(1.5f);
        }


    }

    public void PummelAttack()
    {

        print("PUMMEL HAS BEEN CALLED");
        if (GameObject.Find("punchBoy").transform.position.x <= 1 && GameObject.Find("punchBoy").transform.position.x >= 0)
        {
            if (GameObject.Find("punchBoy").transform.position.z <= 1 && GameObject.Find("punchBoy").transform.position.z >= 0)
            {
                Instantiate(PummelPrefab, new Vector3(.5f, height, .5f), Quaternion.identity);
                Instantiate(Pummel2d, new Vector3(-14.06f, 3.64f, 0f), Quaternion.identity);
            }
            else if (GameObject.Find("punchBoy").transform.position.z <= 3 && GameObject.Find("punchBoy").transform.position.z >= 2)
            {
                Instantiate(PummelPrefab, new Vector3(.5f, height, 2.5f), Quaternion.identity);
                Instantiate(Pummel2d, new Vector3(-12.94f, 3.5f, 0f), Quaternion.identity);
            }
        }
        else if (GameObject.Find("punchBoy").transform.position.x <= 3 && GameObject.Find("punchBoy").transform.position.x >= 2)
        {
            if (GameObject.Find("punchBoy").transform.position.z <= 1 && GameObject.Find("punchBoy").transform.position.z >= 0)
            {
                Instantiate(PummelPrefab, new Vector3(2.5f, height, .5f), Quaternion.identity);
                Instantiate(Pummel2d, new Vector3(-12.94f, 3.7f, 0f), Quaternion.identity);
            }
            else if (GameObject.Find("punchBoy").transform.position.z <= 3 && GameObject.Find("punchBoy").transform.position.z >= 2)
            {
                Instantiate(PummelPrefab, new Vector3(2.5f, height, 2.5f), Quaternion.identity);
                Instantiate(Pummel2d, new Vector3(-11.5f, 3.64f, 0f), Quaternion.identity);
            }
        }

        rounds++;

    }

    public override void ResetAttack()
    {
        rounds = 0;
    }
}