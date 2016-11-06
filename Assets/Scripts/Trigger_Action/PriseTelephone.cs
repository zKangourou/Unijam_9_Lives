using UnityEngine;
using System.Collections;

public class PriseTelephone : Interractable
{
    [SerializeField] private GameObject other;

    public override void Interract()
    {
        if(player.power_list.Contains(Player.Power.cableElectrique))//ajouter un test de skill
        {
            GameObject.FindGameObjectWithTag("Player").transform.position = other.transform.position;
            GameObject.FindGameObjectWithTag("Indicator").GetComponent<IndicatorManager>().HideHelp();
        }
    }

    void OnTriggerEnter2D()
    {
        if (player.power_list.Contains(Player.Power.cableElectrique))//ajouter un test de skill
        {
            GameObject.FindGameObjectWithTag("Indicator").GetComponent<IndicatorManager>().ShowHelp();
        }
    }
    void OnTriggerExit2D()
    {
        GameObject.FindGameObjectWithTag("Indicator").GetComponent<IndicatorManager>().HideHelp();
    }
}