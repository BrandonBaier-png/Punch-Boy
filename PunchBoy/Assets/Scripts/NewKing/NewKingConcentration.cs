using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewKingConcentration : MonoBehaviour
{
    // How many temporary hitpoints the boss has
    // bossConcentration reaching zero before the attack happens means the attack will cancel
    private float bossConcentration = 50;
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
