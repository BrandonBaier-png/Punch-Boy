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

    public Animator Animator;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (ITime > 0)
        {
            ITime -= Time.deltaTime;
        }

        //print("Punch boy health " + health);
        //Debug.Log(health);
    }

    void OnTriggerEnter(UnityEngine.Collider collision)
    {
        BoxCollider spriteBox = collision.gameObject.GetComponent<BoxCollider>();
        if (collision.tag == "Spike" && ITime <= 0)
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

    public void dealtDamage()
    {
        print("Punch Boy Dealt Damage :3");
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
