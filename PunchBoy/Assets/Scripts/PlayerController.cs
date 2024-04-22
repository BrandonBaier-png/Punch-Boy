using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Unity.VisualScripting;
using static InputScript;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour, IMovementActions
{
    private int xPOS = 0;
    private int yPOS = 0;
    public Transform movePoint;
    public GameObject fireFistPrefab;
    public GameObject basicPunchPrefab;
    public GameObject sweepPrefab;
    public Animator animator;

    public Image punchIcon;
    public Image sweepIcon;
    public Image fireIcon;

    Vector3 left;
    Vector3 right;

    private float basicCooldown = 1.0f;
    private float sweepCooldown = 5.0f;
    private float fireCooldown = 5.0f;
    private float moveCooldown = 0.0f;

    public AudioSource source;
    public AudioClip punchAudio;
    public AudioClip sweepAudio;
    public AudioClip fireAudio;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        left = new Vector3(transform.position.x - 1, transform.position.y, transform.position.z);
        right = new Vector3(transform.position.x + 1, transform.position.y, transform.position.z);

        if (GameObject.Find("punchBoy") == null)
        {
            SceneManager.LoadScene("GameOver");
        }

        if (Input.GetKeyDown(KeyCode.W) && xPOS < 3 && moveCooldown <= 0)
        {
            animator.SetBool("moveUpBool", true);
            MovePlayer(Vector3.forward);
            xPOS++;
            moveCooldown = .3f;
        }

        if (Input.GetKeyDown(KeyCode.A) && yPOS > 0 && moveCooldown <= 0)
        {
            animator.SetBool("moveLeftBool", true);
            MovePlayer(Vector3.left);
            yPOS--;
            moveCooldown = .3f;
        }

        if (Input.GetKeyDown(KeyCode.S) && xPOS > 0 && moveCooldown <= 0)
        {
            animator.SetBool("moveDownBool", true);
            MovePlayer(Vector3.back);
            xPOS--;
            moveCooldown = .3f;
        }

        if (Input.GetKeyDown(KeyCode.D) && yPOS < 3 && moveCooldown <= 0)
        {
            animator.SetBool("moveRightBool", true);
            MovePlayer(Vector3.right);
            yPOS++;
            moveCooldown = .3f;
        }

        if (moveCooldown <= .05f)
        {
            animator.SetBool("moveRightBool", false);
            animator.SetBool("moveLeftBool", false);
            animator.SetBool("moveDownBool", false);
            animator.SetBool("moveUpBool", false);
        }

        if (moveCooldown > 0)
        {
            moveCooldown -= Time.deltaTime;
        }

        //Basic punch skill
        if (Input.GetKeyDown(KeyCode.J) && basicCooldown >= 1.0f && moveCooldown <= 0)
        {
            basicCooldown = 0;
            Instantiate(basicPunchPrefab, transform.position, basicPunchPrefab.transform.rotation);
        }

        //Sweep skill
        if (Input.GetKeyDown(KeyCode.K) && sweepCooldown >= 5.0f && moveCooldown <= 0)
        {
            sweepCooldown = 0;
            StartCoroutine(SweepRoutine());
        }

        //Fire punch skill
        if (Input.GetKeyDown(KeyCode.L) && fireCooldown >= 5.0f && moveCooldown <= 0)
        {
            fireCooldown = 0;
            Instantiate(fireFistPrefab, transform.position, fireFistPrefab.transform.rotation);
        }

        if (basicCooldown <= 1.0f)
        {
            basicCooldown += Time.deltaTime;
            UpdatePunch();
        }

        if (sweepCooldown <= 5.0f)
        {
            sweepCooldown += Time.deltaTime;
            UpdateSweep();
        }

        if (fireCooldown <= 5.0f)
        {
            fireCooldown += Time.deltaTime;
            UpdateFire();
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

    public void UpdatePunch()
    {
        punchIcon.fillAmount = basicCooldown / 1.0f;
    }

    public void UpdateSweep()
    {
        sweepIcon.fillAmount = sweepCooldown / 5.0f;
    }

    public void UpdateFire()
    {
        fireIcon.fillAmount = fireCooldown / 5.0f;
    }
}