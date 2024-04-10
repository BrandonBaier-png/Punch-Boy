using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.InputSystem;
using Unity.VisualScripting;
using static InputScript;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour, IMovementActions
{
    private int xPOS = 0;
    private int yPOS = 0;
    public Transform movePoint;
    public GameObject fireFistPrefab;
    public GameObject basicPunchPrefab;
    public GameObject sweepPrefab;

    Vector3 left;
    Vector3 right;

    private float basicCooldown = 0.0f;
    private float sweepCooldown = 0.0f;
    private float fireCooldown = 0.0f;
    private float moveCooldown = 0.0f;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        left = new Vector3(transform.position.x - 1, transform.position.y, transform.position.z);
        right = new Vector3(transform.position.x + 1, transform.position.y, transform.position.z);

        if (Input.GetKeyDown(KeyCode.Q))
        {
            SceneManager.LoadScene("GameOver");
        }

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
        if (Input.GetKeyDown(KeyCode.J) && basicCooldown <= 0 && moveCooldown <= 0)
        {
            basicCooldown = 1.0f;
            Instantiate(basicPunchPrefab, transform.position, basicPunchPrefab.transform.rotation);
            moveCooldown = .3f;
        }

        //Sweep skill
        if (Input.GetKeyDown(KeyCode.K) && sweepCooldown <= 0 && moveCooldown <= 0)
        {
            sweepCooldown = 5.0f;
            StartCoroutine(SweepRoutine());
            moveCooldown = .3f;
        }

        //Fire punch skill
        if (Input.GetKeyDown(KeyCode.L) && fireCooldown <= 0 && moveCooldown <= 0)
        {
            fireCooldown = 5.0f;
            Instantiate(fireFistPrefab, transform.position, fireFistPrefab.transform.rotation);
            moveCooldown = .3f;
        }

        if (basicCooldown > 0)
        {
            basicCooldown = basicCooldown - Time.deltaTime;
        }

        if (sweepCooldown > 0)
        {
            sweepCooldown = sweepCooldown - Time.deltaTime;
        }

        if (fireCooldown > 0)
        {
            fireCooldown = fireCooldown - Time.deltaTime;
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

    IEnumerator SweepRoutine()
    {
        Instantiate(sweepPrefab, left, sweepPrefab.transform.rotation);
        yield return new WaitForSeconds(.08f);

        Instantiate(sweepPrefab, transform.position, sweepPrefab.transform.rotation);
        yield return new WaitForSeconds(.08f);

        Instantiate(sweepPrefab, right, sweepPrefab.transform.rotation);
        yield return new WaitForSeconds(.08f);
    }

}

