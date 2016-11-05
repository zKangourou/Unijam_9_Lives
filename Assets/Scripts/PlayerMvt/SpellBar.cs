using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class SpellBar : MonoBehaviour {
    [SerializeField]
    private Sprite blank;
    [SerializeField]
    private Image spell1;
    [SerializeField]
    private Image spell2;
    [SerializeField]
    private Image spell3;
    [SerializeField]
    private Image spell4;
    [SerializeField]
    private Image spell5;
    [SerializeField]
    private Image spell6;
    [SerializeField]
    private Image spell7;
    [SerializeField]
    private Image spell8;
    public Dictionary<string, Image> spellDictionary;
    //Player player;

    void Awake()
    {
        //player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        spellDictionary.Clear();
    }

    void Start () {
	    
	}
    
    void Update()
    {
        /*
        for (int i = 0; i < player.power_list.Count; i++)
        {
            actualText = textList[i].text;
            image.sprite = dialogueImages.GetImage(textList[i].image);
        }*/
    }
}
