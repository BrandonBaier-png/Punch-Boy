using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewSpunch : MonoBehaviour
{
    public float speed = 10.0f;
    //private bool isHit = false;
    public GameObject spikeRow;
    public Vector3 spawnPos;
    bool activeAttack = false;
    
    private float[]rowDistances = new float[4];
    // Start is called before the first frame update
    void Start()
    {
        spikeRow = GameObject.Find("NewSpunchGameObject");
    }
    public void Update()
    {
        if (activeAttack)
        {
            print("SPUNCH SPIKES HERE");
            spawnSpikes(1);
            spawnSpikes(2);
            spawnSpikes(3);
            spawnSpikes(4);
            CurrentAttack(false);
        }
    }

    // Update is called once per frame
    public IEnumerator SpawnSpikeRow(float distance, float waitTime)
    {

        //spawnSpikes()
        yield return new WaitForSeconds(waitTime);
    }

    public void spawnSpikes(float rowDistance)
    {
        Vector3 currentSpike = new Vector3(spawnPos.x, spawnPos.y - rowDistance, spawnPos.z);
        //Vector3 newSpawnPos = ;
        Instantiate(spikeRow, spawnPos, spikeRow.transform.rotation);
    }

    public void CurrentAttack(bool value)
    {
        activeAttack = value;
    }
    public void EnableAttack()
    {
        activeAttack = true;
    }
}
