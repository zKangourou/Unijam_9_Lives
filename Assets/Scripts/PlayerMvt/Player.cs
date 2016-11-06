using UnityEngine;
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
     //   power_list.Add(Power.immuneFeu);
        if (power_list.Count != 0)
        {
            for (int i = 0; i < power_list.Count; i++)
            {
                Debug.Log("draw, power_list[i]=" + power_list[i]);
                spellBar.DrawSpell(power_list[i]);
            }
        }
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
