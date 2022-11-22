using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class GoldText : MonoBehaviour
{
    [SerializeField] TMP_Text goldText;

    private void Update()
    {
        goldText.text = TitleManager.saveData.gold.ToString();
    }
}
