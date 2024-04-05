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
    public Animator animator;

    public UnityEvent SwipeEvent;
    public UnityEvent SuperSpunchEvent;
    public UnityEvent SpunchEvent;
    public UnityEvent PummelEvent;
   
    //AttackDel attackDel;



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
        //attackDel += CountAttack;
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
            //attackDel.Invoke();
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
                //GameObject SuperSpunchObject = GameObject.Find("SuperSpunchGameObject");
                //AttackEvent.Invoke();
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
        animator.SetBool("Spunch", true);
        print("Spunch Message 1");
        yield return new WaitForSeconds(2);
        print("Spunch Message 2");
        animator.SetBool("Spunch", false);
        SetAttacking(false);
    }
    IEnumerator CoSuperSpunch()
    {
        animator.SetBool("SuperSpunchPreparing", true);
        print("Super Spunch Message 1");


        GameObject SuperSpunchObject = GameObject.Find("SuperSpunchGameObject");
        SuperSpunchEvent.Invoke();

        yield return new WaitForSeconds(2);
        animator.SetBool("SuperSpunchPreparing", false);
        print("Super Spunch Message 2");
        SetAttacking(false);
    }
    
    IEnumerator CoPummel()
    {
        animator.SetBool("PummelStart", true);
        print("Pummel Message 1");

        yield return new WaitForSeconds(2);
        animator.SetBool("PummelStart", false);
        print("Pummel Message 2");
        SetAttacking(false);
    } 
    IEnumerator CoSwipe()
    {
        animator.SetBool("SwipeStart", true);
        print("Swipe Message 1");

        GameObject SwipeGameObject = GameObject.Find("SwipeGameObject");
        SwipeEvent.Invoke();

        yield return new WaitForSeconds(2);
        animator.SetBool("SwipeStart", false);
        print("swipe Message 2");
        SetAttacking(false);
    }

}
