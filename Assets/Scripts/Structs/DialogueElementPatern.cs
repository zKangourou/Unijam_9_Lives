using UnityEngine;
using System.Collections;

public class DialogueElementPatern
{
    public string image;
    public string text;

    public DialogueElementPatern()
    {
        image = "";
        text = "";
    }

    public DialogueElementPatern(string imageIn,string textIn)
    {
        image = imageIn;
        text = textIn;
    }
}
