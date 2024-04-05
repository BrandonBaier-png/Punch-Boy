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
        print("Punch boy health " + health);
        Debug.Log(health);
    }
    private void OnTriggerEnter(UnityEngine.Collider other)
    {
        health -= 50;
    }
}
