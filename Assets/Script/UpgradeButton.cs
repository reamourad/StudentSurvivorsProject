using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class UpgradeButton : MonoBehaviour
{
    [SerializeField] GameObject upgradeCanvas;
    [SerializeField] GameObject upgradeMenu;
    Volume volume;
    DepthOfField depthOfField;


    private void Start()
    {
        volume = Camera.main.GetComponent<Volume>();
        volume.profile.TryGet(out depthOfField);
    }

    public void onUpgradeButtonClick()
    {
        upgradeCanvas.GetComponent<UpgradeCanvas>().weapon.LevelUp();
        Time.timeScale = 1;
        depthOfField.mode.Override((DepthOfFieldMode)0);
        upgradeMenu.SetActive(false);
    }

}
