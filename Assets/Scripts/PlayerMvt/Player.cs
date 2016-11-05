using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour
{
    private int life;
    private GameObject trigger;
    private bool action;
    private List<Death> death_list = new List<Death>();
    private List<Power> power_list = new List<Power>();
    public bool isTalking;
    //private List<Transform> myList = new List<Transform>();
    //private Dictionary<Deaths, List<Transform>> myDeath;

    public enum Death {
        drogue, medoc,
        tazer, priseElectrique,
        noyadePassive, noyadeActive,
        strangulation, pendaison,
        barbecue, lanceFlamme,
        voiture, piano,
        tronconneuse, hachoir,
        suicideParBalle, meurtreParBalle,
        lion, mange,
        givrePassive, givreActive
    }
    private enum Power { immuneFeu, immuneBalle, immuneTotal }

    void Start()
    {
        isTalking = false;
        life = 9;
    }

    void Update()
    {
        action = Input.GetButtonDown("Action");
        if (action)
        {
            if (trigger != null)
            {
                if (trigger.GetComponent<Interractable>())
                {
                    trigger.GetComponent<Interractable>().Interract();
                    //DieorNot(trigger.mDeath, trigger.isKilling);
                    //AddPower(trigger.mPower);
                }
            } 
        }
    }

    private bool IsImmune(Death death)
    {
        switch (death)
        {
            case Death.medoc:
                return true;
            case Death.barbecue:
                return true;
            case Death.suicideParBalle:
                return true;
            default:
                return false;
        }
    }

    public void DieorNot(Death death, bool kill)
    {
        if (!IsImmune(death))
        {
            if (kill && (this.life != 0))
            {
                Debug.Log("Lose one life");
                this.life -= 1;
            }
        }
    }

    public void Die()
    {
        if (this.life != 0)
        {
            Debug.Log("Lose one life");
            this.life -= 1;
        }
    }

    private void AddPower(Power power)
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
}
