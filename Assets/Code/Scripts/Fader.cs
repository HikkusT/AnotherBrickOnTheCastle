using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fader : MonoBehaviour
{
    public float endTransparency;

    private Image image;

    void Start()
    {
        image = GetComponent<Image>();
        image.color = new Color(image.color.r, image.color.g, image.color.b, 0);
    }

    public IEnumerator FadeIn(float time)
    {
        float elapsedTime = 0;
        Color startingColor = image.color;
        Color endColor = new Color(image.color.r, image.color.g, image.color.b, endTransparency);

        while (elapsedTime < time)
        {
            image.color = Color.Lerp(startingColor, endColor, elapsedTime / time);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }

    public IEnumerator FadeOut(float time)
    {
        float elapsedTime = 0;
        Color startingColor = image.color;
        Color endColor = new Color(image.color.r, image.color.g, image.color.b, 0);

        while (elapsedTime < time)
        {
            image.color = Color.Lerp(startingColor, endColor, elapsedTime / time);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }
}
