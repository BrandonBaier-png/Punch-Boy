using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShockwavePunch : StandardBossAttack
{

    float attackDelay = 1.25f;
    float attackInterval = 1.5f;
    public Animator animator;

    public AudioSource punchAudio;
    public AudioSource spikeAudio;
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

        punch1.add(1, 1).add(1, 2).add(2, 1).add(2, 2).setWaitTime(attackDelay);
        punch1wave1.add(0, 0).add(0, 1).add(0, 2).add(0, 3).add(1, 3).add(2, 3).add(3, 3).add(3, 2).add(3, 1).add(3, 0).add(2, 0).add(1, 0).setWaitTime(attackInterval);

        animator.SetTrigger("Spunch");
        StartCoroutine(AudioDelay());
        yield return StartCoroutine(punch1.attack());
        yield return StartCoroutine(punch1wave1.attack());
        animator.ResetTrigger("Spunch");
        animator.SetTrigger("Spunch");
        StartCoroutine(AudioDelay());
        yield return StartCoroutine(punch1.attack());
        yield return StartCoroutine(punch1wave1.attack());
        animator.ResetTrigger("Spunch");
    }

    IEnumerator AudioDelay()
    {
        yield return new WaitForSeconds(1.0f);
        punchAudio.Play();
        yield return new WaitForSeconds(1.0f);
        spikeAudio.Play();
    }
}