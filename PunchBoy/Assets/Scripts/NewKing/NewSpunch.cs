using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/* New Spunch
 * 
 * This code creates prefabs of hitboxes to test if punch boy is hit by the attacks.
 * Created via coroutine to wait for the attack to conclude
 * 
 * Author - Brandon Baier 
 */

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
        spawnPos = this.GetComponent<Rigidbody>().position;
        rowDistances[0] = 0;
        rowDistances[1] = 1;
        rowDistances[2] = 2;
        rowDistances[3] = 3;
       // spikeRow = GameObject.Find("SpikeRowWide");
    }
    public void Update()
    {
        if (activeAttack)
        {
            StartCoroutine(spawnSpikes(4, 1));
            CurrentAttack(false);
            print("SPUNCH SPIKES HERE");

        }
    }

    // Update is called once per frame
   

    public IEnumerator spawnSpikes(float numRows,  float waitTime)
    {
        
        //Vector3 newSpawnPos = ;
        int rowCount = 0;
        while (rowCount < numRows)
        {
            
            // rowCount is serving as a multipurpose tool here, might break if not careful
            Vector3 currentSpike = new Vector3(spawnPos.x, spawnPos.y, (spawnPos.z - rowCount));
            Instantiate(spikeRow, currentSpike, spikeRow.transform.rotation);
            yield return new WaitForSeconds(1);

            DestroyAllSpikes();
            rowCount++;
            yield return new WaitForSeconds(0.5f);
        }
        
        
    }

    private void DestroyAllSpikes()
    {
        GameObject[] activeSpikes = GameObject.FindGameObjectsWithTag("Spike");
        foreach (GameObject Spike in activeSpikes)
        {
            Destroy(Spike);
        }
        
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
