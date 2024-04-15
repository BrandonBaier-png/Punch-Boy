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
    public float fadeLength = 3f;
    public float fadingSpeed = 0.05f;
    public Color startColor;
    public Color endColor;


    // Start is called before the first frame update
    void Start()
    {

        anim = GetComponent<Animator>();
        rend = transform.GetChild(0).GetComponent<SpriteRenderer>();

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
        yield return ToRed();

        /*startFadeToRed();*/

        playAnimation();
        yield return null;

    }

    IEnumerator ToRed()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
        rend.color = startColor;
        for (float i = 0f; i < fadeLength; i += fadingSpeed)
        {
            rend.color = Color.Lerp(startColor, endColor, i / fadeLength);

            yield return new WaitForSeconds(fadingSpeed);
        }
        Color c = rend.color;
        c.a = 0;
        rend.color = c;
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        yield return null;  
    }

    public void startFadeToRed()
    {
        StartCoroutine(ToRed());
    }

}
