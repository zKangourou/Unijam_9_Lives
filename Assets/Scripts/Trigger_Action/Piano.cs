using UnityEngine;
using System.Collections;

public class Piano : Interractable
{
    [SerializeField]
    TexteController txtController;
    string death_dial = "exemple_de_cle";

    public override void Interract()
    {
        if (!done)
        {
            txtController.StartDialogue(death_dial, TexteController.DialogueType.DIE, Player.Death.piano);
            player.AddPower(Player.Power.passeSousLesPortes);
            done = true;
        }
    }
}
