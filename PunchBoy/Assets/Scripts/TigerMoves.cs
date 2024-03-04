using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SpikeRowMove;
using static DestroyOutOfBounds;
using static DetectCollisions;
using static PlayerCollision;
using static PlayerHealth;


public class TigerMoves : MonoBehaviour
{
    public GameObject spikeRow;
    public SpikeRowMove spikeRowMove;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        callSpikePunch();
    }

    public void callSpikePunch()
    {

    }
}
