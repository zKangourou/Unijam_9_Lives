using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class SpellBar : MonoBehaviour {
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
    [SerializeField]
    private PowerIcones powerIcones;
    [SerializeField]
    private Sprite blank;
    public List<Image> listImage = new List<Image>();
    public List<Sprite> list = new List<Sprite>();
    Player player;

    void Awake()
    {
        list.Clear();
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
    }

    public void DrawSpellBar(List<Player.Power> powerList)
    {
        for (int i =0;i<powerList.Count;i++)
        {
            listImage[i].sprite = powerIcones.GetImageSpell(powerList[i]);
        }
    }

        void Start () {
	}
    
    void Update()
    {
    }
    
}
