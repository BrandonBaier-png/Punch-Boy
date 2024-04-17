using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*heirarchy:
 * attack
 * -gets squares through the grid, then tells it what actions to do and when
 * grid
 * -returns a square corresponding to a coordinate
 * square
 * -just kinda there
 */
public class SpikeBehavior : MonoBehaviour
{
    public Animator anim;

    SpriteRenderer rend;
    BoxCollider hitBox;
    public float fadeLength = 3f;
    public float fadingSpeed = 0.05f;
    public Color startColor;
    public Color endColor;


    // Start is called before the first frame update
    void Start()
    {

        anim = GetComponent<Animator>();
        rend = transform.GetChild(0).GetComponent<SpriteRenderer>();
        hitBox = transform.GetChild(0).GetComponent<BoxCollider>();




        /* startFadeToRed();*/


        /*        StartCoroutine(DeploySpike());*/
    }

    // Update is called once per frame
    void Update()
    {

    }

   public void playAnimation()
    {
        anim.enabled = true;
        anim.Play("Spunch row", 0, 0);
    }

    public IEnumerator DeploySpike()
    {
      
        yield return StartCoroutine(ToRed());
      

        hitBox.enabled = true;

        /*startFadeToRed();*/

        playAnimation();

        yield return new WaitForSeconds(.95f);
        hitBox.enabled = false;
        yield return null;

    }

    IEnumerator ToRed()
    {
        rend.enabled = true;

        rend.color = startColor;
        for (float i = 0f; i < fadeLength; i += fadingSpeed)
        {
            rend.color = Color.Lerp(startColor, endColor, i / fadeLength);

            yield return new WaitForSeconds(fadingSpeed);
        }
        Color c = rend.color;
        c.a = 0;
        rend.color = c;
        rend.enabled = false;
        yield return null;  
    }

    public void startFadeToRed()
    {
        StartCoroutine(ToRed());
    }

}
