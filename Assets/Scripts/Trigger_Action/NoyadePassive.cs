using UnityEngine;
using System.Collections;

public class NoyadePassive : Interractable
{
    [SerializeField]
    TexteController txtController;
    string death_dial = "mort_par_baignoire";

    public override void Interract()
    {
    }

    void OnTriggerEnter2D(Collider2D val)
    {
        if (val.tag =="Player" && !player.IsImmune(Player.Death.noyadePassive))
        {
            txtController.StartDialogue(death_dial, TexteController.DialogueType.DIE, Player.Death.noyadePassive);
            SoundManager.PlayBruitage(SoundManager.Bruitages.NOYADE);
            player.Kill(Player.Death.noyadePassive);
            player.AddPower(Player.Power.immuneNoyade);
        }
    }
}
