using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballDisperse : MonoBehaviour
{
    private float duration = 0.7f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (duration > 0)
        {
            duration -= Time.deltaTime;
        }

        if (duration <= 0)
        {
            Destroy(gameObject);
        }
    }
}
