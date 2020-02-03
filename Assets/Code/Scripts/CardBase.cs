using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardBase : Draggable
{
    public IEnumerator Move(Vector2 newPos, float time)
    {
        float elapsedTime = 0;
        RectTransform rectTransform = GetComponent<RectTransform>();
        Vector3 startingPos = rectTransform.anchoredPosition;

        while (elapsedTime < time)
        {
            rectTransform.anchoredPosition = Vector2.Lerp(startingPos, newPos, elapsedTime / time);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }
}
