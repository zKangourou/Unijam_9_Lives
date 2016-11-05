using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class DeathScreenController : MonoBehaviour
{
    static float SHORT_DELTA_TIME = 0.015f;
    static float DELTA_TIME = 0.1f;
    static float LONG_DELTA_TIME = 0.5f;
    static float WAIT_AT_START = 0.5f;

    DeathScreenListPatern deathList;

    [SerializeField] private GameObject things;
    [SerializeField] private Text deathExplanation;
    [SerializeField] private Text deathPowerExplanation;
    [SerializeField] private Text deathPowerTitle;
    [SerializeField] private Image image;
    [SerializeField] private Player player;


    // Use this for initialization
    void Start () {
        deathList = XmlHelpers.LoadFromTextAsset<DeathScreenListPatern>(Resources.Load<TextAsset>("deathScreen"));
        /*DeathScreenListPatern tmp = new DeathScreenListPatern();
        tmp.list.Add(new DeathScreenPatern("exemple_de_mort","exemple de déscription de la mort","exemple de description du pouvoir lié à la mort"));
        XmlHelpers.SaveToXML<DeathScreenListPatern>("C:/Users/simon/Desktop/deathScreen.xml", tmp);*/

        things.SetActive(false);
        deathExplanation.text = "";
        deathPowerExplanation.text = "";
        deathPowerTitle.text = "";
        image.gameObject.SetActive(false);
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    public void StartDeath(string deathType)
    {
        if()

        things.SetActive(false);
    }
}
