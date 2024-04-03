using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void BossHit();
public class Boss : MonoBehaviour
{
    public float bossHealth = 500;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("FireFist"))
        {
            bossHealth = bossHealth - 10;
            Debug.Log(bossHealth);
            Destroy(other.gameObject);
        }

        if (other.CompareTag("BasicPunch"))
        {
            bossHealth = bossHealth - 5;
            Debug.Log(bossHealth);
            Destroy(other.gameObject);
        }
    }
}
