using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PummelBehavior : MonoBehaviour
{
    public Animator anim;

    SpriteRenderer rend1;
    public float fadeLength = 3f;
    public float fadingSpeed = 0.05f;
    public Color startColor;
    public Color endColor;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rend1 = transform.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void playAnimation()
    {
        rend1.enabled = true;
        anim.enabled = true;
        anim.Play("Pummel2dObject", 0);
    }

    public IEnumerator DeployPummel()
    {
        // Seems like this code is causing issues / breaking it, not sure why

        /*startFadeToRed();*/

        playAnimation();

        yield return new WaitForSeconds(.95f);

        yield return null;

    }
}
