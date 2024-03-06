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
    private float tileMove = 1;
    public Transform movePoint;
    private float cooldown = 0f;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && xPOS < 3 && cooldown <= 0)
        {
            MovePlayer(Vector3.forward);
            xPOS++;
            cooldown = .3f;
        }

        if (Input.GetKeyDown(KeyCode.A) && yPOS > 0 && cooldown <= 0)
        {
            MovePlayer(Vector3.left);
            yPOS--;
            cooldown = .3f;
        }

        if (Input.GetKeyDown(KeyCode.S) && xPOS > 0 && cooldown <= 0)
        {
            MovePlayer(Vector3.back);
            xPOS--;
            cooldown = .3f;
        }

        if (Input.GetKeyDown(KeyCode.D) && yPOS < 3 && cooldown <= 0)
        {
            MovePlayer(Vector3.right);
            yPOS++;
            cooldown = .3f;

        }

        if (cooldown > 0)
        {
            cooldown -= Time.deltaTime;
        }

    }

    private void MovePlayer(Vector3 direction)
    {
        transform.position += (direction * tileMove);
        //transform.Translate(direction * tileMove * Time.deltaTime);
    }

    public void OnPlayerMove(InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }
}
