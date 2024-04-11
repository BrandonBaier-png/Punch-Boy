using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpikeRowMove : MonoBehaviour
{
    private float waitTime = 1;
    public float speed = 10.0f;
    //private bool isHit = false;
    public GameObject spikeRow;
    private bool activeAttack = false;
    // Start is called before the first frame update
    void Start()
    {
        moveSpikes(gameObject);
    }

    // Update is called once per frame
    void Update()
    {

        if (activeAttack == true)
        {
            moveSpikes(gameObject);
            /*transform.Translate(Vector2.up * Time.deltaTime * speed);*/
            //was -1.51
            //Debug.Log(gameObject.transform.position.y);
            if (gameObject.transform.position.y >= 4 && waitTime <= 0)
            {
                waitTime = 1.0f;
            }
            if (waitTime >= 0)
            {
                waitTime -= Time.deltaTime;
            }
            if (waitTime <= 0)
            {
                moveSpikes(gameObject);

            }
        }


    }
    public void CurrentAttack(bool value)
    {

        activeAttack = value;
    }

    public void EnableAttack()
    {
        print("SUPERSPUNCHCALLEDTHISI ONE!!!");
        activeAttack = true;
    }
    void OnTriggerEnter(UnityEngine.Collider other)
    {
        //isHit = true;   
        print("Spunch actually works kidna");
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
