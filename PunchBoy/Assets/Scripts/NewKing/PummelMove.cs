using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PummelMove : MonoBehaviour
{
    float countdown = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        countdown -= Time.deltaTime;
        if (gameObject.transform.position.y <= -2 || GameObject.Find("punchBoy") == null) { 
            Destroy(gameObject);
        }
        if (gameObject.transform.position.y < 7 && countdown <= 0) {
            transform.Translate(Vector2.down * Time.deltaTime * 5);
        }
    }
}
