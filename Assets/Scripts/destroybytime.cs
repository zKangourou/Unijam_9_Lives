﻿using UnityEngine;
using System.Collections;

public class destroybytime : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine(death());
	}

    IEnumerator death()
    {
        yield return new WaitForSeconds(5);
        GameObject.Destroy(this.gameObject);
    }
}
