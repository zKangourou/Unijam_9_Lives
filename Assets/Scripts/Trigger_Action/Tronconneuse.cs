using UnityEngine;
using System.Collections;

public class Tronconneuse : Interractable
{
    [SerializeField]
    TexteController txtController;
    string death_dial = "exemple_de_cle";
    [SerializeField]
    GameObject pieceSombre;
    private Vector3 posBob;

    public override void Interract()
    {
    }

    void OnTriggerEnter2D(Collider2D val)
    {
        Debug.Log("trigger tronconneuse");
        GetComponent<Collider2D>().enabled = false;
        pieceSombre.SetActive(false);
        if (val.tag == "Player" && !done)
        {
            player.isTalking = true;
            player.Kill(Player.Death.tronconneuse);
            player.AddPower(Player.Power.desolidarisation);
            done = true;
            SoundManager.PlayBruitage(SoundManager.Bruitages.VIOLON);
            StartCoroutine(BobMove());
        }
    }

    IEnumerator BobMove()
    {
        //transform.localScale = new Vector3(0, 0, 1);
        //sprite.color = Color.white;
        bool sound = true;
        //while (transform.localScale.x < 0.99f)
        while (this.transform.position.x > player.transform.position.x)
        {
            this.transform.position -= new Vector3(0.3f, 0, 0);
            player.transform.position -= new Vector3(0.08f, 0, 0);
            /*
            if (sound && transform.localScale.x > 0.20f)
            {
                SoundManager.PlayBruitage(SoundManager.Bruitages.VOITURE);
                sound = false;
            }*/
            yield return new WaitForSeconds(0.03f);
        }
        //transform.localScale = new Vector3(1, 1, 1);
        txtController.StartDialogue(death_dial, TexteController.DialogueType.DIE, Player.Death.tronconneuse);
    }
}
