using UnityEngine;
using System.Collections;

public class Tronconneuse : Interractable
{
    [SerializeField]
    TexteController txtController;
    string death_dial = "exemple_de_cle";

    public override void Interract()
    {
    }

    void OnTriggerEnter2D()
    {
        Debug.Log("piece sombre");
        this.gameObject.SetActive(false);
        /*
        txtController.StartDialogue(death_dial, TexteController.DialogueType.DIE, Player.Death.noyadeActive);
        SoundManager.PlayBruitage(SoundManager.Bruitages.NOYADE);
        player.Kill(Player.Death.noyadeActive);
        player.AddPower(Player.Power.canalisation);*/
    }
}
