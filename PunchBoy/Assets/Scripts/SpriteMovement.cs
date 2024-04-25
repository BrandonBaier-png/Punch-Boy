using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
//using UnityEngine.SceneManagement;

public class SpriteMovement : MonoBehaviour
{
    private float aniCooldown = 0.0f;
    private float fireballCD = 0.0f;
    private float sweepCD = 0.0f;
    private float punchCD = 0.0f;

    public Animator animator;
    public GameObject fireballPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //  NOTE - Do not destory the punch boy object, this code will cause a large amount of errors if it is deleted. 
        //
        //
        if (GameObject.Find("punchBoy").transform.position.z == 0)
        {
            if (GameObject.Find("punchBoy").transform.position.x == 0)
            {
                gameObject.transform.position = new Vector3(-14.81f, -0.7f, 0);
            }
            else if (GameObject.Find("punchBoy").transform.position.x == 1)
            {
                gameObject.transform.position = new Vector3(-14.1f, -1.06f, 0);
            }
            else if (GameObject.Find("punchBoy").transform.position.x == 2)
            {
                gameObject.transform.position = new Vector3(-13.47f, -1.37f, 0);
            }
            else if (GameObject.Find("punchBoy").transform.position.x == 3)
            {
                gameObject.transform.position = new Vector3(-12.87f, -1.74f, 0);
            }
        }
        else if (GameObject.Find("punchBoy").transform.position.z == 1)
        {
            if (GameObject.Find("punchBoy").transform.position.x == 0)
            {
                gameObject.transform.position = new Vector3(-14.13f, -0.42f, 0);
            }
            else if (GameObject.Find("punchBoy").transform.position.x == 1)
            {
                gameObject.transform.position = new Vector3(-13.5f, -0.74f, 0);
            }
            else if (GameObject.Find("punchBoy").transform.position.x == 2)
            {
                gameObject.transform.position = new Vector3(-12.86f, -1.06f, 0);
            }
            else if (GameObject.Find("punchBoy").transform.position.x == 3)
            {
                gameObject.transform.position = new Vector3(-12.19f, -1.35f, 0);
            }
        }
        else if (GameObject.Find("punchBoy").transform.position.z == 2) {
            if (GameObject.Find("punchBoy").transform.position.x == 0)
            {
                gameObject.transform.position = new Vector3(-13.49f, -0.09f, 0);
            }
            else if (GameObject.Find("punchBoy").transform.position.x == 1)
            {
                gameObject.transform.position = new Vector3(-12.84f, -0.41f, 0);
            }
            else if (GameObject.Find("punchBoy").transform.position.x == 2)
            {
                gameObject.transform.position = new Vector3(-12.25f, -0.76f, 0);
            }
            else if (GameObject.Find("punchBoy").transform.position.x == 3)
            {
                gameObject.transform.position = new Vector3(-11.6f, -1.03f, 0);
            }
        }
        else if (GameObject.Find("punchBoy").transform.position.z == 3)
        {
            if (GameObject.Find("punchBoy").transform.position.x == 0)
            {
                gameObject.transform.position = new Vector3(-12.87f, 0.2f, 0);
            }
            else if (GameObject.Find("punchBoy").transform.position.x == 1)
            {
                gameObject.transform.position = new Vector3(-12.22f, -0.1f, 0);
            }
            else if (GameObject.Find("punchBoy").transform.position.x == 2)
            {
                gameObject.transform.position = new Vector3(-11.61f, -0.42f, 0);
            }
            else if (GameObject.Find("punchBoy").transform.position.x == 3)
            {
                gameObject.transform.position = new Vector3(-10.98f, -0.72f, 0);
            }
        }
        if (sweepCD > 0) { sweepCD -= Time.deltaTime; }
        if (fireballCD > 0) { fireballCD -= Time.deltaTime; }
        if (punchCD > 0) { punchCD -= Time.deltaTime; }
        if (aniCooldown > 0) { aniCooldown -= Time.deltaTime; }
        if (aniCooldown <= 0)
        {
            animator.SetBool("punchBool", false);
            animator.SetBool("sweepBool", false);
            animator.SetBool("firePunchBool", false);
        }
        if (Input.GetKeyDown(KeyCode.J) && punchCD <= 0)
        {
            punchCD = 1.0f;
            animator.SetBool("punchBool", true);
            aniCooldown = .3f;
        }
        if (Input.GetKeyDown(KeyCode.K) && sweepCD <= 0)
        {
            sweepCD = 5.0f;
            animator.SetBool("sweepBool", true);
            aniCooldown = .3f;
        }
        if (Input.GetKeyDown(KeyCode.L) && fireballCD <= 0)
        {
            fireballCD = 1.0f;
            animator.SetBool("firePunchBool", true);
            aniCooldown = .3f;
            Instantiate(fireballPrefab, transform.position, fireballPrefab.transform.rotation);
        }
    }
}
