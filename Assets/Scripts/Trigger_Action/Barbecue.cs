using UnityEngine;
using System.Collections;
using System;

public class Barbecue : Interractable {
    [SerializeField]
    TexteController txtController;
    string isImmune_dial = "cat immune";
    string death_dial = "no immune, cat killed!";

    public override void Interract()
    {
        if (player.IsImmune(Player.Death.barbecue))
        {
            txtController.StartDialogue(isImmune_dial,TexteController.DialogueType.DIE,Player.Death.barbecue);
        }
        else
        {
            txtController.StartDialogue(death_dial, TexteController.DialogueType.NOTHING);
        }
        //player.Kill(Player.Death.barbecue);
        player.AddPower(Player.Power.immuneFeu);
    }
}
