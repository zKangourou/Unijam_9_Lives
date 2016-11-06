using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BossDeFin : Interractable
{
    [SerializeField]
    TexteController txtController;
    
    public override void Interract()
    {
    }

    void OnTriggerEnter2D()
    {
        if (player.EndChoice())
        {
            txtController.StartDialogue("boss_enerve", TexteController.DialogueType.NOTHING);
        }
        else
        {
            txtController.StartDialogue("boss_joyeux", TexteController.DialogueType.NOTHING);
        }
        //SoundManager.PlayBruitage(SoundManager.Bruitages.NOYADE);
    }
}
