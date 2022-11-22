using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class Boss : MonoBehaviour
{
    Volume volume;
    LensDistortion lensDistortion;

    private void Awake()
    {
        volume = Camera.main.GetComponent<Volume>();
        volume.profile.TryGet(out lensDistortion);
        Debug.Log(lensDistortion.intensity.value);
    }

    //public IEnumerator DistortCoroutine()
    //{
    //    //while (lensDistortion.intensity.value > -1f)
    //    //{
    //    //    lensDistortion.intensity.value -= 0.1f;
    //    //    yield return new WaitForSeconds(0.05f);
    //    //}
    //    lensDistortion.intensity.value = -1;
    //    yield return new WaitForSeconds(1f);
    //    //while (lensDistortion.intensity.value < 0)
    //    //{
    //    //    lensDistortion.intensity.value += 0.1f;
    //    //    yield return new WaitForSeconds(0.1f);
    //    //}
    //    lensDistortion.intensity.value = 0;
    //    Debug.Log("collision");
    //    yield return 0;

    //}

   
}
