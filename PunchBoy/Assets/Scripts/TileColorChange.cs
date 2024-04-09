using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileColorChange : MonoBehaviour
{
    SpriteRenderer rend;
    public float fadeLength = 3f;
    public float fadingSpeed = 0.05f;
    public Color startColor;
    public Color endColor;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();

        startFadeToRed();
    }

    IEnumerator ToRed() {
        rend.color = startColor;
        for (float i = 0f; i < fadeLength; i += fadingSpeed)
        {
            rend.color = Color.Lerp(startColor, endColor, i / fadeLength);
       
            yield return new WaitForSeconds(fadingSpeed);
        }
    }

    public void startFadeToRed() {
        StartCoroutine("ToRed");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
