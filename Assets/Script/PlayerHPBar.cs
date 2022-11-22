using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHPBar : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] Image foreground;
    // Update is called once per frame
    void Update()
    {
        if(player != null)
        {
            //set the position to be equal to the player
            transform.position = player.transform.position + new Vector3(0, 1f, 0);
            float hpRatio = (float) Player.hp / Player.maxHp;
            foreground.transform.localScale = new Vector3(hpRatio, 1, 1);
        }

    }
}
