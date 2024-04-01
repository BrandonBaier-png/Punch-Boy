using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swipe : MonoBehaviour
{
    public float speed = 30.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > 1)
        {
            Destroy(gameObject);
        }

        else
        {
            transform.Translate(Vector3.up * Time.deltaTime * speed);
        }
    }
}
