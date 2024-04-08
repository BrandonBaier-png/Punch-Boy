using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicPunch : MonoBehaviour
{
    public float speed = 30.0f;
    Vector3 bound;

    // Start is called before the first frame update
    void Start()
    {
        bound = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z >= bound.z + 1)
        {
            Destroy(gameObject);
        }

        else
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }
    }
}
