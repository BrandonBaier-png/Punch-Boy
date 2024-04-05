using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TigerSwipe : MonoBehaviour
{
    Vector3 spawnPos;

    public GameObject Wave1Prefab;
    public GameObject Wave2Prefab;
    public GameObject Wave3Prefab;
    public GameObject Wave4Prefab;
    private bool activeAttack = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            StartCoroutine(SwipeAttackRoutine());
        }

        if (activeAttack)
        {
            //print("SUPERSPUNCH ACTIVE");
            StartCoroutine(SwipeAttackRoutine());
        }
    }
    

    IEnumerator SwipeAttackRoutine()
    {
        spawnPos = new Vector3(0, .5f, 3);

        yield return new WaitForSeconds(1);

        Instantiate(Wave1Prefab, spawnPos, Wave1Prefab.transform.rotation);
        yield return new WaitForSeconds(.05f);
        spawnPos[0] = spawnPos[0] + 1;
        spawnPos[2] = spawnPos[2] - .5f;

        Instantiate(Wave2Prefab, spawnPos, Wave2Prefab.transform.rotation);
        yield return new WaitForSeconds(.05f);
        spawnPos[0] = spawnPos[0] + 1;
        spawnPos[2] = spawnPos[2] - .5f;

        Instantiate(Wave3Prefab, spawnPos, Wave3Prefab.transform.rotation);
        yield return new WaitForSeconds(.05f);
        spawnPos[0] = spawnPos[0] + 1;
        spawnPos[2] = spawnPos[2] - .5f;

        Instantiate(Wave4Prefab, spawnPos, Wave4Prefab.transform.rotation);
        yield return new WaitForSeconds(.05f);
        spawnPos[0] = 3;
        spawnPos[2] = 3;

        yield return new WaitForSeconds(.75f);

        Instantiate(Wave1Prefab, spawnPos, Wave1Prefab.transform.rotation);
        yield return new WaitForSeconds(.05f);
        spawnPos[0] = spawnPos[0] - 1;
        spawnPos[2] = spawnPos[2] - .5f;

        Instantiate(Wave2Prefab, spawnPos, Wave2Prefab.transform.rotation);
        yield return new WaitForSeconds(.05f);
        spawnPos[0] = spawnPos[0] - 1;
        spawnPos[2] = spawnPos[2] - .5f;

        Instantiate(Wave3Prefab, spawnPos, Wave3Prefab.transform.rotation);
        yield return new WaitForSeconds(.05f);
        spawnPos[0] = spawnPos[0] - 1;
        spawnPos[2] = spawnPos[2] - .5f;

        Instantiate(Wave4Prefab, spawnPos, Wave4Prefab.transform.rotation);
        yield return new WaitForSeconds(.05f);
        spawnPos[0] = spawnPos[0] - 1;
        spawnPos[2] = spawnPos[2] - .5f;

        activeAttack = false;
    }

    void TestEnableAttack()
    {
        Instantiate(Wave4Prefab, spawnPos, Wave4Prefab.transform.rotation);
        activeAttack = true;
    }
}
