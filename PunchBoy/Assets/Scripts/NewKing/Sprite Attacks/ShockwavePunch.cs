using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShockwavePunch : StandardBossAttack
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
        StartCoroutine(Shockwave());
        return base.attackPattern();
    }
    // Update is called once per frame

    IEnumerator Shockwave()
    {
        GroupAttack punch1 = gameObject.AddComponent<GroupAttack>();
        GroupAttack punch1wave1 = gameObject.AddComponent<GroupAttack>();
        GroupAttack punch2 = gameObject.AddComponent<GroupAttack>();
        GroupAttack punch2wave1 = gameObject.AddComponent<GroupAttack>();
        GroupAttack punch2wave2 = gameObject.AddComponent<GroupAttack>();
        GroupAttack punch3 = gameObject.AddComponent<GroupAttack>();
        GroupAttack punch3wave1 = gameObject.AddComponent<GroupAttack>();
        GroupAttack punch3wave2 = gameObject.AddComponent<GroupAttack>();

        punch1.add(1, 1).add(1, 2).add(2, 1).add(2, 2).setWaitTime(attackDelay);
        punch1wave1.add(0, 0).add(0, 1).add(0, 2).add(0, 3).add(1, 3).add(2, 3).add(3, 3).add(3, 2).add(3, 1).add(3, 0).add(2, 0).add(1, 0).setWaitTime(attackInterval);

        punch2.add(0, 2).add(0, 3).add(1, 2).add(1, 3).setWaitTime(attackDelay);
        punch2wave1.add(0, 1).add(1, 1).add(2, 1).add(2, 2).add(2, 3).setWaitTime(attackDelay);
        punch2wave2.add(0, 0).add(1, 0).add(2, 0).add(3, 0).add(3, 1).add(3, 2).add(3, 3).setWaitTime(attackInterval);

        punch3.add(2, 0).add(2, 1).add(3, 0).add(3, 1).setWaitTime(attackDelay);
        punch3wave1.add(1, 0).add(1, 1).add(1, 2).add(2, 2).add(3, 2).setWaitTime(attackDelay);
        punch3wave2.add(0, 0).add(0, 1).add(0, 2).add(0, 3).add(1, 3).add(2, 3).add(3, 3).setWaitTime(attackInterval);

        animator.SetTrigger("Swipe");
        yield return StartCoroutine(punch1.attack());
        yield return StartCoroutine(punch1wave1.attack());
        yield return StartCoroutine(punch2.attack());
        yield return StartCoroutine(punch2wave1.attack());
        yield return StartCoroutine(punch2wave2.attack());
        animator.ResetTrigger("Swipe");
    }
}