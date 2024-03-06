using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeRespawn : MonoBehaviour
{
    public GameObject spikes;
    private Vector3 row2 = new Vector3(2, -2, 0.82f);
    private Vector3 row3 = new Vector3(0, 0, 0);
    private Vector3 row4 = new Vector3(0, 0, 0);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnTriggerEnter(UnityEngine.Collider other)
    {
          if(other.tag == "Spike Row")
             Debug.Log("it hit!");
            other.transform.position = row2;
        
    }
}
