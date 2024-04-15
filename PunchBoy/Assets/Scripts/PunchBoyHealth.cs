using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PunchBoyHealth : MonoBehaviour
{
    private float maxHealth = 100;
    private float currentHealth = 100;
    public Image PBHealthBar;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        

        //print("Punch boy health " + health);
        //Debug.Log(health);
    }

    void OnTriggerEnter(UnityEngine.Collider collision)
    {
        PlayerController player = collision.gameObject.GetComponent<PlayerController>();
        if (collision.tag == "Spike")
        {
            dealtDamage();
            UpdateHealth();
        }
        if (currentHealth <= 0)
        {
            UpdateHealth();
            SceneManager.LoadScene("GameOver");
        }
    }

    public void dealtDamage()
    {
        currentHealth -= 25;
    }

    public void UpdateHealth()
    {
        PBHealthBar.fillAmount = currentHealth / maxHealth;
    }
}
