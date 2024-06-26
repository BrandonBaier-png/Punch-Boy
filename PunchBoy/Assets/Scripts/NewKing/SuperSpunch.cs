using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


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
    

    //time before attack is unleashed
    private float waitTime = 10;
    public Animator animator;
    public float speed = 10.0f;
    //private bool isHit = false;
    public GameObject spikeRow;
    private Vector3 spawnPos = new Vector3(1.5f, -2, 1.5f);
    private float topBound = 10;
    public float BASECOOLDOWN = 3;
    public float attackCooldown = 3;
    private bool readyToAttack = false;
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

        if (Input.GetKeyDown(KeyCode.M))
        {
            activeAttack = true;
        }

        if (activeAttack)
        {
            //print("SUPERSPUNCH ACTIVE");
            SuperSpunchCountdown();
        }
    }

    void SuperSpunchCountdown()
    {
        
        if (attackCooldown <= 0 && bossConcen > 0)
        {
            Invoke("spawnSpikes", 0);
            //attackCooldown = BASECOOLDOWN;
            ResetSuperSpunch();
        }
        else
        {
            attackCooldown -= Time.deltaTime; 
        }
    }

    void ResetSuperSpunch()
    {
        activeAttack = false;
        attackCooldown = BASECOOLDOWN;

    }

    void OnTriggerEnter(UnityEngine.Collider other)
    {
        DetectCollisions.Destroy(other);
    }
    public void spawnSpikes()
    {

        Instantiate(spikeRow, spawnPos, spikeRow.transform.rotation);
    }

    public void CurrentAttack(bool value)
    {
        //print("SUPERSPUNCHCALLED");
        activeAttack = value;
    }
    public void EnableAttack()
    {
        print("SUPERSPUNCHCALLEDTHISI ONE!!!");
        activeAttack = true;    
    }
}
