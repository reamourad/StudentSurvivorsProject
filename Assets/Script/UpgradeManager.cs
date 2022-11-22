using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UpgradeManager : MonoBehaviour
{
    public void onBackButtonClick()
    {
        SceneManager.LoadScene("Title");
    }
}
