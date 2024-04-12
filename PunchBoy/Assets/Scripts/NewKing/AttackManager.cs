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

    private IEnumerator currentAttack;

    public UnityEvent SwipeEvent;
    public UnityEvent SuperSpunchEvent;
    public UnityEvent SpunchEvent;
    public UnityEvent PummelEvent;

    //AttackDel attackDel;



    private float Timer = 5;
    //SORT OUT THESE VARIABLES LATER

    public GameObject spikeRow;
    private Vector3 spawnPos = new Vector3(1.5f, -2, 1.5f);


    private List<int> baseAttackList = new List<int>() { 0, 1, 2, 3 };
    private List<int> attackList = new List<int>();
    private int secondsBetweenAttack = 4;
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
            EnqueueBossAttacksFixed();
            //EnqueueBossAttacks()
        }
    }

    // When called, calls the attack 
    void InitiateAttack()
    {
        switch (attackQueue.Dequeue())
        {
            case 0:
                currentAttack = CoSpunch();
                break;         
            case 1:
                currentAttack = CoSuperSpunch();
                break;
            case 2:
                currentAttack = CoPummel();
                break;
            case 3:
                currentAttack = CoSwipe();
                break;
        }

        StartCoroutine(currentAttack);
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

    void EnqueueBossAttacksFixed()
    {
        //MAKE RANDOM
        attackQueue.Enqueue(0);
        attackQueue.Enqueue(1);
        attackQueue.Enqueue(2);
        //attackQueue.Enqueue(2);
        attackQueue.Enqueue(3);
    }

    void EnqueueBossAttacks()
    {
        attackList = baseAttackList;
        //for 
        //int n = rand() % attackList.;
        //printf("%s\n", array[n]);
        //MAKE RANDOM
        attackQueue.Enqueue(0);
        attackQueue.Enqueue(1);
        attackQueue.Enqueue(2);
        //attackQueue.Enqueue(2);
        attackQueue.Enqueue(3);
    }
    // SPUNCH
    IEnumerator CoSpunch()
    {
        animator.SetBool("Spunch", true);

        GameObject SpunchObject = GameObject.Find("SpunchGameObject");
        SpunchEvent.Invoke();

        yield return new WaitForSeconds(secondsBetweenAttack);
        animator.SetBool("Spunch", false);
        SetAttacking(false);
    }
    // SUPER SPUNCH
    IEnumerator CoSuperSpunch()
    {
        animator.SetBool("SuperSpunchPreparing", true);


        GameObject SuperSpunchObject = GameObject.Find("SuperSpunchGameObject");
        SuperSpunchEvent.Invoke();

        yield return new WaitForSeconds(secondsBetweenAttack);
        DestroyAllSpikes();
        animator.SetBool("SuperSpunchPreparing", false);
        SetAttacking(false);
    }
    // PUMMEL
    IEnumerator CoPummel()
    {
        //print("PUMMEL START");
        animator.SetBool("PummelStart", true);
        PummelEvent.Invoke();
        yield return new WaitForSeconds(secondsBetweenAttack);
        animator.SetBool("PummelStart", false);
        SetAttacking(false);
        //print("PUMMEL END");

    }
    // SWIPE
    IEnumerator CoSwipe()
    {
        animator.SetBool("SwipeStart", true);

        GameObject SwipeGameObject = GameObject.Find("SwipeGameObject");
        SwipeEvent.Invoke();

        yield return new WaitForSeconds(secondsBetweenAttack);
        animator.SetBool("SwipeStart", false);
        SetAttacking(false);
    }

    private void DestroyAllSpikes()
    {
        GameObject[] activeSpikes = GameObject.FindGameObjectsWithTag("Spike");
        foreach (GameObject Spike in activeSpikes)
        {
            Destroy(Spike);
        }

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
