using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
//static SuperSpunch might cause issues idk if it will
using static SuperSpunch;

/*
 * IAttack Manager
 * Tasked with randomizing the boss attack choices
 * Attacks are loaded into a queue & picked after a specified delay
 * 
 * 
 * Author - Brandon Baier 
 * 
 */


public delegate void AttackCalled();

public class AttackManager : MonoBehaviour
{
    AttackCalled onAttackCalled;


    //private Dictionary<>;
    private float Timer = 5;
    //Attack Info

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
        onAttackCalled += CountAttack;
    }

    // Update is called once per frame
    void Update()
    {
        //When the cooldown is less than zero, New King is ready to attack

        if (attackCooldown <= 0)
        {
            attackCooldown = BASECOOLDOWN;
            InitiateAttack();
            SetAttack(true);
            onAttackCalled.Invoke();
        }
        else
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
                print("ATTACK 1");
                AddOnSpunch();
                onAttackCalled.Invoke();
                RemoveOnSpunch();

                break;

            case 1:
                print("ATTACK 2");
                AddOnSuperSpunch();
                onAttackCalled.Invoke();
                RemoveOnSuperSpunch();
                break;

            case 2:
                print("ATTACK 3");
                AddOnPummel();
                onAttackCalled.Invoke();
                RemoveOnPummel();
                break;

            case 3:
                print("ATTACK 4");
                break;
        }


        print("Items in Queue" + attackQueue.Count);

    }
    void SetAttack(bool value)
    {
        attacking = value;
    }

    // Tallys the number of attacks that have occured 
    // Once tally is greater than initial, refills the queue
    void CountAttack()
    {
        attackTally++;
        print("Delegate has been called");
    }

    void EnqueueBossAttacks()
    {
        attackQueue.Enqueue(0);
        attackQueue.Enqueue(1);
        attackQueue.Enqueue(2);
        attackQueue.Enqueue(3);
    }

    public void AddOnSuperSpunch(AttackCalled)
    {
        //Add the required function calls here
    }
    public void RemoveOnSuperSpunch()
    {
        //Remove the required function calls here
    }
    public void AddOnSpunch()
    {

    }
    public void RemoveOnSpunch()
    {

    }

    public void AddOnPummel()
    {

    }
    public void RemoveOnPummel()
    {

    }


}
