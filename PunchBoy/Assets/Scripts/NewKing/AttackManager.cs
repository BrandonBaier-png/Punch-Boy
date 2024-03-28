using System.Collections;
using System.Collections.Generic;
using System.Threading;
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
    AttackCalled attackManager;

    private float Timer = 5;
    //Attack Info
    private bool attacking = false;
    private int attackTally = 0;
    public const float ATTACKCOOLDOWN = 3;
    public float attackCooldown = 3;

    private Queue<int> attackQueue = new Queue<int>();

    // Start is called before the first frame update
    
    void Start()
    {
        attackQueue.Enqueue(0);
        attackQueue.Enqueue(1);
        attackQueue.Enqueue(2);
        attackQueue.Enqueue(3);

        attackManager += CountAttack;
    }

    // Update is called once per frame
    void Update()
    {
        if (attackCooldown <= 0)
        {
            attackCooldown = ATTACKCOOLDOWN;
            InitiateAttack();
            SetAttack(true);
            attackManager.Invoke();
        }
        else
        {
            attackCooldown -= Time.deltaTime;
        }
    }

    // When called, calls the attack 
    void InitiateAttack()
    {
        // need to call superspunch the c# file
        // Idk what needs to happen
        print(attackQueue.Dequeue());
        
        //if (attackQueue.Count)
        //{
            
        //}
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
}
