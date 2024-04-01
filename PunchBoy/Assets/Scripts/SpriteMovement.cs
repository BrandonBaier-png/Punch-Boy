using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("punchBoy") == null) { 
            Destroy(gameObject);
        }
        else if (GameObject.Find("punchBoy").transform.position.z == 0)
        {
            if (GameObject.Find("punchBoy").transform.position.x == 0)
            {
                gameObject.transform.position = new Vector3(-14.61f, -0.77f, 0);
            }
            else if (GameObject.Find("punchBoy").transform.position.x == 1)
            {
                gameObject.transform.position = new Vector3(-13.97f, -1.1f, 0);
            }
            else if (GameObject.Find("punchBoy").transform.position.x == 2)
            {
                gameObject.transform.position = new Vector3(-13.35f, -1.44f, 0);
            }
            else if (GameObject.Find("punchBoy").transform.position.x == 3)
            {
                gameObject.transform.position = new Vector3(-12.73f, -1.74f, 0);
            }
        }
        else if (GameObject.Find("punchBoy").transform.position.z == 1)
        {
            if (GameObject.Find("punchBoy").transform.position.x == 0)
            {
                gameObject.transform.position = new Vector3(-14.016f, -0.474f, 0);
            }
            else if (GameObject.Find("punchBoy").transform.position.x == 1)
            {
                gameObject.transform.position = new Vector3(-13.373f, -0.791f, 0);
            }
            else if (GameObject.Find("punchBoy").transform.position.x == 2)
            {
                gameObject.transform.position = new Vector3(-12.738f, -1.133f, 0);
            }
            else if (GameObject.Find("punchBoy").transform.position.x == 3)
            {
                gameObject.transform.position = new Vector3(-12.087f, -1.426f, 0);
            }
        }
        else if (GameObject.Find("punchBoy").transform.position.z == 2) {
            if (GameObject.Find("punchBoy").transform.position.x == 0)
            {
                gameObject.transform.position = new Vector3(-13.365f, -0.164f, 0);
            }
            else if (GameObject.Find("punchBoy").transform.position.x == 1)
            {
                gameObject.transform.position = new Vector3(-12.746f, -0.482f, 0);
            }
            else if (GameObject.Find("punchBoy").transform.position.x == 2)
            {
                gameObject.transform.position = new Vector3(-12.103f, -0.791f, 0);
            }
            else if (GameObject.Find("punchBoy").transform.position.x == 3)
            {
                gameObject.transform.position = new Vector3(-11.444f, -1.084f, 0);
            }
        }
        else if (GameObject.Find("punchBoy").transform.position.z == 3)
        {
            if (GameObject.Find("punchBoy").transform.position.x == 0)
            {
                gameObject.transform.position = new Vector3(-12.738f, 0.145f, 0);
            }
            else if (GameObject.Find("punchBoy").transform.position.x == 1)
            {
                gameObject.transform.position = new Vector3(-12.079f, -0.181f, 0);
            }
            else if (GameObject.Find("punchBoy").transform.position.x == 2)
            {
                gameObject.transform.position = new Vector3(-11.452f, -0.466f, 0);
            }
            else if (GameObject.Find("punchBoy").transform.position.x == 3)
            {
                gameObject.transform.position = new Vector3(-10.809f, -0.783f, 0);
            }
        }

    }
}
