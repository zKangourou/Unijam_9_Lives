using UnityEngine;
using System.Collections;

public class Voiture : Interractable
{
    [SerializeField] TexteController txtController;
    [SerializeField] SpriteRenderer sprite;
    string death_dial = "mort_par_voiture";

    public override void Interract()
    {
    }

    void OnTriggerEnter2D(Collider2D val)
    {
        if (val.tag == "Player" && !done)
        {
            player.isTalking = true;
            player.Kill(Player.Death.voiture);
            player.AddPower(Player.Power.passeSousLesPortes);
            done = true;
            StartCoroutine(PrintCar());
        }
    }

    IEnumerator PrintCar()
    {
        transform.localScale = new Vector3(0, 0, 1);
        sprite.color = Color.white;
        bool sound = true;
        while(transform.localScale.x<0.99f)
        {
            transform.localScale += new Vector3(0.01f, 0.01f, 0);
            if (sound && transform.localScale.x > 0.20f)
            {
                SoundManager.PlayBruitage(SoundManager.Bruitages.VOITURE);
                sound = false;
            }
            yield return new WaitForSeconds(0.01f);
        }
        transform.localScale = new Vector3(1, 1, 1);
        txtController.StartDialogue(death_dial, TexteController.DialogueType.DIE, Player.Death.voiture);
    }
}
