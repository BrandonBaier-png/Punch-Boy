using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeRowMove : MonoBehaviour
{

    private float speed = 10.0f;
    private bool isHit = false;
    public GameObject spikeRow;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * Time.deltaTime * speed);
    }

   void OnTriggerEnter(UnityEngine.Collider other)
    {
        isHit = true;   
        DetectCollisions.Destroy(other);
    }

   public void moveSpikes(GameObject spikesToMove)
    {
        transform.Translate(Vector2.up * Time.deltaTime * speed);
    }
}
