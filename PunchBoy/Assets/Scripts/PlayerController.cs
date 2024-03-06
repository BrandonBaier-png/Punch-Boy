using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.InputSystem;
using Unity.VisualScripting;
using static InputScript;

public class PlayerController : MonoBehaviour, IMovementActions
{
    private int xPOS = 0;
    private int yPOS = 0;
    public Transform movePoint;
    public GameObject fireFistPrefab;
    public GameObject basicPunchPrefab;

    private bool isCountering = false;
    private float counterDuration = 0.0f;
    private float basicCooldown = 0.0f;
    private float counterCooldown = 0.0f;
    private float fireCooldown = 0.0f;
    private float moveCooldown = 0.0f;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.W) && xPOS < 3 && moveCooldown <= 0)
        {
            MovePlayer(Vector3.forward);
            xPOS++;
            moveCooldown = .3f;
        }

        if (Input.GetKeyDown(KeyCode.A) && yPOS > 0 && moveCooldown <= 0)
        {
            MovePlayer(Vector3.left);
            yPOS--;
            moveCooldown = .3f;
        }

        if (Input.GetKeyDown(KeyCode.S) && xPOS > 0 && moveCooldown <= 0)
        {
            MovePlayer(Vector3.back);
            xPOS--;
            moveCooldown = .3f;
        }

        if (Input.GetKeyDown(KeyCode.D) && yPOS < 3 && moveCooldown <= 0)
        {
            MovePlayer(Vector3.right);
            yPOS++;
            moveCooldown = .3f;
        }

        if (moveCooldown > 0)
        {
            moveCooldown -= Time.deltaTime;
        }

        //Basic punch skill
        if (Input.GetKeyDown(KeyCode.J) && basicCooldown <= 0)
        {
            basicCooldown = 1.0f;
            Instantiate(basicPunchPrefab, transform.position, basicPunchPrefab.transform.rotation);
        }

        //Counter skill
        if (Input.GetKeyDown(KeyCode.K) && counterCooldown <= 0)
        {
            counterDuration = 2.0f;
            if (counterDuration > 0)
            {
                isCountering = true;
            }

            counterCooldown = 4.0f;
        }

        //Fire punch skill
        if (Input.GetKeyDown(KeyCode.L) && fireCooldown <= 0)
        {
            fireCooldown = 5.0f;
            Instantiate(fireFistPrefab, transform.position, fireFistPrefab.transform.rotation);
        }

        if (basicCooldown > 0)
        {
            basicCooldown = basicCooldown - Time.deltaTime;
        }

        if (counterCooldown > 0)
        {
            counterCooldown = counterCooldown - Time.deltaTime;
        }

        if (fireCooldown > 0)
        {
            fireCooldown = fireCooldown - Time.deltaTime;

        }

        if (counterDuration > 0)
        {
            counterDuration = fireCooldown - Time.deltaTime;
        }

    }

    private void MovePlayer(Vector3 direction)
    {
        transform.position += (direction * 1);
    }

    public void OnPlayerMove(InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }

}
