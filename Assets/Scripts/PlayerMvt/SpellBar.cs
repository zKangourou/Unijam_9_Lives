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
    Player player;
    private PowerIcones powerIcones;
    private int inc;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        spellDictionary.Clear();
    }

    void Start () {
        inc = 0;
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

    public void DrawSpell(Player.Power power)
    {
        inc += 1;
        Sprite spellSprite = powerIcones.GetImageSpell(power);
        //spellDictionary.Add(power, spell1.spellSprite);
    }
}
