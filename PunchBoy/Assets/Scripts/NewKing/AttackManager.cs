using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

//static SuperSpunch might cause issues idk if it will


/*
 * Attack Manager
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

    /*
     * Might have to make this update into a coroutine of sorts to prevent it from moving on before ready
     * 
     */
    void Update()
    {
        //When the cooldown is less than zero, New King is ready to attack

        if (attackCooldown <= 0)
        {
            attackCooldown = BASECOOLDOWN;
            InitiateAttack();
            SetAttacking(true);
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
            case 0:
                StartCoroutine(CoSpunch());
                break;         
            case 1:
                StartCoroutine(CoSuperSpunch());
                break;
            case 2:
                StartCoroutine(CoPummel());
                break;
            case 3:
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

        GameObject SpunchObject = GameObject.Find("SpunchGameObject");
        SpunchEvent.Invoke();

        yield return new WaitForSeconds(2);
        animator.SetBool("Spunch", false);
        SetAttacking(false);
    }
    IEnumerator CoSuperSpunch()
    {
        animator.SetBool("SuperSpunchPreparing", true);


        GameObject SuperSpunchObject = GameObject.Find("SuperSpunchGameObject");
        SuperSpunchEvent.Invoke();

        yield return new WaitForSeconds(2);
        animator.SetBool("SuperSpunchPreparing", false);
        SetAttacking(false);
    }
    
    IEnumerator CoPummel()
    {
        animator.SetBool("PummelStart", true);

        yield return new WaitForSeconds(2);
        animator.SetBool("PummelStart", false);
        SetAttacking(false);
    } 
    IEnumerator CoSwipe()
    {
        animator.SetBool("SwipeStart", true);

        GameObject SwipeGameObject = GameObject.Find("SwipeGameObject");
        SwipeEvent.Invoke();

        yield return new WaitForSeconds(2);
        animator.SetBool("SwipeStart", false);
        SetAttacking(false);
    }

    /*
     * IEnumerator someRoutine() 
     *  {
     *  var routine = b.someOtherRoutine();
     *  yield return routine;
     *  }
     * 
     * 
     * 
     */

}
