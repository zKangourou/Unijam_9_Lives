﻿using UnityEngine;
using System.Collections;

public class Barbecue : Interractable {

    public override void Interract()
    {
        player.Die();
    }
}