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

    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
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
        yield return new WaitForSeconds(2);
        playAnimation();
        yield return null;
    }

}
