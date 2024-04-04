using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

//static SuperSpunch might cause issues idk if it will


/*
 * IAttack Manager
 * Tasked with randomizing the boss attack choices
 * Attacks are loaded into a queue & picked after a specified delay
 * 
 * 
 * Author - Brandon Baier 
 * 
 */

public delegate void AttackDel();

public class AttackManager : MonoBehaviour
{
    public UnityEvent AttackEvent;
    AttackDel attackDel;

    SuperSpunch superSpunch;

    private float Timer = 5;
    //SORT OUT THESE VARIABLES LATER

    public GameObject spikeRow;
    private Vector3 spawnPos = new Vector3(1.5f, -2, 1.5f);


    private bool attacking = false;
    private int attackTally = 0;
    public const float BASECOOLDOWN = 3;
    public float attackCooldown = 3;
    private Queue<int> attackQueue = new Queue<int>();

    // Start is called before the first frame update

    void Start()
    {
        EnqueueBossAttacks();

        //Adding methods to the attackManager delegate
        //Whenever attackManager is called, CountAttack is also called;
        attackDel += CountAttack;
    }

    // Update is called once per frame
    void Update()
    {
        //When the cooldown is less than zero, New King is ready to attack

        if (attackCooldown <= 0)
        {
            attackCooldown = BASECOOLDOWN;
            InitiateAttack();
            SetAttacking(true);
            attackDel.Invoke();
        }
        else if (!attacking)
        {
            attackCooldown -= Time.deltaTime;
        }

        if (attackQueue.Count == 0)
        {
            EnqueueBossAttacks();
        }
    }

    // When called, calls the attack 
    void InitiateAttack()
    {
        switch (attackQueue.Dequeue())
        {
            case 1:
                StartCoroutine(CoSpunch());
                break;         
            case 0:
                AttackEvent.Invoke();
                GameObject SuperSpunchObject = GameObject.Find("SuperSpunchGameObject");
                StartCoroutine(CoSuperSpunch());
                break;
            case 2:
                print("ATTACK 3");
                StartCoroutine(CoPummel());
                break;
            case 3:
                print("ATTACK 4");
                StartCoroutine(CoSwipe());
                break;
        }
    }

    
    void SetAttacking(bool value)
    {
        attacking = value;
    }

    // Tallys the number of attacks that have occured 
    // Once tally is greater than initial, refills the queue
    void CountAttack()
    {
        attackTally++;
    }

    void EnqueueBossAttacks()
    {
        //MAKE RANDOM
        attackQueue.Enqueue(0);
        attackQueue.Enqueue(1);
        attackQueue.Enqueue(2);
        attackQueue.Enqueue(3);
    }
    IEnumerator CoSpunch()
    {
        print("Spunch Message 1");
        yield return new WaitForSeconds(2);
        print("Spunch Message 2");
        SetAttacking(false);
    }
    IEnumerator CoSuperSpunch()
    {
        
        print("Super Spunch Message 1");
        yield return new WaitForSeconds(2);
        print("Super Spunch Message 2");
        SetAttacking(false);
    }
    
    IEnumerator CoPummel()
    {
        print("Pummel Message 1");
        yield return new WaitForSeconds(2);
        print("Pummel Message 2");
        SetAttacking(false);
    } 
    IEnumerator CoSwipe()
    {
        print("Swipe Message 1");
        yield return new WaitForSeconds(2);
        print("swipe Message 2");
        SetAttacking(false);
    }

}
