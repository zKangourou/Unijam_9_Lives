﻿using UnityEngine;
using System.Collections;

public class Interractable : MonoBehaviour {
    protected Player player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    public virtual void Interract()
    {

    }
}