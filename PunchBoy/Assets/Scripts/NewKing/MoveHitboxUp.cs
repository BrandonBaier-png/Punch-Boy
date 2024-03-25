using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MoveHitboxUp : MonoBehaviour
{
    private float speed = 30;
    private float topBound = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * speed);

        if (transform.position.y > topBound && gameObject.CompareTag("Spike"))
        {
            Destroy(gameObject);
        }
    }
}
