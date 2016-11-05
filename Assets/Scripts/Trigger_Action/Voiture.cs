using UnityEngine;
using System.Collections;

public class Voiture : Interractable
{
    [SerializeField] TexteController txtController;
    [SerializeField] SpriteRenderer sprite;
    string death_dial = "exemple_de_cle";

    public override void Interract()
    {
    }

    void OnTriggerEnter2D()
    {
        if (!done)
        {
            txtController.StartDialogue(death_dial, TexteController.DialogueType.DIE, Player.Death.voiture);
            player.Kill(Player.Death.voiture);
            player.AddPower(Player.Power.superman);
            done = true;
            StartCoroutine(PrintCar());
        }
    }

    IEnumerator PrintCar()
    {
        transform.localScale = new Vector3(0, 0, 1);
        sprite.color = Color.white;
        while(transform.localScale.x<0.99f)
        {
            transform.localScale += new Vector3(0.01f, 0.01f, 0);
            yield return new WaitForSeconds(0.01f);
        }
        transform.localScale = new Vector3(1, 1, 1);
    }
}
