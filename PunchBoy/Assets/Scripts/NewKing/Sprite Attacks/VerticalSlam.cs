using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalSlam : StandardBossAttack
{

    float attackDelay = 1.25f;
    float attackInterval = 1.5f;
    public Animator animator;
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
        GroupAttack slam1Wave = gameObject.AddComponent<GroupAttack>();
        GroupAttack slam2 = gameObject.AddComponent<GroupAttack>();
        GroupAttack slam2Wave = gameObject.AddComponent<GroupAttack>();

        slam1.add(0, 1).add(0, 2).add(1, 1).add(1, 2).add(2, 1).add(2, 2).add(3, 1).add(3, 2).setWaitTime(attackDelay);
        slam1Wave.add(0, 0).add(0, 3).add(1, 0).add(1, 3).add(2, 0).add(2, 3).add(3, 0).add(3, 3).setWaitTime(attackInterval);
        slam2.add(1, 0).add(2, 0).add(1, 1).add(2, 1).add(1, 2).add(2, 2).add(1, 3).add(2, 3).setWaitTime(attackDelay);
        slam2Wave.add(0, 0).add(3, 0).add(0, 1).add(3, 1).add(0, 2).add(3, 2).add(0, 3).add(3, 3).setWaitTime(attackInterval);

        animator.SetTrigger("Swipe");
        yield return StartCoroutine(slam1.attack());
        yield return StartCoroutine(slam1Wave.attack());
        yield return StartCoroutine(slam2.attack());
        yield return StartCoroutine(slam2Wave.attack());
        animator.ResetTrigger("Swipe");
    }
}