using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public AudioSource buttonHit;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Begin()
    {
        buttonHit.Play();
        StartCoroutine(GameStart());
    }

    IEnumerator GameStart() {
        yield return new WaitForSeconds(.2f);
        SceneManager.LoadScene("perspective");
    }
}
