using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PostProcessingController : MonoBehaviour
{
    public static bool postProcessing = true;
    [SerializeField] Toggle toggle;
    private void Start()
    {
        toggle.isOn = postProcessing;
    }

    public void PostProcessingOnOff(bool value)
    {
        postProcessing = toggle.isOn;
    }

    public void onBackButton()
    {
        SceneManager.LoadScene("Title");
    }
}
