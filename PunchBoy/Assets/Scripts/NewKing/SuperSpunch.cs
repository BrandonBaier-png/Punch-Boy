using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;


/*
 * Initial Super Spike Punch controller
 * Takes in game object spike punch row and spawns a copy of the prefab upon pressing M
 * Similar in nature to Prototype 3 from the unity tutorials
 * 
 * Author - Brandon Baier 
 * 
 */
public class SuperSpunch : MonoBehaviour
{
    Rigidbody rigidbodyDespawner;

    private float BASETEMPBOSSHEALTH = 50;
    private float TempBossHealth = 50;

    
    public int BASESPUNCHTIMER = 3;
    public int spunchTimer = 3;

    //time before attack is unleashed
    //private float waitTime = 10;
    public Animator animator;
    //private bool isHit = false;
    public GameObject spikeRow;
    private Vector3 spawnPos = new Vector3(1.5f, 1, 1.5f);
    //private float topBound = 10;
    public float BASECOOLDOWN = 3;
    public float attackCooldown = 3;

    //private bool readyToAttack = false;
    public float BASEBOSSCONCEN = 20;
    public float bossConcen = 20;

    private bool activeAttack = false;
    

    // Start is called before the first frame update
    void Start()
    {
        //attackCalled += EnableAttack();
        // moveSpikes(gameObject);
    }
    // Update is called once per frame
    void Update()
    {


        if (activeAttack)
        {
            //print("SUPERSPUNCH ACTIVE");
            StartCoroutine(superSpunchAttack());
            CurrentAttack(false);
        }
    }

    IEnumerator superSpunchAttack()
    {
        print("Waiting for boss countdown");
        yield return new WaitForSeconds(spunchTimer);
        if (TempBossHealth > 0)
        {
            Invoke("spawnSpikes", 0);
            
        }
        yield return new WaitForSeconds(1);

    }

    public void spawnSpikes()
    {
        Instantiate(spikeRow, spawnPos, spikeRow.transform.rotation);
        ResetAttack();
    }
    void ResetSuperSpunch()
    {
        activeAttack = false;
        attackCooldown = BASECOOLDOWN;
    } 
    
    public void RemoveTempHitpoints(float damageDealt) 
    {
        TempBossHealth -= damageDealt;
    }

    public void CurrentAttack(bool value)
    {
        //print("SUPERSPUNCHCALLED");
        activeAttack = value;
    }

    public void EnableAttack()
    {
        print("Super Spunch Enabled");
        //print("SUPERSPUNCHCALLEDTHISI ONE!!!");
        activeAttack = true;    
    }


    public void ResetAttack()
    {
        TempBossHealth = BASETEMPBOSSHEALTH;
        spunchTimer = BASESPUNCHTIMER;
    }
}
