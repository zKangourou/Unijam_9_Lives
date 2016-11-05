using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TexteController : Singleton<TexteController> {
    [SerializeField] private Text text;
    [SerializeField]
    private GameObject things;

	// Use this for initialization
	void Awake () {
	
	}
}
