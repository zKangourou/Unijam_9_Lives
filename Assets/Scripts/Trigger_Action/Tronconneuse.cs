using UnityEngine;
using System.Collections;

public class Tronconneuse : Interractable
{
    [SerializeField]
    TexteController txtController;
    string death_dial = "exemple_de_cle";
    [SerializeField]
    GameObject bob_tronconneuse;
    private Vector3 posBob;

    public override void Interract()
    {
    }

    void OnTriggerEnter2D(Collider2D val)
    {
        posBob = bob_tronconneuse.transform.position;
        Debug.Log("piece sombre");
        this.gameObject.SetActive(false);
        if (val.tag == "Player" && !done)
        {
            player.isTalking = true;
            player.Kill(Player.Death.tronconneuse);
            player.AddPower(Player.Power.desolidarisation);
            done = true;
            StartCoroutine(BobMove());
        }
    }

    IEnumerator BobMove()
    {        
        //transform.localScale = new Vector3(0, 0, 1);
        //sprite.color = Color.white;
        bool sound = true;
        //while (transform.localScale.x < 0.99f)s
        while (bob_tronconneuse.transform.position.x > player.transform.position.x)
        {
            bob_tronconneuse.transform.position += new Vector3(-1.0f, 0, 0);
            SoundManager.PlayBruitage(SoundManager.Bruitages.VIOLON);
            /*
            if (sound && transform.localScale.x > 0.20f)
            {
                SoundManager.PlayBruitage(SoundManager.Bruitages.VOITURE);
                sound = false;
            }*/
            yield return new WaitForSeconds(0.01f);
        }
        //transform.localScale = new Vector3(1, 1, 1);
        txtController.StartDialogue(death_dial, TexteController.DialogueType.DIE, Player.Death.tronconneuse);
    }
}
