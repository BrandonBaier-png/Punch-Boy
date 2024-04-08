using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NewKingConcentration : MonoBehaviour
{
    UnityEvent takeDamage = new UnityEvent();
    private float bossConcentration = 50;

    // How many temporary hitpoints the boss has
    // bossConcentration reaching zero before the attack happens means the attack will cancel

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void decreaseHealth(float damage)
    {
        bossConcentration -= damage;
    }


}
