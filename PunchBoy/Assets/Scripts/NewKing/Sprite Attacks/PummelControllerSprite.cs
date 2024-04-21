using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpikeInheritor : StandardBossAttack
{

    public override IEnumerator attackPattern()
    {
        print("Attack Pattern Overidden");
        return base.attackPattern();
    }
}