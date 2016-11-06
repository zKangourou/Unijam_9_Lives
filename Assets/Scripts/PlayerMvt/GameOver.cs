using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameOver : MonoBehaviour {
    Player player;
    EndGame endGame;
    private GameObject trigger;

    public enum EndGame { ACTIF,PASSIF };

	void Awake ()
    {
        endGame = EndGame.PASSIF;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }
	
	void Update ()
    {
        if (trigger != null)
        {
            if (trigger.GetComponent<Interractable>())
            {
                trigger.GetComponent<Interractable>().Interract();
            }
        }
    }

    public void EndChoice(List<Player.Power> powerList)
    {
        if (powerList.Count != 0)
        {
            if (powerList.Contains(Player.Power.tireDesBalles))
            {
                endGame = EndGame.ACTIF;
            }
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
