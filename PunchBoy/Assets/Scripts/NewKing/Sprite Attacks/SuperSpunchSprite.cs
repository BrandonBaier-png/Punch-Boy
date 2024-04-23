using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/*
 * SuperSpunchSprite Controller 
 * Author - Brandon Baier
 * 
 * Originally meant for the 3d sprite version of this attack,
 * It has been repurposed for use in a 2d environment
 * 
 */

public class SuperSpunchSprite : StandardBossAttack
{
    private float BASETEMPBOSSHEALTH = 25;
    // THIS IS A PROOF OF CONCEPT HEALTH, WE CAN CHANGE IT AT ANY TIME
    private float TempBossHealth;
    float spunchTimer = 4;
    // Start is called before the first frame update

    private void Start()
    {
        
    }

    public override IEnumerator attackPattern()
    {
        TempBossHealth = BASETEMPBOSSHEALTH;
        AttatchToDelegate();

        StartCoroutine(CallSuperSpunchAttack());
        return base.attackPattern();
    }

    IEnumerator CallSuperSpunchAttack()
    {
        GroupAttack allSpikes = gameObject.AddComponent<GroupAttack>();

        for (int x = 0; x < 4; x++) {
            for (int y = 0; y < 4; y++)
            {
                allSpikes.add(x, y);
            }
        }

        print("Waiting for boss countdown");
        yield return new WaitForSeconds(spunchTimer);
        print("Boss Health " + TempBossHealth);
        if (TempBossHealth > 0)
        {
            yield return StartCoroutine(allSpikes.attack());

        }
        RemoveFromDelegate();
    }

    public void dealTempDamage(float damage)
    {
        TempBossHealth -= damage;
    }


    private void AttatchToDelegate()
    {
        GameObject boss = GameObject.Find("Boss");
        if (boss != null)
        {
            Boss bossController = boss.GetComponent<Boss>();
            if (bossController != null)
            {
                bossController.AddOnHealthChanged(dealTempDamage);
            }
        }
    }

    private void RemoveFromDelegate()
    {
        GameObject boss = GameObject.Find("Boss");
        if (boss != null)
        {
            Boss bossController = boss.GetComponent<Boss>();
            if (bossController != null)
            {
                bossController.RemoveOnHealthChanged(dealTempDamage);
            }
        }
    }
}
