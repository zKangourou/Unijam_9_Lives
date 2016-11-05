using UnityEngine;
using System.Collections;

public class Stairs : Interractable
{
    [SerializeField]
    private GameObject other;

    public override void Interract()
    {
        GameObject.FindGameObjectWithTag("Player").transform.position = other.transform.position + new Vector3(0, -2.24f, 0);
    }

    void OnTriggerEnter2D()
    {
        GameObject.FindGameObjectWithTag("Indicator").GetComponent<IndicatorManager>().ShowHelp();
    }
    void OnTriggerExit2D()
    {
        GameObject.FindGameObjectWithTag("Indicator").GetComponent<IndicatorManager>().HideHelp();
    }
}
