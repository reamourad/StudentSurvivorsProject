using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeMenu : MonoBehaviour
{
    [SerializeField] Player player;
    public GameObject[] upgradeCanvas;

    public void createUpgrades()
    {
        Time.timeScale = 0;
        List<int> chosenNums = new List<int>();
        foreach (GameObject upgrade in upgradeCanvas)
        {
            //find a weapon that hasnt been chosen yet
            int randomIndex = 1;
            //int randomIndex = Random.Range(0, player.weapons.Length);
            while (chosenNums.Contains(randomIndex))
            {
                randomIndex = Random.Range(0, player.weapons.Length);
            }
            chosenNums.Add(randomIndex);
            
            //update the upgrades 
            upgrade.GetComponent<UpgradeCanvas>().weapon = player.weapons[randomIndex];
            upgrade.GetComponent<UpgradeCanvas>().levelText.text = string.Format("Level: {0}", player.weapons[randomIndex].level.ToString());
            upgrade.GetComponent<UpgradeCanvas>().image.sprite = player.weapons[randomIndex].sprite;
            upgrade.GetComponent<UpgradeCanvas>().weaponName.text = player.weapons[randomIndex].weaponName;
            upgrade.GetComponent<UpgradeCanvas>().description.text = player.weapons[randomIndex].description;
        }
    }
}
