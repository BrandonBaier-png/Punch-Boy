using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TigerHealth : MonoBehaviour
{
    public float speed = .5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter(UnityEngine.Collider other)
    {  
        DetectCollisions.Destroy(other);
    }
}
