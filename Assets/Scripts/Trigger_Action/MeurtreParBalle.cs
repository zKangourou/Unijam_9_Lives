using UnityEngine;
using System.Collections;

public class MeurtreParBalle : Interractable
{
    [SerializeField]
    TexteController txtController;
    [SerializeField]
    SpriteRenderer sprite;
    string death_dial = "mort_par_lazer";

    public override void Interract()
    {
        /*
        if (player.IsImmune(Player.Death.meurtreParBalle))
        {
            txtController.StartDialogue(isImmune_dial, TexteController.DialogueType.NOTHING);
        }
        else
        {
            txtController.StartDialogue(death_dial, TexteController.DialogueType.DIE, Player.Death.meurtreParBalle);
        }
        player.AddPower(Player.Power.immuneBalle);*/
    }

    void OnTriggerEnter2D()
    {
        if (!done)
        {
            player.isTalking = true;
            player.Kill(Player.Death.meurtreParBalle);
            player.AddPower(Player.Power.tireDesBalles);
            done = true;
            SoundBalles();
        }
    }
    private void SoundBalles()
    {
        SoundManager.PlayBruitage(SoundManager.Bruitages.LAZER);
        txtController.StartDialogue(death_dial, TexteController.DialogueType.DIE, Player.Death.meurtreParBalle);
    }
}
