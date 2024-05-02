using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButton : MonoBehaviour
{
    public AudioSource buttonAudio;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Menu() {
        buttonAudio.Play();
        StartCoroutine(MenuButton());
    }

    IEnumerator MenuButton() { 
        yield return new WaitForSeconds(.2f);
        SceneManager.LoadScene("StartScreen");
    }
}
