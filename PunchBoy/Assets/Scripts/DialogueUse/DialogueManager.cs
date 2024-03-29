using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;




public class DialogueManager : MonoBehaviour
{
    public DialogueTrigger dialogueTrigger;

    public Text nameText;
    public Text dialogueText;

    private Queue<string> sentences;
    // Start is called before the first frame update

    void Start()
    {
        sentences = new Queue<string>();
    }
    public void StartDialogue(Dialogue dialogue)
    {

        //this would be a good place to initialize the profile images
        nameText.text = dialogue.name;
        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        
        DisplayNextSentence();

    }
    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;
    }
    public void EndDialogue()
    {

        Debug.Log("End of conversation in DialogueManager");
        //dialogueTrigger.nextDialogue();
    }

}
