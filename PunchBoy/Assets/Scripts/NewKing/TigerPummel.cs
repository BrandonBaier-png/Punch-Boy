using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TigerPummel : MonoBehaviour
{
    [SerializeField] private Object PummelPrefab;
    float pummelCooldown = 0;
    bool active = false;
    int rounds = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (pummelCooldown <= 0 && GameObject.Find("punchBoy") != null && active == true) {
            if (GameObject.Find("punchBoy").transform.position.x <= 1 && GameObject.Find("punchBoy").transform.position.x >= 0)
            {
                if (GameObject.Find("punchBoy").transform.position.z <= 1 && GameObject.Find("punchBoy").transform.position.z >= 0)
                {
                    Instantiate(PummelPrefab, new Vector3(.5f, 10, .5f), Quaternion.identity);
                }
                else if (GameObject.Find("punchBoy").transform.position.z <= 3 && GameObject.Find("punchBoy").transform.position.z >= 2)
                {
                    Instantiate(PummelPrefab, new Vector3(.5f, 10, 2.5f), Quaternion.identity);
                }
            }
            else if (GameObject.Find("punchBoy").transform.position.x <= 3 && GameObject.Find("punchBoy").transform.position.x >= 2) {
                if (GameObject.Find("punchBoy").transform.position.z <= 1 && GameObject.Find("punchBoy").transform.position.z >= 0)
                {
                    Instantiate(PummelPrefab, new Vector3(2.5f, 10, .5f), Quaternion.identity);
                }
                else if (GameObject.Find("punchBoy").transform.position.z <= 3 && GameObject.Find("punchBoy").transform.position.z >= 2)
                {
                    Instantiate(PummelPrefab, new Vector3(2.5f, 10, 2.5f), Quaternion.identity);
                }
            }
            pummelCooldown = 1.5f;
            rounds++;
        }
        if (pummelCooldown > 0) {
            pummelCooldown -= Time.deltaTime;
        }
        if (rounds >= 4) { 
            active = false;
            rounds = 0;
        }
    }
    public void enableAttack()
    {
        active = true;
    }
}
