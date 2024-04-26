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
    private float fireCooldown = 1.0f;
    private float moveCooldown = 0.0f;
    private float attackCooldown = 0.0f;

    public AudioSource fireAudio;
    public AudioSource sweepAudio;
    public AudioSource punchAudio;

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
            animator.SetTrigger("MoveUp");
            MovePlayer(Vector3.forward);
            xPOS++;
            moveCooldown = .3f;
        }

        if (Input.GetKeyDown(KeyCode.A) && yPOS > 0 && moveCooldown <= 0)
        {
            animator.SetTrigger("MoveLeft");
            MovePlayer(Vector3.left);
            yPOS--;
            moveCooldown = .3f;
        }

        if (Input.GetKeyDown(KeyCode.S) && xPOS > 0 && moveCooldown <= 0)
        {
            animator.SetTrigger("MoveDown");
            MovePlayer(Vector3.back);
            xPOS--;
            moveCooldown = .3f;
        }

        if (Input.GetKeyDown(KeyCode.D) && yPOS < 3 && moveCooldown <= 0)
        {
            animator.SetTrigger("MoveRight");
            MovePlayer(Vector3.right);
            yPOS++;
            moveCooldown = .3f;
        }

        if (moveCooldown <= .05f)
        {
            animator.ResetTrigger("MoveUp");
            animator.ResetTrigger("MoveDown");
            animator.ResetTrigger("MoveRight");
            animator.ResetTrigger("MoveDown");
        }

        if (moveCooldown > 0)
        {
            moveCooldown -= Time.deltaTime;
        }

        if (attackCooldown > 0)
        {
            attackCooldown -= Time.deltaTime;
        }

        if (attackCooldown <= 0) {
            animator.ResetTrigger("punch");
            animator.ResetTrigger("firePunch");
        }

        //Basic punch skill
        if (Input.GetKeyDown(KeyCode.J) && basicCooldown >= 1.0f && attackCooldown <= 0)
        {
            animator.SetTrigger("Punch");
            basicCooldown = 0;
            punchAudio.Play();
            Instantiate(basicPunchPrefab, transform.position, basicPunchPrefab.transform.rotation);
            attackCooldown = 0.5f;
        }

        //Sweep skill
        if (Input.GetKeyDown(KeyCode.K) && sweepCooldown >= 5.0f && attackCooldown <= 0)
        {
            animator.SetTrigger("Sweep");
            sweepCooldown = 0;
            sweepAudio.Play();
            StartCoroutine(SweepRoutine());
            attackCooldown = 0.5f;
        }

        //Fire punch skill
        if (Input.GetKeyDown(KeyCode.L) && fireCooldown >= 1.0f && attackCooldown <= 0)
        {
            animator.SetTrigger("FirePunch");
            fireCooldown = 0;
            Instantiate(fireFistPrefab, transform.position, fireFistPrefab.transform.rotation);
            fireAudio.Play();
            attackCooldown = 0.5f;
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

        if (fireCooldown <= 1.0f)
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
        fireIcon.fillAmount = fireCooldown / 1.0f;
    }
}