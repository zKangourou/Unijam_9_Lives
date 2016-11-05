using UnityEngine;
using System.Collections;

public class Strangulation : Interractable
{
    [SerializeField]
    TexteController txtController;
    string death_dial = "exemple_de_cle";

    public override void Interract()
    {
        if (!done)
        {
            txtController.StartDialogue(death_dial, TexteController.DialogueType.DIE, Player.Death.strangulation);
            player.AddPower(Player.Power.catVador);
            done = true;
        }
    }
}
