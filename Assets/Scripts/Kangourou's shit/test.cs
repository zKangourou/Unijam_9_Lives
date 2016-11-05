using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class test : MonoBehaviour {

	// Use this for initialization
	void Start () {
        List<DialogueElementPatern> tmp =  TextesDictionary.GetTexte("exemple_de_cle");
        foreach (DialogueElementPatern val in tmp)
        {
            Debug.Log(val.image + " " + val.text);
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
