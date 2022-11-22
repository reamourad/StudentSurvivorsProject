using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShieldPermanent : MonoBehaviour
{
    public int cost;
    [SerializeField] TMP_Text costText;
    [SerializeField] TMP_Text currentLevelText;

    private void Start()
    {
        costText.text = $"Cost: {cost}";
        currentLevelText.text = $"Current level: {TitleManager.saveData.speedPermanent}";
    }


    public void onSpeedPermanentClick()
    {
        if (TitleManager.saveData.gold >= cost)
        {
            TitleManager.saveData.gold -= cost;
            TitleManager.saveData.speedPermanent++;
            Debug.Log(TitleManager.saveData.speedPermanent);
            currentLevelText.text = $"Current level: {TitleManager.saveData.speedPermanent}";
        }
    }
}
