using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BossDeFin : Interractable
{
    [SerializeField]
    TexteController txtController;
    [SerializeField]
    EndSceneController endSceneController;
    string txt;

    public override void Interract()
    {
    }

    void OnTriggerEnter2D()
    {
        if (player.EndChoice())
        {
            txtController.StartDialogue("boss_enerve", TexteController.DialogueType.BOSS);
            txt = "KUKUKU THE CAT IS DEAD (FOR REAL)";
        }
        else
        {
            txtController.StartDialogue("boss_joyeux", TexteController.DialogueType.BOSS);
            txt = "HAHAHAHAH LES CHATS REIGNERONT SUR L'UNIVERS";
        }
        endSceneController.SetText(txt);
        //SoundManager.PlayBruitage(SoundManager.Bruitages.NOYADE);
    }
}
