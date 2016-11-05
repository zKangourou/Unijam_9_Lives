using UnityEngine;
using System.Collections;

public class Voiture : Interractable
{
    [SerializeField]
    TexteController txtController;
    string death_dial = "exemple_de_cle";

    public override void Interract()
    {
        if (!done)
        {
            txtController.StartDialogue(death_dial, TexteController.DialogueType.DIE, Player.Death.voiture);
            player.AddPower(Player.Power.superman);
            done = true;
        }
    }
}
