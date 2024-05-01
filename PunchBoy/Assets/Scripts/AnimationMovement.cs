using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AnimationMovement : MonoBehaviour
{

    private float topBound = -2.4f;
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
                    gameObject.transform.position = row1;
                    ++counter;
                }
                break;
            case 1:
                if (transform.position.y > topBound)
                {
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
