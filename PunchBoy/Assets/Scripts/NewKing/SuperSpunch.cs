using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SuperSpunch : MonoBehaviour
{
    Rigidbody rigidbodyDespawner;
    

    private float waitTime = 0;
    public float speed = 10.0f;
    //private bool isHit = false;
    public GameObject spikeRow;
    // Start is called before the first frame update
    void Start()
    {
        moveSpikes(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        /*transform.Translate(Vector2.up * Time.deltaTime * speed);*/

        if (gameObject.transform.position.y >= -1.51 && waitTime <= 0)
        {
            waitTime = 1.0f;
        }
        if (waitTime >= 0)
        {
           // Debug.Log(waitTime);
            waitTime -= Time.deltaTime;
        }
        if (waitTime <= 0)
        {
            moveSpikes(gameObject);
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

        public void moveSpikes(GameObject spikesToMove)
    {
       
       transform.Translate(Vector2.up * Time.deltaTime * speed);
        
    }

   /* IEnumerator Wait(float seconds)
    {
        //yield on a new YieldInstruction that waits for n seconds.
        yield return new WaitForSeconds(seconds);
    }*/
}
