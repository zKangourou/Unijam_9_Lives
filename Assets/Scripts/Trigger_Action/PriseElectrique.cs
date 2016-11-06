using UnityEngine;
using System.Collections;

public class PriseElectrique : Interractable
{
    [SerializeField]
    TexteController txtController;
    string death_dial = "mort_par_prise";
    string isImmune_dial = "prise_again";

    public override void Interract()
    {
        if (!done)
        {
            txtController.StartDialogue(death_dial, TexteController.DialogueType.DIE, Player.Death.priseElectrique);
            player.Kill(Player.Death.priseElectrique);
            player.AddPower(Player.Power.cableElectrique);
            done = true;
            SoundManager.PlayBruitage(SoundManager.Bruitages.PRISE);
        }
        else
        {
            txtController.StartDialogue(isImmune_dial, TexteController.DialogueType.NOTHING);
        }
        GameObject.FindGameObjectWithTag("Indicator").GetComponent<IndicatorManager>().HideHelp();
    }

    void OnTriggerEnter2D()
    {
        GameObject.FindGameObjectWithTag("Indicator").GetComponent<IndicatorManager>().ShowHelp();
        SoundManager.PlayBruitage(SoundManager.Bruitages.PROCHEPRISE);
    }
    void OnTriggerExit2D()
    {
        GameObject.FindGameObjectWithTag("Indicator").GetComponent<IndicatorManager>().HideHelp();
    }
}
