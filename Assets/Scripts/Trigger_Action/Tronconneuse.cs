using UnityEngine;
using System.Collections;

public class Tronconneuse : Interractable
{
    [SerializeField]
    TexteController txtController;
    string death_dial = "exemple_de_cle";
    public bool lumiere = false;

    public override void Interract()
    {
    }

    void OnTriggerEnter2D(Collider2D val)
    {
        /*
        Debug.Log("piece sombre");
        this.gameObject.SetActive(false);
        if (val.tag == "Player" && !done)
        {
            player.isTalking = true;
            player.Kill(Player.Death.voiture);
            player.AddPower(Player.Power.passeSousLesPortes);
            done = true;
            StartCoroutine(bob.Move());
        }*/
    }

    /*
IEnumerator PrintCar()
{
    transform.localScale = new Vector3(0, 0, 1);
    sprite.color = Color.white;
    bool sound = true;
    while (transform.localScale.x < 0.99f)
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
}*/
}
