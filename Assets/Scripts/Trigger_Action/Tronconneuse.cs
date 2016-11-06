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
    private bool bla;
    private int inc = 0;

    public override void Interract()
    {
    }

    void OnTriggerEnter2D(Collider2D val)
    {
        pieceSombre.SetActive(false);
        if (val.tag == "Player" && !done)
        {
            player.isTalking = true;
            bla = true;
            player.Kill(Player.Death.tronconneuse);
            player.AddPower(Player.Power.desolidarisation);
            done = true;
            SoundManager.PlayBruitage(SoundManager.Bruitages.VIOLON);
            StartCoroutine(BobMove());
        }
    }

    void OnTriggerExit2D(Collider2D val)
    {
        SoundManager.PlayBruitage(SoundManager.Bruitages.STOP);
        GetComponent<Collider2D>().enabled = false;
        if (val.tag == "Player")
        {
            player.isTalking = false;
            pieceSombre.SetActive(true);
            bla = false;
        }
    }

    IEnumerator BobMove()
    {
        while (bla && this.transform.position.x > player.transform.position.x)
        {
            inc += 1;
            this.transform.position -= new Vector3(0.05f, 0, 0);
            if (inc > 6)
            {
                player.transform.position -= new Vector3(0.06f, 0, 0);
            }
            yield return new WaitForSeconds(0.03f);
        }
    }
}
