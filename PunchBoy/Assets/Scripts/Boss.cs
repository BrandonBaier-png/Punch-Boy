using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


//public delegate void HealthChanged(Boss newKing,
//    int oldHealth, int newHealth);

public delegate void BossHit();
public class Boss : MonoBehaviour
{
    private float bossConcenInitial = 20;
    private float bossConcen = 20;
    public float bossHealth = 500;
    public float fireFistDamage = 10;
    public float basicPunchDamage = 5;

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
        if (other.CompareTag("FireFist") || other.CompareTag("Sweep"))
        {
            BossHit(fireFistDamage);
            Debug.Log(bossHealth);
            Destroy(other.gameObject);
        }

        if (other.CompareTag("BasicPunch"))
        {
            BossHit(basicPunchDamage);
            Debug.Log(bossHealth);
            Destroy(other.gameObject);
        }

        if (other.CompareTag("Sweep"))
        {
            bossHealth = bossHealth - 10;
            Debug.Log(bossHealth);
            Destroy(other.gameObject);
        }
        if (bossHealth <= 0)
        {
            Destroy(gameObject);
        }
        Debug.Log(bossHealth);
    }

    private void BossHit(float damage)
    {
        bossHealth -= damage;
    }
}
