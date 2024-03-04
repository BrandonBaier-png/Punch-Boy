using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    private int currentTextNum = 0;
    public Dialogue dialogue;


    public void Start()
    {
        if (dialogue.orderNum == 0)
        {
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        }
    }
    public void TriggerDialogue()
    {

        

    }

    public void StartDialogue(Dialogue dialogue)
    {

        if (dialogue.orderNum == currentTextNum)
        {
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        }
    }

    public void nextDialogue(Dialogue dialogue)
    {

        currentTextNum += 1;
        //Debug.Log("End of conversation within DialogueTrack");
        if (dialogue.orderNum == currentTextNum)
        {
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        }
        //Debug.Log("End of conversation");

    }
}
