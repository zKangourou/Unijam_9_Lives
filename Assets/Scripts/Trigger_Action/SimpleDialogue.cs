using UnityEngine;
using System.Collections;

public class SimpleDialogue : Interractable
{
    [SerializeField] TexteController textController;
    [SerializeField] string textKey;

    public override void Interract()
    {
        textController.StartDialogue(textKey,TexteController.DialogueType.NOTHING);
    }

    public void DoNothing()
    {
        return;
    }
}
