using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


//public delegate void HealthChanged(Boss newKing,
//    int oldHealth, int newHealth);

public delegate void BossHit();
public class Boss : MonoBehaviour
{
    public UnityEvent BossDamaged;

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
            BossHit(fireFistDamage);
            Debug.Log(bossHealth);
            Destroy(other.gameObject);
            UpdateHealth();
        }

        if (other.CompareTag("BasicPunch"))
        {
            BossHit(basicPunchDamage);
            Debug.Log(bossHealth);
            Destroy(other.gameObject);
            UpdateHealth();
        }

        if (currentHealth <= 0)
        {
            SceneManager.LoadScene("GameWin");
        }
        Debug.Log(bossHealth);

        BossDamaged.Invoke();

    }

    private void BossHit(float damage)
    {
        currentHealth -= damage;
    }

    public void UpdateHealth()
    {
        healthBar.fillAmount = currentHealth / bossHealth;
    }
}
