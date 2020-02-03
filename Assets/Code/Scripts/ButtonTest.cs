using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonTest : MonoBehaviour
{
    public CardHand hand;
    public GameObject card;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(Add);
    }

    public void Add()
    {
        GameObject cardInstance = Instantiate(card);
        hand.AddCard(cardInstance);
    }
}
