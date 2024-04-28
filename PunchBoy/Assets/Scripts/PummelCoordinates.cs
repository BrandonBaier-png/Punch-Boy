using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PummelCoordinates : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject getPummel(int x)
    {
        int pos = 0;
        pos = x;
        return gameObject.transform.GetChild(pos).gameObject;
    }
}
