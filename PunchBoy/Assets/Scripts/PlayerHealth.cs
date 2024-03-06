using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class PlayerHealth : MonoBehaviour
{
    private float health = 5000.0f;


    public void setHealth(float newHealth)
    {
        this.health = newHealth;
    }

    public float getHealth()
    {
        return health;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
