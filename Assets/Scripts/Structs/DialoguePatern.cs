using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DialoguePatern
{
    public string key;
    public List<DialogueElementPatern> elements;

    public DialoguePatern()
    {
        key = "";
        elements = new List<DialogueElementPatern>();
    }

    public DialoguePatern(string keyIn,List<DialogueElementPatern> elementsIn)
    {
        key = keyIn;
        elements = elementsIn;
    }
}
