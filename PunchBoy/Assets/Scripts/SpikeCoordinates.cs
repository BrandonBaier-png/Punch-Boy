using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeCoordinates : MonoBehaviour
{
    //array positions in X and Y coordinates
    //(row * 4) + y
    //Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public GameObject getSpike(int x, int y)
    {
        int pos = 0;
        pos = (x * 4) + y;
        return gameObject.transform.GetChild(pos).gameObject;
    }
}

