using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class moveScreenNStuff : MonoBehaviour
{
    private float scene = 10;
    int pair = 1;
    public SpriteRenderer rend;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (scene <= 0) {
            if (pair > 2) { pair = 1; }
            if (pair % 2 == 0) 
            { 
                scene = 10;
                rend.sortingOrder = -10;
            }
            else 
            { 
                scene = 7;
                rend.sortingOrder = 10;
            }
            pair++;
        }

        if (scene > 0) { 
            scene -= Time.deltaTime;
        }


    }
}
