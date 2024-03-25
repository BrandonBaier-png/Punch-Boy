using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PummelMove : MonoBehaviour
{
    public float speed = .5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Translate(Vector2.down * Time.deltaTime * speed);
        if (transform.position.y <= -2) {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter(UnityEngine.Collider other)
    {  
        DetectCollisions.Destroy(other);
    }
}
