using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private float cameraSpeed = 5f;
    [SerializeField] public Transform target;
    Volume volume;
    Vignette vignette;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Camera working");
        volume = GetComponent<Volume>();
        volume.profile.TryGet(out vignette);
    }

    // Update is called once per frame
    void Update()
    {
        vignette.intensity.Override(1 - player.GetHpRatio());
        if (player != null)
        {
            if (target == null)
            {
                return;
            }
            var targetPosition = new Vector3(target.transform.position.x, target.transform.position.y, -10);
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, cameraSpeed * Time.unscaledDeltaTime);
        }

    }

    public IEnumerator ShakeCoroutine(float duration, float magnitude)
    {
        Vector3 orignalPosition = transform.position;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            transform.position = new Vector3(x + orignalPosition.x, y + orignalPosition.y, -10f);
            elapsed += Time.deltaTime;
            yield return 0;
        }
        transform.position = orignalPosition;
    }
}
