using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PlayerHealth;

public class SpikeMove : MonoBehaviour
{

    private float speed = 10.0f;
    private int attackNumber = 1;
    private float attackDamage = 10.0f;
    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        spikePunch();
        
    }

    private int RandomNumber()
    {
        //syntax = Random.Range(-spawnRange, spawnRange);
        int randNum = Random.Range(0, 3);
        return randNum;
    }

    private void spikePunch()
    {
        //RandomNumber();
        if (RandomNumber() == attackNumber)
        {
            transform.Translate(Vector2.up * Time.deltaTime * speed);
        }
    }

  private void OnTriggerEnter(UnityEngine.Collider other)
    {
        Destroy(gameObject);
        Destroy(other.gameObject);
    }


}