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
    private List<Image> listImage = new List<Image>();
    public Dictionary<string, Image> spellDictionary = new Dictionary<string, Image>();
    Player player;
    private PowerIcones powerIcones;
    private Image image;

    void Awake()
    {
        listImage.Clear();
        listImage.Add(spell1);
        listImage.Add(spell2);
        listImage.Add(spell3);
        listImage.Add(spell4);
        listImage.Add(spell5);
        listImage.Add(spell6);
        listImage.Add(spell7);
        listImage.Add(spell8);
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        spellDictionary.Clear();
    }

    void Start () {
	}
    
    void Update()
    {
    }

    public void DrawSpell(Player.Power power)
    {
        Sprite spellSprite = powerIcones.GetImageSpell(power);
        if (listImage.Count != 0) {
            for (int i = 0; i < listImage.Count; i++)
            {
                if (listImage[i] == blank)
                {
                    listImage[i].sprite = spellSprite;
                    break;
                }
            }
        }
    }
}
