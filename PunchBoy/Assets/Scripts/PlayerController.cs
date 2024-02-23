using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float tileMove = 500;
    public Transform movePoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            MovePlayer(Vector3.forward);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            MovePlayer(Vector3.left);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            MovePlayer(Vector3.back);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            MovePlayer(Vector3.right);
        }
    }

    private void MovePlayer(Vector3 direction)
    {
        transform.position += (direction * tileMove * Time.deltaTime);
    }


}
