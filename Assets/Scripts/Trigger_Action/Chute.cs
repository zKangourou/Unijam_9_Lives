using UnityEngine;
using System.Collections;

public class Chute : Interractable
{
    [SerializeField]
    TexteController txtController;
    string death_dial = "mort_par_chute";

    public override void Interract()
    {
    }

    void OnTriggerEnter2D()
    {
        if (!player.IsImmune(Player.Death.chute))
        {
            txtController.StartDialogue(death_dial, TexteController.DialogueType.DIE, Player.Death.chute);
            player.Kill(Player.Death.chute);
            player.AddPower(Player.Power.immuneChute);
        }
    }
}
