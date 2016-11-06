﻿using UnityEngine;
using System.Collections;

public class Porte : Interractable
{

    public override void Interract()
    {
        if (player.power_list.Contains(Player.Power.passeSousLesPortes))
        {
            GameObject.FindGameObjectWithTag("Player").transform.position = transform.position + Mathf.Sign((transform.position - GameObject.FindGameObjectWithTag("Player").transform.position).x) * new Vector3(2,0,0);
            GameObject.FindGameObjectWithTag("Indicator").GetComponent<IndicatorManager>().HideHelp();
        }
    }

    void OnTriggerEnter2D()
    {
        if (player.power_list.Contains(Player.Power.passeSousLesPortes))
        {
            GameObject.FindGameObjectWithTag("Indicator").GetComponent<IndicatorManager>().ShowHelp();
        }
    }
    void OnTriggerExit2D()
    {
        GameObject.FindGameObjectWithTag("Indicator").GetComponent<IndicatorManager>().HideHelp();
    }
}
