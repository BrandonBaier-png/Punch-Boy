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
    private Animator anim;

    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
  /*      anim.Play("Spunch Row", 0, 0);*/
  
    }

   public void playAnimation(GameObject spike)
    {
        anim.Play("Spunch Row", 0, 0);
    }

}
