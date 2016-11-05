using UnityEngine;
using System.Collections;

public class NoyadeActive : Interractable
{
    [SerializeField]
    TexteController txtController;
    string isImmune_dial = "cat immune";
    string death_dial = "exemple_de_cle";

    public override void Interract()
    {
        if (player.IsImmune(Player.Death.noyadeActive))
        {
            txtController.StartDialogue(isImmune_dial, TexteController.DialogueType.NOTHING);
        }
        else
        {
            txtController.StartDialogue(death_dial, TexteController.DialogueType.DIE, Player.Death.noyadeActive);
        }
        player.AddPower(Player.Power.canalisation);
    }
}
