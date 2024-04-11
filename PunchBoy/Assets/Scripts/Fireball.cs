using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    private float speed = 15.0f;
    Vector3 punchBoyPosition;
    private Animator animator;
    public GameObject dispersePrefab;

    // Start is called before the first frame update
    void Start()
    {
        punchBoyPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x >= punchBoyPosition.x + 2.5f)
        {
            Destroy(gameObject);
            Instantiate(dispersePrefab, transform.position, dispersePrefab.transform.rotation);
        }

        else
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed);
            transform.Translate(Vector3.up * Time.deltaTime * (speed * 0.66f));
        }
    }
}
