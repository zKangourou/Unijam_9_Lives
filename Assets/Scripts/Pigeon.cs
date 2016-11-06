using UnityEngine;
using System.Collections;

public class Pigeon : MonoBehaviour {

    Animator animateur;

	// Use this for initialization
	void Start () {
        animateur = this.GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        float a = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMvt>().avance;
        if (a>=0)
        {
            if (animateur != null)
            {
                animateur.SetBool("Droite", true);
            }
        }
        else
        {
            if (animateur != null)
            {
                animateur.SetBool("Droite", false);
            }
        }
    }
}
