using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author - Brandon Baier / Turner Norum
 * 
 * The logic behind 2d Swipe, 
 * Designed for 3d by Turner Norum / Altered for 2d by Brandon Baier
 * 
 */

public class MoonSwipe : StandardBossAttack
{

    float secondsBetweenAttack = 0.15f;
    float secondsBetweenAttackWave = 1.0f;
    public Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    public override IEnumerator attackPattern()
    {
        //print("Pummel attackPattern Override has been called");
        StartCoroutine(MSwipe());
        return base.attackPattern();
    }
    // Update is called once per frame

    IEnumerator MSwipe()
    {
        /*      |      |      |
         * Row1 | Row2 | Row3 | Row4
         *      |      |      |
         */

        // Wave 1
        GroupAttack wave1row1 = gameObject.AddComponent<GroupAttack>();
        GroupAttack wave1row2 = gameObject.AddComponent<GroupAttack>();
        GroupAttack wave1row3 = gameObject.AddComponent<GroupAttack>();
        GroupAttack wave2row1 = gameObject.AddComponent<GroupAttack>();
        GroupAttack wave2row2 = gameObject.AddComponent<GroupAttack>();
        GroupAttack wave2row3 = gameObject.AddComponent<GroupAttack>();

        wave1row1.add(0, 1).add(1, 2).add(2, 2).add(3, 1).setWaitTime(secondsBetweenAttack);
        wave1row2.add(0, 2).add(1, 3).add(2, 3).add(3, 2).setWaitTime(secondsBetweenAttack);
        wave1row3.add(0, 3).add(3, 3).setWaitTime(secondsBetweenAttackWave);

        wave2row1.add(0, 2).add(1, 1).add(2, 1).add(3, 2).setWaitTime(secondsBetweenAttack);
        wave2row2.add(0, 1).add(1, 0).add(2, 0).add(3, 1).setWaitTime(secondsBetweenAttack);
        wave2row3.add(0, 0).add(3, 0).setWaitTime(secondsBetweenAttackWave);

        animator.SetTrigger("SwipeStart");
        yield return StartCoroutine(wave1row1.attack());
        yield return StartCoroutine(wave1row2.attack());
        yield return StartCoroutine(wave1row3.attack());
        animator.ResetTrigger("SwipeStart");
        animator.SetTrigger("SwipeStart");
        yield return StartCoroutine(wave2row1.attack());
        yield return StartCoroutine(wave2row2.attack());
        yield return StartCoroutine(wave2row3.attack());
        animator.ResetTrigger("SwipeStart");
    }
}