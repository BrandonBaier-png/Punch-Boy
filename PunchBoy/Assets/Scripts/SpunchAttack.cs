using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpunchAttack : MonoBehaviour
{

    SpikeCoordinates getSpikePos;

    //GameObject spike1;


    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<SpikeCoordinates>().getSpike(0, 0);
       
    }
    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<SpikeBehavior>().playAnimation(gameObject);
    }
}

