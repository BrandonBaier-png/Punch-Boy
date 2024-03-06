using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class Dialogue {


    public enum Characters
    {
        PunchBoy,
        NewKing
    }
    public Characters currentCharacter;
    public Dictionary<string, string> characterInfo = new Dictionary<string, string>();

    void dialogueInfo()
    {
        switch(currentCharacter)
        {
            case Characters.PunchBoy:
                Debug.Log("Punch Boy Called");
                break;

            case Characters.NewKing:
                Debug.Log("New King Called");
                break;
        }
    }
    
    
    public string name;
    public int orderNum;
    [TextArea(3, 10)]
    public string[] sentences;
    // speed of the text
   
}
