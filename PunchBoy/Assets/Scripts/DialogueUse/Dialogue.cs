using OpenCover.Framework.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class Dialogue {


    public enum Characters {PunchBoy, NewKing};

    public Characters currentCharacter;
    //public Dictionary<string, string> characterText = new Dictionary<string, string>();
    public Dictionary<int, string> characterText = new();
    

    void Start()
    {

    }


    void dialogueInfo()
    {

        switch (currentCharacter)
        {
            case Characters.PunchBoy:
                name = "Punch Boy";
                break;

            case Characters.NewKing:
                name = "New King";
                break;
        }
    }


    
    string punchBoy1()
    {
        currentCharacter = Characters.PunchBoy;
        return "done";
    }
    
    public string name;
    public int orderNum;
    [TextArea(3, 10)]
    public string[] sentences;
    // speed of the text
   
}


