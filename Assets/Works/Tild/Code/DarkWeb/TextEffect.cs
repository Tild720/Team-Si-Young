using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class TextEffect : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    private TMP_Text text;
    private string tempText;
    private void Awake()
    {
        text = GetComponentInChildren<TMP_Text>();
        tempText = text.text;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        text.text = tempText;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        text.text = ($"<{tempText}>");
    }
}
