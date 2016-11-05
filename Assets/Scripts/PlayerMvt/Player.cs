﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour
{
    private int life;
    private GameObject trigger;
    private bool action, death_barbecue;
    private List<bool> death_list = new List<bool>();
    //private List<Transform> myList = new List<Transform>();
    //private Dictionary<Deaths, List<Transform>> myDeath;

    void Start()
    {
        life = 9;
        death_barbecue = false;
        death_list.Add(death_barbecue);
    }

    void Update()
    {
        action = Input.GetButtonDown("Action");
    }

    private void LoseOneLife()
    {
        if (this.life != 0)
        {
            Debug.Log("Lose one life");
            this.life -= 1;
        }
    }

    public void Die()
    {
        LoseOneLife();
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        trigger = coll.gameObject;
        Debug.Log("objet collidé " + trigger.tag);
        /*
        if (barbecue)
        {
            Debug.Log("Le chat brûle et gagne un pouvoir !");
            LoseOneLife();
            death_barbecue = true;
        }*/
    }


}
