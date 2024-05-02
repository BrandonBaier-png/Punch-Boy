using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PummelBehavior : MonoBehaviour
{
    public Animator anim;
    SpriteRenderer rend1;

    // Start is called before the first frame update
    void Start()
    {
        rend1 = transform.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void playAnimation()
    {
        rend1.enabled = true;
        anim.SetTrigger("PummelAttack");
/*        anim.enabled = true;
        anim.Play("Pummel2dPunch", 0);*/
    }

    public IEnumerator DeployPummel()
    {
        // Seems like this code is causing issues / breaking it, not sure why

        /*startFadeToRed();*/

        playAnimation();

        yield return new WaitForSeconds(.5f);

        rend1.enabled = false;
        
        yield return null;

    }
}
