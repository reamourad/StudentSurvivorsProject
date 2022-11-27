using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PostProcessingController : MonoBehaviour
{
    public static bool postProcessing = true;

    public void PostProcessingOnOff(bool value)
    {
        postProcessing = value;
    }

    public void onBackButton()
    {
        SceneManager.LoadScene("Title");
    }
}
