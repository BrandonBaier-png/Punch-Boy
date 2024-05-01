using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class restartGameButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void restart() {
        GameObject.Find("SoundEffect").GetComponent<AudioSource>().Play();
        StartCoroutine(RestartButton());
    }
    IEnumerator RestartButton() {
        yield return new WaitForSeconds(.2f);
        SceneManager.LoadScene("perspective");
    }
}
