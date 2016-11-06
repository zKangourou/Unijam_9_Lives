using UnityEngine;
using System.Collections;

public class NoyadeActive : Interractable
{
    [SerializeField]
    TexteController txtController;
    string death_dial = "mort_par_noyade";

    public override void Interract()
    {
    }
    void OnTriggerEnter2D(Collider2D val)
    {
			if (val.tag == "Player" && !player.power_list.Contains(Player.Power.canalisation))
        {
            txtController.StartDialogue(death_dial, TexteController.DialogueType.DIE, Player.Death.noyadeActive);
            SoundManager.PlayBruitage(SoundManager.Bruitages.NOYADE);
            player.Kill(Player.Death.noyadeActive);
            player.AddPower(Player.Power.canalisation);
        }
    }
}
