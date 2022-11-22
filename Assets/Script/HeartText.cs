using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HeartText : MonoBehaviour
{
    [SerializeField] TMP_Text heartText;

    private void Update()
    {
        heartText.text = Player.hp.ToString() + "/" + Player.maxHp.ToString();
    }
}
