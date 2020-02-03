using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardHand : MonoBehaviour
{
    public float cardHeight;
    public float movementDuration;

    private List<GameObject> cards = new List<GameObject>();
    private RectTransform rectTransform;
    private float width;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    private void Update()
    {
        width = rectTransform.rect.width;
    }

    public void AddCard(GameObject card)
    {
        card.transform.SetParent(transform);
        cards.Add(card);
        ReorganizeHand();
    }

    public void RemoveCard(GameObject card)
    {
        cards.Remove(card);
        ReorganizeHand();
    }

    private void ReorganizeHand()
    {
        float spacing = width / (cards.Count + 1);

        for(int i = 0; i < cards.Count; i++)
        {
            Vector2 newPos = new Vector2((i + 1) * spacing, cardHeight);
            StartCoroutine(cards[i].GetComponent<CardBase>().Move(newPos, movementDuration));
        }
    }
}
