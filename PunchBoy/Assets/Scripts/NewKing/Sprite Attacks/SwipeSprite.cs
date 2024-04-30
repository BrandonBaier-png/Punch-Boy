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

public class SwipeSprite : StandardBossAttack
{

    float secondsBetweenAttack = 0.2f;
    float secondsBetweenAttackWave = 0.7f;
    float secondsBetweenFinalWaves = 1.5f;
    public Animator animator;

    public AudioSource swipeAudio;
    // Start is called before the first frame update
    void Start()
    {

    }

    public override IEnumerator attackPattern()
    {
        //print("Pummel attackPattern Override has been called");
        StartCoroutine(SwipeAttack());
        return base.attackPattern();
    }
    // Update is called once per frame

    IEnumerator SwipeAttack()
    {
        /*      |      |      |
         * Row1 | Row2 | Row3 | Row4
         *      |      |      |
         */

        // Wave 1
        GroupAttack wave1row1 = gameObject.AddComponent<GroupAttack>();
        GroupAttack wave1row2 = gameObject.AddComponent<GroupAttack>();
        GroupAttack wave1row3 = gameObject.AddComponent<GroupAttack>();
        GroupAttack wave1row4 = gameObject.AddComponent<GroupAttack>();

        // Wave 2
        GroupAttack wave2row1 = gameObject.AddComponent<GroupAttack>();
        GroupAttack wave2row2 = gameObject.AddComponent<GroupAttack>();
        GroupAttack wave2row3 = gameObject.AddComponent<GroupAttack>();
        GroupAttack wave2row4 = gameObject.AddComponent<GroupAttack>();

        GroupAttack wave3row1 = gameObject.AddComponent<GroupAttack>();
        GroupAttack wave3row2 = gameObject.AddComponent<GroupAttack>();
        GroupAttack wave3row3 = gameObject.AddComponent<GroupAttack>();
        GroupAttack wave3row4 = gameObject.AddComponent<GroupAttack>();

        GroupAttack wave4row1 = gameObject.AddComponent<GroupAttack>();
        GroupAttack wave4row2 = gameObject.AddComponent<GroupAttack>();
        GroupAttack wave4row3 = gameObject.AddComponent<GroupAttack>();
        GroupAttack wave4row4 = gameObject.AddComponent<GroupAttack>();

        wave1row1.add(0, 0).setWaitTime(secondsBetweenAttack);
        wave1row2.add(0, 1).add(1, 1).setWaitTime(secondsBetweenAttack);
        wave1row3.add(0, 2).add(1, 2).add(2, 2).setWaitTime(secondsBetweenAttack);
        wave1row4.add(0, 3).add(1, 3).add(2, 3).add(3, 3).setWaitTime(secondsBetweenAttackWave); //extra delay to wait for the previous spikes to return
        
        wave2row4.add(0, 3).setWaitTime(secondsBetweenAttack);
        wave2row3.add(0, 2).add(1, 2).setWaitTime(secondsBetweenAttack);
        wave2row2.add(0, 1).add(1, 1).add(2, 1).setWaitTime(secondsBetweenAttack);
        wave2row1.add(0, 0).add(1, 0).add(2, 0).add(3, 0).setWaitTime(secondsBetweenFinalWaves);

        wave3row1.add(3, 0).add(2, 0).setWaitTime(secondsBetweenAttack);
        wave3row2.add(3, 1).add(2, 1).setWaitTime(secondsBetweenAttack);
        wave3row3.add(3, 2).add(2, 2).setWaitTime(secondsBetweenAttack);
        wave3row4.add(3, 3).add(2, 3).setWaitTime(secondsBetweenFinalWaves);

        wave4row1.add(0, 3).add(1, 3).setWaitTime(secondsBetweenAttack);
        wave4row2.add(0, 2).add(1, 2).setWaitTime(secondsBetweenAttack);
        wave4row3.add(0, 1).add(1, 1).setWaitTime(secondsBetweenAttack);
        wave4row4.add(0, 0).add(1, 0).setWaitTime(secondsBetweenAttack);

        animator.SetTrigger("SwipeStart");
        StartCoroutine(AudioDelay());
        yield return StartCoroutine(wave1row1.attack());
        yield return StartCoroutine(wave1row2.attack());
        yield return StartCoroutine(wave1row3.attack());
        yield return StartCoroutine(wave1row4.attack());
        animator.ResetTrigger("SwipeStart");
        animator.SetTrigger("SwipeStart");
        StartCoroutine(AudioDelay());
        yield return StartCoroutine(wave2row4.attack());
        yield return StartCoroutine(wave2row3.attack());
        yield return StartCoroutine(wave2row2.attack());
        yield return StartCoroutine(wave2row1.attack());
        animator.ResetTrigger("SwipeStart");
        animator.SetTrigger("SwipeStart");
        StartCoroutine(AudioDelay());
        yield return StartCoroutine(wave3row1.attack());
        yield return StartCoroutine(wave3row2.attack());
        yield return StartCoroutine(wave3row3.attack());
        yield return StartCoroutine(wave3row4.attack());
        animator.ResetTrigger("SwipeStart");
        animator.SetTrigger("SwipeStart");
        StartCoroutine(AudioDelay());
        yield return StartCoroutine(wave4row1.attack());
        yield return StartCoroutine(wave4row2.attack());
        yield return StartCoroutine(wave4row3.attack());
        yield return StartCoroutine(wave4row4.attack());
        animator.ResetTrigger("SwipeStart");
    }

    IEnumerator AudioDelay()
    {
        yield return new WaitForSeconds(1.0f);
        swipeAudio.Play();
    }
}