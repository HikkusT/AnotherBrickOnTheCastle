using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraEffect : MonoBehaviour
{
    public float initialShakeMagnitude;

    public IEnumerator ShakeScreen(float time)
    {
        float elapsedTime = 0;
        Vector3 startingPos = transform.position;

        while (elapsedTime < time)
        {
            float shakeMagnitude = Mathf.Lerp(initialShakeMagnitude, 0, elapsedTime / time);
            transform.position = startingPos + Random.insideUnitSphere * shakeMagnitude;

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = startingPos;
    }
}
