using UnityEngine;
using System.Collections;

public class Tuyeau : Interractable
{
    [SerializeField]
    private GameObject other;

    public override void Interract()
    {
        if (player.power_list.Contains(Player.Power.canalisation))
        {
            GameObject.FindGameObjectWithTag("Player").transform.position = other.transform.position;
            GameObject.FindGameObjectWithTag("Indicator").GetComponent<IndicatorManager>().HideHelp();
        }
    }

    void OnTriggerEnter2D()
    {
        if (player.power_list.Contains(Player.Power.canalisation))
        {
            GameObject.FindGameObjectWithTag("Indicator").GetComponent<IndicatorManager>().ShowHelp();
        }
    }
    void OnTriggerExit2D()
    {
        GameObject.FindGameObjectWithTag("Indicator").GetComponent<IndicatorManager>().HideHelp();
    }
}
