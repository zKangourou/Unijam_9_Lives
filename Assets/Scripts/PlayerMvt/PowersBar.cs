using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class PowersBar : MonoBehaviour {
    [SerializeField]
    private Sprite blank;
    Dictionary<string, List<Image>> spellDictionary;
    Player player;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

    }

    void Start () {
	    
	}
    
    void Update()
    {
        for (int i = 0; i < player.power_list.Count; i++)
        {/*
            actualText = textList[i].text;
            image.sprite = dialogueImages.GetImage(textList[i].image);*/
        }
    }
}
