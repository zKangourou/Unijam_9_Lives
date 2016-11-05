using UnityEngine;
using System.Collections;

public class Barbecue : Interractable {

    public override void Interract()
    {
        //TODO tester si immune au feu puis tuer le chat en fonction
        player.DieorNot(Player.Death.barbecue, true);
    }
}
