using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathManager : MonoBehaviour
{
    [SerializeField] TMP_Text giantText;
    [SerializeField] TMP_Text mermanText;
    [SerializeField] TMP_Text zombieText;
    [SerializeField] TMP_Text goldText;
    [SerializeField] TMP_Text crystalText;


    private void Start()
    {
        giantText.text = GameManager.deathData.giantCount.ToString();
        mermanText.text = GameManager.deathData.mermanCount.ToString();
        zombieText.text = GameManager.deathData.zombieCount.ToString();
        goldText.text = GameManager.deathData.goldCount.ToString();
        crystalText.text = GameManager.deathData.expCount.ToString();
    }

    public void onTitleButtonClick()
    {
        SceneManager.LoadScene("Title");
    }
}
