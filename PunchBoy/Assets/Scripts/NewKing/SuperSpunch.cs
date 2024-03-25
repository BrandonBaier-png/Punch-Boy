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

    public float speed = 10.0f;
    //private bool isHit = false;
    public GameObject spikeRow;
    private Vector3 spawnPos = new Vector3(1.5f, 0, 1.5f);
    private float topBound = 10;
    // Start is called before the first frame update
    void Start()
    {
       // moveSpikes(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M)) {
            Invoke("spawnSpikes", 0);
            //Debug.Log("SPIKES SPAWNED");
        }

       

     }

   void OnTriggerEnter(UnityEngine.Collider other)
    {
        //isHit = true;   
        DetectCollisions.Destroy(other);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Destructor destructor = collision.collider.GetComponent<>()
        //EnemyController e = collision.collider.GetComponent<EnemyController>();
    }

        public void spawnSpikes()
    {

        Instantiate(spikeRow, spawnPos, spikeRow.transform.rotation);
        
    }

   /* IEnumerator Wait(float seconds)
    {
        //yield on a new YieldInstruction that waits for n seconds.
        yield return new WaitForSeconds(seconds);
    }*/
}
