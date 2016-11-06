using UnityEngine;
using System.Collections;

public class Hachoir : Interractable
{
    [SerializeField]
    TexteController txtController;
    string death_dial = "mort_par_hachoir";
    string isImmune_dial = "hachoir_again";

    public override void Interract()
    {
        if (!done)
        {
            txtController.StartDialogue(death_dial, TexteController.DialogueType.DIE, Player.Death.hachoir);
            player.AddPower(Player.Power.hachis);
            done = true;
            SoundManager.PlayBruitage(SoundManager.Bruitages.HACHOIR);
        }
        else
        {
            txtController.StartDialogue(isImmune_dial, TexteController.DialogueType.NOTHING);
        }
        GameObject.FindGameObjectWithTag("Indicator").GetComponent<IndicatorManager>().HideHelp();
    }

    void OnTriggerEnter2D(Collider2D val)
    {
        if (val.tag == "Player")
        {
            GameObject.FindGameObjectWithTag("Indicator").GetComponent<IndicatorManager>().ShowHelp();
        }
    }
    void OnTriggerExit2D()
    {
        GameObject.FindGameObjectWithTag("Indicator").GetComponent<IndicatorManager>().HideHelp();
    }
}
