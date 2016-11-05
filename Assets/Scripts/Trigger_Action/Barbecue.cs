using UnityEngine;
using System.Collections;

public class Barbecue : Interractable {

    public override void Interract()
    {
        //TODO tester si immune au feu puis tuer le chat en fonction
        player.Kill(Player.Death.barbecue);
        player.AddPower(Player.Power.immuneFeu);
    }
}
