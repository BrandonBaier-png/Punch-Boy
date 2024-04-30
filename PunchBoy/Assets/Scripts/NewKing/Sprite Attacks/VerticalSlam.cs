using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalSlam : StandardBossAttack
{

    float attackDelay = 1.5f;
    public Animator animator;

    public AudioSource punchAudio;
    // Start is called before the first frame update
    void Start()
    {

    }

    public override IEnumerator attackPattern()
    {
        StartCoroutine(Slam());
        return base.attackPattern();
    }
    // Update is called once per frame

    IEnumerator Slam()
    {
        GroupAttack slam1 = gameObject.AddComponent<GroupAttack>();
        GroupAttack slam2 = gameObject.AddComponent<GroupAttack>();

        slam1.add(0, 1).add(0, 2).add(1, 1).add(1, 2).add(2, 1).add(2, 2).add(3, 1).add(3, 2).setWaitTime(attackDelay);
        slam2.add(1, 0).add(2, 0).add(1, 1).add(2, 1).add(1, 2).add(2, 2).add(1, 3).add(2, 3).setWaitTime(attackDelay);

        animator.SetTrigger("SwipeStart");
        StartCoroutine(AudioDelay());
        yield return StartCoroutine(slam1.attack());
        animator.ResetTrigger("SwipeStart");
        animator.SetTrigger("SwipeStart");
        StartCoroutine(AudioDelay());
        yield return StartCoroutine(slam2.attack());
        animator.ResetTrigger("SwipeStart");
    }

    IEnumerator AudioDelay()
    {
        yield return new WaitForSeconds(1.0f);
        punchAudio.Play();
    }
}