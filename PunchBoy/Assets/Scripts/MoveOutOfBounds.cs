using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
                            //was -1.50
    private float topBound = -1.51f;
    //private float lowerBound = -10;
    private int counter = 0;
    private Vector3 row1 = new Vector3(1.816654f, -1.89f, 0.65f);
    private Vector3 row2 = new Vector3(1.816654f, -1.89f, -0.82f);
    private Vector3 row3 = new Vector3(1.816654f, -1.89f, -1.82f);
    private Vector3 row4 = new Vector3(1.816654f, -1.89f, -2.75f);
    private Vector3[] positions = new Vector3[3];
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

                    gameObject.transform.position = row2;
                    ++counter;
                }
                break; 
            case 1:
                if (transform.position.y > topBound)
                {
         
                    gameObject.transform.position = row3;
                    ++counter;
                }
                break;
            case 2:
                if (transform.position.y > topBound)
                {

                    gameObject.transform.position = row4;
                    ++counter;
                }
                break;
            case 3:
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
