using UnityEngine;
using System.Collections;

public class Barbecue : Interractable {
    [SerializeField]
    TexteController txtController;
    string isImmune_dial = "cat immune";
    string death_dial = "no immune, cat killed!";

    public void Death_Screen() { Debug.Log("ecran de la mort"); }

    public override void Interract()
    {
        if (player.IsImmune(Player.Death.barbecue))
        {
            txtController.StartDialogue(isImmune_dial, null);
        }
        else
        {
            txtController.StartDialogue(death_dial, Death_Screen);
        }
        //player.Kill(Player.Death.barbecue);
        player.AddPower(Player.Power.immuneFeu);
    }
}
