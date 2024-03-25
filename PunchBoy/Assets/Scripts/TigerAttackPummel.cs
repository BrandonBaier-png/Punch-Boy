using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TigerAttackPummel : MonoBehaviour
{
    private float cooldown = 0;
    private int done = 0;
    private bool call = false;
    [SerializeField] private Object PummelObject;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.U) && call == false) { 
            call = true;
        }
        if (done >= 4) {
            call = false;
        }
        if (cooldown <= 0 && done < 4 && call == true)
        {
            if (GameObject.Find("punchBoy").transform.position.x >= 0 && GameObject.Find("punchBoy").transform.position.x <= 1 && GameObject.Find("punchBoy").transform.position.z <= 1 && GameObject.Find("punchBoy").transform.position.z >= 0)
            {
                var spawnPummel = Instantiate(PummelObject, new Vector3(0.5f, 4.5f, 0.5f), Quaternion.identity);
            }
            if (GameObject.Find("punchBoy").transform.position.x >= 2 && GameObject.Find("punchBoy").transform.position.x <= 3 && GameObject.Find("punchBoy").transform.position.z <= 1 && GameObject.Find("punchBoy").transform.position.z >= 0)
            {
                var spawnPummel = Instantiate(PummelObject, new Vector3(2.5f, 4.5f, 0.5f), Quaternion.identity);
            }
            if (GameObject.Find("punchBoy").transform.position.x >= 0 && GameObject.Find("punchBoy").transform.position.x <= 1 && GameObject.Find("punchBoy").transform.position.z <= 3 && GameObject.Find("punchBoy").transform.position.z >= 2)
            {
                var spawnPummel = Instantiate(PummelObject, new Vector3(0.5f, 4.5f, 2.5f), Quaternion.identity);
            }
            if (GameObject.Find("punchBoy").transform.position.x >= 2 && GameObject.Find("punchBoy").transform.position.x <= 3 && GameObject.Find("punchBoy").transform.position.z <= 3 && GameObject.Find("punchBoy").transform.position.z >= 2)
            {
                var spawnPummel = Instantiate(PummelObject, new Vector3(2.5f, 4.5f, 2.5f), Quaternion.identity);
            }
            cooldown = 1.5f;
            done++;
        }
        if (cooldown > 0) { 
            cooldown -= Time.deltaTime;
        }
    }
}
