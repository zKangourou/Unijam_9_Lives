using UnityEngine;
using System.Collections;

public class GivrePassive : Interractable
{
    [SerializeField]
    TexteController txtController;
    string death_dial = "exemple_de_cle";

    public override void Interract()
    {
        if (!done)
        {
            txtController.StartDialogue(death_dial, TexteController.DialogueType.DIE, Player.Death.givrePassive);
            player.AddPower(Player.Power.patinoire);
            done = true;
        }
    }
}
