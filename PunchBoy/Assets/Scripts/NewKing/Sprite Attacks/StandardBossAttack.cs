using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author - Brandon Baier
 * 
 * A parent class to base the other boss attack functions off of 
 * "playSpikes()" is to be made virtual in order to determine what runs in the children classes
 */

public class StandardBossAttack : MonoBehaviour
{
    private List<SpikeBehavior> spikeList = new List<SpikeBehavior>();
    public Animator spunchTigerAnim;
    private bool triggerAnim = false;
    private float spikeWaitTime = 0.5f;
    private bool activeAttack = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (activeAttack)
        {
            //print("SUPERSPUNCH ACTIVE");
            StartCoroutine(attackPattern());
            CurrentAttack(false);
        }
    }

    public virtual IEnumerator attackPattern()
    {
       yield return null;
    }

    // Sets if this attack is currently happening
    public void CurrentAttack(bool value)
    {
        activeAttack = value;
    }

    // Method called by the AttackManager to enable the attack for the first time
    public void EnableAttack()
    {
        activeAttack = true;
    }
}
