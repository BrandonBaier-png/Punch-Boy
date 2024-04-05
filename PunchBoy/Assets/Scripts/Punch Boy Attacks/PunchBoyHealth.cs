using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchBoyHealth : MonoBehaviour
{
    private float health = 100;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
        //print("Punch boy health " + health);
        //Debug.Log(health);
    }



    void OnTriggerEnter(UnityEngine.Collider collision)
    {
        PlayerController player = collision.gameObject.GetComponent<PlayerController>();
        if (collision.tag == "Spike")
        {
            dealtDamage();
            
        }
    }

    public void dealtDamage()
    {
        health -= 25;
        //print("PUNCHBOY HAS DIED :3");
    }
}
