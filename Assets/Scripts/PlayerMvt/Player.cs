﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour
{
    Vector3 initPos;

    private int life;
    private GameObject trigger;
    private bool action;
    private List<Death> death_list = new List<Death>();
    [HideInInspector]
    public List<Power> power_list = new List<Power>();
    public bool isTalking;
    [SerializeField]
    private SpellBar spellBar;

    public enum Death {
        chute,
        noyadePassive, noyadeActive,
        tazer, priseElectrique,
        strangulation, pendaison,
        barbecue, lanceFlamme,
        voiture, piano,
        tronconneuse, hachoir,
        suicideParBalle, meurtreParBalle,
        givrePassive, givreActive
    }
    public enum Power {
        noPower, immuneChute,
        canalisation, immuneNoyade,
        pikatchu, cableElectrique,
        flamme, immuneFeu,
        catVador, corde,
        superman, passeSousLesPortes,
        desolidarisation, hachis,
        tireDesBalles, immuneBalle,
        figeLesGens, patinoire }

    void Start()
    {
        isTalking = false;
        life = 9;
        death_list.Clear();
        power_list.Clear();
        initPos = transform.position;
    }

    void Update()
    {
        if (!isTalking)
        {
            action = Input.GetButtonDown("Action");
            if (action)
            {
                if (trigger != null)
                {
                    if (trigger.GetComponent<Interractable>())
                    {
                        trigger.GetComponent<Interractable>().Interract();
                    }
                }
            }
        }
        spellBar.DrawSpellBar(power_list);

        if (power_list.Contains(Power.tireDesBalles) && power_list[0]!= Power.tireDesBalles)
        {
            List<Power> tmp = new List<Power>();
            foreach(Power val in power_list)
            {
                tmp.Add(val);
            }
            tmp.Remove(Power.tireDesBalles);
            power_list.Clear();
            power_list.Add(Power.tireDesBalles);

            foreach (Power val in tmp)
            {
                power_list.Add(val);
            }
        }
    }

    public bool EndChoice()
    {
        if (power_list.Count != 0)
        {
            return power_list.Contains(Power.tireDesBalles);
        }
        else return false;
    }

    public bool IsImmune(Death death)
    {
        Power power;
        switch (death)
        {
            case Death.noyadeActive:
                power = Power.immuneNoyade;
                break;
            case Death.noyadePassive:
                power = Power.immuneNoyade;
                break;
            case Death.chute:
                power = Power.immuneChute;
                break;
            case Death.meurtreParBalle:
                power = Power.immuneBalle;
                break;
            case Death.suicideParBalle:
                power = Power.immuneBalle;
                break;
            case Death.barbecue:
                power = Power.immuneFeu;
                break;
            case Death.lanceFlamme:
                power = Power.immuneFeu;
                break;
            default:
                power = Power.noPower;
                break;
        }
        if (power != Power.noPower && power_list.Contains(power))
        {
            Debug.Log(power + ": immune to " + death + ", kill failed");
            return true;
        }
        else
        {
            Debug.Log("no immune to " + death + ", kill autorized");
            return false;
        }
    }

    public void Kill(Death death)
    {
        if (!IsImmune(death))
        {
            if (this.life != 0)
            {
                Debug.Log("Lose one life");
                this.life -= 1;
            }
        }
        else
            Debug.Log("immune, kill failed");
    }

    public void AddPower(Power power)
    {
        if (!power_list.Contains(power))
        {
            power_list.Add(power);
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        trigger = coll.gameObject;
    }

    void OnTriggerExit2D(Collider2D coll)
    {
        trigger = null;
    }

    public void ResetPosition()
    {
        //transform.position = initPos;
    }
}
