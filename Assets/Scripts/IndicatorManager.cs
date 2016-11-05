using UnityEngine;
using System.Collections;

public class IndicatorManager : MonoBehaviour {
    [SerializeField] private GameObject objet;

    public void ShowHelp()
    {
        objet.SetActive(true);
    }
    public void HideHelp()
    {
        objet.SetActive(false);
    }
}
