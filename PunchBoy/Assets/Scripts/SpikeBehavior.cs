using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpikeBehavior : MonoBehaviour
{
    public Animator anim;
    SpikeCoordinates spikePos;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GameObject.Find("Spike 1").GetComponent<Animator>().SetBool("New Bool", true);
        GameObject.Find("Spike 2").GetComponent<Animator>().SetBool("New Bool", true);
    }

    void selectSpike()
    {
       
    }
}
