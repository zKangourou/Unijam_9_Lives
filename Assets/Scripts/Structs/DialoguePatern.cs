using UnityEngine;
using System.Collections;

public class DialoguePatern
{
    public string key;
    public string text;

    public DialoguePatern()
    {
        key = "";
        text = "";
    }

    public DialoguePatern(string keyIn,string textIn)
    {
        key = keyIn;
        text = textIn;
    }
}
