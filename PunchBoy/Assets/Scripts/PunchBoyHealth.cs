using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        if (health <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    public void dealtDamage()
    {
        health -= 25;
    }
}
