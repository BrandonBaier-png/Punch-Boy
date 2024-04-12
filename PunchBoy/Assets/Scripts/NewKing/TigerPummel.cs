using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TigerPummel : MonoBehaviour
{
    [SerializeField] private Object PummelPrefab;
    [SerializeField] private Object Pummel2d;
    float pummelCooldown = 0;
    bool active = false;
    int rounds = 0;
    private bool activeAttack = false;
    private float height = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (activeAttack)
        {
            print("PUMMEL HAS BEEN CALLED :3");
            if (pummelCooldown <= 0 && GameObject.Find("punchBoy") != null) {
                if (GameObject.Find("punchBoy").transform.position.x <= 1 && GameObject.Find("punchBoy").transform.position.x >= 0)
                {
<<<<<<< Updated upstream
                    if (GameObject.Find("punchBoy").transform.position.z <= 1 && GameObject.Find("punchBoy").transform.position.z >= 0)
                    {
                        Instantiate(PummelPrefab, new Vector3(.5f, height, .5f), Quaternion.identity);
                    }
                    else if (GameObject.Find("punchBoy").transform.position.z <= 3 && GameObject.Find("punchBoy").transform.position.z >= 2)
                    {
                        Instantiate(PummelPrefab, new Vector3(.5f, height, 2.5f), Quaternion.identity);
                    }
                }
                else if (GameObject.Find("punchBoy").transform.position.x <= 3 && GameObject.Find("punchBoy").transform.position.x >= 2) {
                    if (GameObject.Find("punchBoy").transform.position.z <= 1 && GameObject.Find("punchBoy").transform.position.z >= 0)
                    {
                        Instantiate(PummelPrefab, new Vector3(2.5f, height, .5f), Quaternion.identity);
                    }
                    else if (GameObject.Find("punchBoy").transform.position.z <= 3 && GameObject.Find("punchBoy").transform.position.z >= 2)
                    {
                        Instantiate(PummelPrefab, new Vector3(2.5f, height, 2.5f), Quaternion.identity);
                    }
=======
                    Instantiate(PummelPrefab, new Vector3(.5f, 10, .5f), Quaternion.identity);
                    Instantiate(Pummel2d, new Vector3(-14.06f, 3.64f, 0f), Quaternion.identity);
                }
                else if (GameObject.Find("punchBoy").transform.position.z <= 3 && GameObject.Find("punchBoy").transform.position.z >= 2)
                {
                    Instantiate(PummelPrefab, new Vector3(.5f, 10, 2.5f), Quaternion.identity);
                    Instantiate(Pummel2d, new Vector3(-12.94f, 3.5f, 0f), Quaternion.identity);
>>>>>>> Stashed changes
                }
                pummelCooldown = 1.5f;
                rounds++;
            }
<<<<<<< Updated upstream
            if (pummelCooldown > 0) {
                pummelCooldown -= Time.deltaTime;
=======
            else if (GameObject.Find("punchBoy").transform.position.x <= 3 && GameObject.Find("punchBoy").transform.position.x >= 2) {
                if (GameObject.Find("punchBoy").transform.position.z <= 1 && GameObject.Find("punchBoy").transform.position.z >= 0)
                {
                    Instantiate(PummelPrefab, new Vector3(2.5f, 10, .5f), Quaternion.identity);
                    Instantiate(Pummel2d, new Vector3(-12.94f, 3.7f, 0f), Quaternion.identity);
                }
                else if (GameObject.Find("punchBoy").transform.position.z <= 3 && GameObject.Find("punchBoy").transform.position.z >= 2)
                {
                    Instantiate(PummelPrefab, new Vector3(2.5f, 10, 2.5f), Quaternion.identity);
                    Instantiate(Pummel2d, new Vector3(-11.5f, 3.64f, 0f), Quaternion.identity);
                }
>>>>>>> Stashed changes
            }
            if (rounds >= 4) {
                rounds = 0;
                CurrentAttack(false);
            }
            
        }
    }
    public void CurrentAttack(bool value)
    {
        activeAttack = value;
    }

    public void EnableAttack()
    {
        activeAttack = true;
    }
}

