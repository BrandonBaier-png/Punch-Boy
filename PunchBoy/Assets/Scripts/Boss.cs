using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


//public delegate void HealthChanged(Boss newKing,
//    int oldHealth, int newHealth);


public delegate void BossHit(float damage);
public class Boss : MonoBehaviour
{
    SuperSpunchSprite superSpunchSprite;
    public UnityEvent BossDamaged;
    public BossHit onBossHit;

    //private float bossConcenInitial = 20;
    //private float bossConcen = 20;
    public Image healthBar;

    private float bossHealth = 200;
    private float currentHealth = 200;
    private float fireFistDamage = 10;
    private float basicPunchDamage = 5;

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


            // the bossHits below were BossHit before


            dealBossDamage(fireFistDamage);
            Debug.Log(bossHealth);
            Destroy(other.gameObject);
            UpdateHealth();
        }

        if (other.CompareTag("BasicPunch"))
        {
            dealBossDamage(basicPunchDamage);
            Debug.Log(bossHealth);
            Destroy(other.gameObject);
            UpdateHealth();
        }

        if (currentHealth <= 0)
        {
            SceneManager.LoadScene("GameWin");
        }
        Debug.Log(bossHealth);


    }

    private void dealBossDamage(float damage)
    {
        currentHealth -= damage;
        if (onBossHit != null)
        {
            onBossHit.Invoke(damage);
        }
    }

    public void AddOnHealthChanged(BossHit bossHit)
    {
        print("Found Da boss");

        onBossHit += bossHit;
        //currentHealth -= damage;
        
    }

    public void RemoveOnHealthChanged(BossHit bossHit)
    {
        print("REMOVED Da boss");

        onBossHit -= bossHit;
        //currentHealth -= damage;

    }

    public void UpdateHealth()
    {
        healthBar.fillAmount = currentHealth / bossHealth;
    }
}
