using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PunchBoyHealth : MonoBehaviour
{
    private float maxHealth = 100;
    private float currentHealth = 100;
    private float ITime = 0;
    public Image PBHealthBar;

    private bool pbInvincible = false;
    private float PBINVINCIBLETIMERBASE = 0.05f;
    private float pbInvincibleTimer = 0.05f;


    public Animator Animator;
    // Start is called before the first frame update
    void Start()
    {
        SpriteMovement pbSpriteMovement = this.gameObject.GetComponent<SpriteMovement>();
            //print("FISHE SEARCH");
            if (pbSpriteMovement != null)
            {
                pbSpriteMovement.addToMovementTracker(toggleInvincible);
                //print("Sprite Movement Found");

   
            }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ITime > 0)
        {
            ITime -= Time.deltaTime;
        }

        if (pbInvincible)
        {
            //print("INVINCIBLE STATUS: " + pbInvincible);
            pbInvincibleTimer -= Time.deltaTime;
            if (pbInvincibleTimer < 0)
            {
                toggleInvincible(false);
                pbInvincibleTimer = PBINVINCIBLETIMERBASE;
            }
        }

        //print("Punch boy health " + health);
        //Debug.Log(health);
    }

    void OnTriggerEnter(UnityEngine.Collider collision)
    {
        BoxCollider spriteBox = collision.gameObject.GetComponent<BoxCollider>();
        if (collision.tag == "Spike" && ITime <= 0 && !pbInvincible)
        {
            dealtDamage();
            UpdateHealth();
            ITime = .3f;
        }
        if (currentHealth <= 0)
        {
            UpdateHealth();
            StartCoroutine(PunchBoyDead());
        }
    }

    public void toggleInvincible(bool status)
    {
        pbInvincible = status;
    }

    public void dealtDamage()
    {
        currentHealth -= 10;
    }

    public void UpdateHealth()
    {
        PBHealthBar.fillAmount = currentHealth / maxHealth;
    }

    IEnumerator PunchBoyDead() {
        Animator.SetTrigger("Death");
        Debug.Log("death animation triggered");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("GameOver");
    }
}
