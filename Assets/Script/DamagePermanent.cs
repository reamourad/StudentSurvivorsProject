using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DamagePermanent : MonoBehaviour
{
    public int cost;
    [SerializeField] TMP_Text costText;
    [SerializeField] TMP_Text currentLevelText;

    private void Start()
    {
        costText.text = $"Cost: {cost}";
        currentLevelText.text = $"Current level: {TitleManager.saveData.damagePermanent}";
    }


    public void onDamagePermanentClick()
    {
        if(TitleManager.saveData.gold >= cost)
        {
            TitleManager.saveData.gold -= cost;
            TitleManager.saveData.damagePermanent++;
            currentLevelText.text = $"Current level: {TitleManager.saveData.damagePermanent}";
        }
    }
}
