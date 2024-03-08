using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionResize : MonoBehaviour
{
    //Playercontroller
    [SerializeField] private Object lastPositionObject;
    [SerializeField] private Object currentPositionObject;


    // Start is called before the first frame update
    void Start()
    {
        var lastPosition = Instantiate(lastPositionObject, new Vector3(0, 0, 0), Quaternion.identity);
        var currentPosition = Instantiate(currentPositionObject, new Vector3(0, 0, 0), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
