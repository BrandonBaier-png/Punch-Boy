using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// I'm making a comment here so I can push to help someone troubleshoot their version
public class AnimationMovement : MonoBehaviour
{
    //was -1.50
    private float topBound = -2.4f;
    //private float lowerBound = -10;
    private int counter = 0;
    private Vector3 row1 = new Vector3(-14.27602f, -3.024747f, 3.978167f);
    private Vector3 row2 = new Vector3(-14.82f, -3.38f, 3.978167f);
    private Vector3 row3 = new Vector3(-15.44f, -3.67f, 3.978167f);
    private Vector3 row4 = new Vector3(-16.09f, -3.99f, 3.978167f);
    // Start is called before the first frame update
    void Start()
    {
   
    }

    // Update is called once per frame
    void Update()
    {

        switch (counter)
        {
            case 0:
                if (transform.position.y > topBound)
                {
                    //GameObject.Find("Spike Row Animation").transform.position = new Vector3(-14.941f, -3.405f, -3.978167f);
                    gameObject.transform.position = row1;
                    ++counter;
                }
                break;
            case 1:
                if (transform.position.y > topBound)
                {
                    //GameObject.Find("Spike Row Animation").transform.position = new Vector3(-14.941f, -3.405f, -3.978167f);
                    gameObject.transform.position = row2;
                    ++counter;
                }
                break;
            case 2:
                if (transform.position.y > topBound)
                {

                    gameObject.transform.position = row3;
                    ++counter;
                }
                break;
            case 3:
                if (transform.position.y > topBound)
                {

                    gameObject.transform.position = row4;
                    ++counter;
                }
                break;
            case 4:
                if (transform.position.y > topBound)
                {
                    Destroy(gameObject);
                }
                break;
        }
    }
}



/*
        if (transform.position.y > topBound && counter == 0)
        {
            *//*Destroy(gameObject);*//*
            gameObject.transform.position = row2;
            ++counter;
        }
        else if (transform.position.y > topBound && counter == 1)
        {
            *//*Destroy(gameObject);*//*
            gameObject.transform.position = row3;
            ++counter;
        }
        else if (transform.position.y > topBound && counter == 2)
        {
            *//*Destroy(gameObject);*//*
            gameObject.transform.position = row4;
            ++counter;
        }
        else if (transform.position.y > topBound && counter == 3)
        {
            Destroy(gameObject);
        }
        else if (transform.position.y < lowerBound)
        {
            *//*Destroy(gameObject);*//*
        }*/


/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class SpikeRespawn : MonoBehaviour
{

    private Vector3 row2 = new Vector3(1.816654f, -0.97f, -0.82f);
    private Vector3 row3 = new Vector3(1.816654f, -0.97f, -1.82f);
    private Vector3 row4 = new Vector3(1.816654f, -0.97f, -2.75f);
    private Vector3[] positions = new Vector3[3];

    // Start is called before the first frame update
    void Start()
    {
        positions[0] = row2;
        positions[1] = row3;
        positions[2] = row4;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(UnityEngine.Collider other)
    {
        // int counter = 0;
        if (other.tag == "Respawn" || other.tag == "Player")
        {
            Debug.Log("Im here");
            Debug.Log("it hit!");
            Debug.Log(gameObject.name);
            *//*Debug.Log(gameObject.pos);*//*
            gameObject.transform.position = row2;*//*

        }
    }
}
*/


