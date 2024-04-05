using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    public float waitTime = 5;
    //public Animation anim;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(waiter());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator waiter()
    {
   
        //start at row 1
        gameObject.transform.position = new Vector3(-14.23f, -3.01f, 3.9781f);

        yield return new WaitForSecondsRealtime(waitTime);

        //move to row 2
        gameObject.transform.position = new Vector3(-14.84f, -3.35f, 3.9781f);

        
        yield return new WaitForSecondsRealtime(waitTime);

        //move to row 3
        gameObject.transform.position = new Vector3(-15.5f, -3.69f, 3.9781f);

        yield return new WaitForSecondsRealtime(waitTime);

        //move to row 4
        gameObject.transform.position = new Vector3(-16.12f, -4.12f, 3.9781f);

        yield return new WaitForSecondsRealtime(waitTime);
        Destroy(gameObject);    
    }
}
