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



    //private float Timer = 5;
    //SORT OUT THESE VARIABLES LATER

    public GameObject spikeRow;
    private Vector3 spawnPos = new Vector3(1.5f, -2, 1.5f);


    private bool animationBuffer = false;
    private List<int> baseAttackList = new List<int>() { 0, 1, 2, 3 };
    
    private int secondsBetweenAttack = 4;
    private int secondsBetweenSuperSpunchAttack = 4;
    private bool attacking = false;
    private int attackTally = 0;
    public const float BASECOOLDOWN = 3;
    public float attackCooldown = 3;



    private Queue<int> attackQueue = new Queue<int>();
    private 

    int[] attackDatabase = { 1, 2, 3, 4 };

    // Start is called before the first frame update

    void Start()
    {
        //EnqueueBossAttacksFixed();
    }

    // Update is called once per frame

    /*
     * Might have to make this update into a coroutine of sorts to prevent it from moving on before ready
     * 
     */
    void Update()
    {
        //When the cooldown is less than zero, New King is ready to attack
        if (attackQueue.Count <= 0)
        {
            //EnqueueBossAttacks();
            EnqueueBossAttacksFixed();
        }

        if (attackCooldown <= 0)
        {
            attackCooldown = BASECOOLDOWN;
            // TEMP DISABLE ATTACK
            StartCoroutine(InitiateAttack());
            SetAttacking(true);
        }
        else if (!attacking)
        {
            attackCooldown -= Time.deltaTime;
        }

        
    }

    void EnqueueBossAttacksFixed()
    {


        /*
         * 0 - Spunch
         * 1 - Super Spunch
         * 2 - Pummmel 
         * 3 - Swipe
         */
        
        attackQueue.Enqueue(1);
        attackQueue.Enqueue(0);
        attackQueue.Enqueue(2);
        attackQueue.Enqueue(3);
       
    }


    void EnqueueBossAttacks()
    {
        /* Boss attack randomization doensn't function,
         * maybe try completely random, while storing & not repeating the previous 2 attacks through a delegate.
         * 
         * -Brando 
         */
        int i = 0;
        
        List<int> attackList = baseAttackList;
        List<string> stringList = new List<string>() { "Test1", "Test2", "Test3"};

        stringList.Remove("Test1");
        //attackList.Remove(i);
        
        while (attackQueue.Count < 5) {
            attackQueue.Enqueue(i);
            i++;
            print(attackQueue.Count + "Items in Queue :3");
        }
        //// attackList.Count might be causing the crash

        //int attackToQueue = Random.Range(0, attacksAvailable.Count);

        //attacksAvailable.Remove(attackToQueue);
        //print("Current attack queue: " + attackToQueue);



        //int attackToQueue = Random.Range(0, attackList.Count);
        //int selectedAttack = Random.Range(0, (attacksAvailable.Count - 1));
        //print("Current attack queue: " + selectedAttack);
        //attacksAvailable.Remove(selectedAttack);
        //attackQueue.Enqueue(selectedAttack);


    }

    // When called, calls the attack 
    IEnumerator InitiateAttack()
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
                //currentAttack = CoSpunch();
                break;
            case 3:
                currentAttack = CoSwipe();
                break;
        }
        //StartCoroutine(currentAttack);
        yield return StartCoroutine(currentAttack);
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

    

    // SPUNCH
    IEnumerator CoSpunch()
    {
        if (!animationBuffer)
        {
            animator.SetTrigger("Spunch");
            animationBuffer = true;
        }

        GameObject SpunchObject = GameObject.Find("SpunchGameObject");
        SpunchEvent.Invoke();

        yield return new WaitForSeconds(secondsBetweenAttack);
        animator.ResetTrigger("Spunch");
        animationBuffer = false;
        SetAttacking(false);
    }
    // SUPER SPUNCH
    IEnumerator CoSuperSpunch()
    {
        GameObject SuperSpunchObject = GameObject.Find("SuperSpunchGameObject");
        SuperSpunchEvent.Invoke();

        


        yield return new WaitForSeconds(secondsBetweenSuperSpunchAttack);
        //DestroyAllSpikes();
        animator.SetBool("SuperSpunchPreparing", false);
        animator.ResetTrigger("SuperSpunch");
        animationBuffer = false;
        SetAttacking(false);
    }
    // PUMMEL
    IEnumerator CoPummel()
    {
        print("PUMMEL ATTACK MANAGER");

        PummelEvent.Invoke();

        //StartCoroutine(waitUntilAttackCleared());
        

        yield return new WaitForSeconds(secondsBetweenAttack);
        SetAttacking(false);
        //print("PUMMEL END");

    }
    // SWIPE
    IEnumerator CoSwipe()
    {
        if (!animationBuffer)
        {
            animator.SetTrigger("Swipe");
            animationBuffer = true;
        }

        GameObject SwipeGameObject = GameObject.Find("SwipeGameObject");
        SwipeEvent.Invoke();

        yield return new WaitForSeconds(secondsBetweenAttack);
        animator.ResetTrigger("Swipe");
        animationBuffer = false;
        SetAttacking(false);
    }


    /* Below code is likely depricated
     * 
     * -Brandon
     */
    private void DestroyAllSpikes()
    {
        GameObject[] activeSpikes = GameObject.FindGameObjectsWithTag("Spike");
        foreach (GameObject Spike in activeSpikes)
        {
            Destroy(Spike);
        }

    }

    IEnumerator waitUntilAttackCleared()
    {
        GameObject[] allSpikes = GameObject.FindGameObjectsWithTag("Spike");

        while (allSpikes.Length > 0)
        {
            yield return null;
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
