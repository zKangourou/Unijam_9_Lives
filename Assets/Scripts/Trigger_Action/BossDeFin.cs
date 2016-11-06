using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BossDeFin : Interractable
{
    [SerializeField]
    TexteController txtController;
    [SerializeField]
    string passive_death;
    [SerializeField]
    string active_death;

    void Start()
    {
    }

    public override void Interract()
    {
    }

    void OnTriggerEnter2D()
    {
        if (player.EndChoice())
        {
            Debug.Log("blo");
            txtController.StartDialogue(active_death, TexteController.DialogueType.NOTHING);
        }
        else
        {
            Debug.Log("bla");
            txtController.StartDialogue(passive_death, TexteController.DialogueType.NOTHING);
        }
        //SoundManager.PlayBruitage(SoundManager.Bruitages.NOYADE);
    }
}
