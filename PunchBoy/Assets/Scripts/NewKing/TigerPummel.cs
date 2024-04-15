using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TigerPummel : MonoBehaviour
{
    [SerializeField] private Object PummelPrefab;
    [SerializeField] private Object Pummel2d;
    float pummelCooldown = 0;
    bool active = false;
    int rounds = 0;
    private bool activeAttack = false;
    private float height = 5f;
    public int secondsBetweenAttack = 2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*
         * THIS CODE CURRENTLY CAUSES THE GAME TO CRASH
         * Likely due to an invinite loop of some sort.
         * Code has been temporarily replaced in the AttackManager
         * 
         */
        if (activeAttack)
        {
            while (rounds < 4)
            {
                PummelInstance();
            }
           
            rounds = 0;
            CurrentAttack(false);
            
        }
    }

    IEnumerator PummelAttack()
    {
        yield return new WaitForSeconds(secondsBetweenAttack);
    }

    public void PummelInstance()
    {
        if (pummelCooldown <= 0 && GameObject.Find("punchBoy") != null)
        {
            print("PUMMEL HAS BEEN CALLED :3");
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
            pummelCooldown = 1.5f;
            rounds++;
        }
        else
        {
            pummelCooldown -= Time.deltaTime;
        }
    }

    public void CurrentAttack(bool value)
    {
        activeAttack = value;
    }

    public void EnableAttack()
    {
        activeAttack = true;
    }
}

