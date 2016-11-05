using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;

public class DeathScreenController : MonoBehaviour
{
    static float SHORT_DELTA_TIME = 0.015f;
    static float DELTA_TIME = 0.1f;
    static float LONG_DELTA_TIME = 0.5f;
    static float WAIT_AT_START = 0.5f;

    Dictionary<Player.Death, DeathPatern> deathNote;

    [SerializeField] private GameObject things;
    [SerializeField] private Text deathExplanation;
    [SerializeField] private Text deathPowerExplanation;
    [SerializeField] private GameObject deathPowerTitle;
    [SerializeField] private Image image;
    private Player player;
    [SerializeField] private GameObject nextText;
    bool next;


    // Use this for initialization
    void Start () {
        deathNote = new Dictionary<Player.Death, DeathPatern>();
        DeathScreenListPatern deathList = XmlHelpers.LoadFromTextAsset<DeathScreenListPatern>(Resources.Load<TextAsset>("deathScreen"));
        foreach (DeathScreenPatern val in deathList.list)
        {
            deathNote.Add(val.deathType, val.deathDescription);
        }
        /*DeathScreenListPatern tmp = new DeathScreenListPatern();
        tmp.list.Add(new DeathScreenPatern(Player.Death.barbecue,new DeathPatern("exemple de déscription de la mort","exemple de description du pouvoir lié à la mort")));
        XmlHelpers.SaveToXML<DeathScreenListPatern>("C:/Users/simon/Desktop/deathScreen.xml", tmp);*/

        things.SetActive(false);
        deathExplanation.text = "";
        deathPowerExplanation.text = "";
        deathPowerTitle.SetActive(false);
        image.gameObject.SetActive(false);
        nextText.SetActive(false);
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    public void Cheat()
    {
        StartDeath(Player.Death.barbecue);
    }

    public void StartDeath(Player.Death deathType)
    {
        if(!deathNote.ContainsKey(deathType))
        {
            Debug.LogError("Type de mort inconnue");
            return;
        }
        
        deathExplanation.text = "";
        deathPowerExplanation.text = "";
        deathPowerTitle.SetActive(false);
        image.gameObject.SetActive(false);
        nextText.SetActive(false);

        things.SetActive(true);
        StartCoroutine(PrintText(deathType));
    }



    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            next = true;
        }
    }

    IEnumerator PrintText(Player.Death deathType)
    {
        DeathPatern actualPatern = deathNote[deathType];
        yield return new WaitForSeconds(WAIT_AT_START);
            foreach (char c in actualPatern.deathDescription)
            {
                deathExplanation.text += c;
                    yield return new WaitForSeconds(SHORT_DELTA_TIME);

                    if (c == '.' || c == '!' || c == '?' || c == ';' || c == '\n')
                    {
                        yield return new WaitForSeconds(LONG_DELTA_TIME);
                    }
                    else if (c == ',')
                    {
                        yield return new WaitForSeconds(DELTA_TIME);
                    }
            }
        deathPowerTitle.SetActive(true);
        image.sprite = PowerIcones.GetImage(deathType);
        image.gameObject.SetActive(true);
        deathPowerExplanation.text = actualPatern.deathPowerDescription;
        nextText.SetActive(true);


        next = false;
            while (!next)
            {
                yield return new WaitForSeconds(SHORT_DELTA_TIME);
            }
        things.SetActive(false);
        player.Kill(deathType);
    }
}
