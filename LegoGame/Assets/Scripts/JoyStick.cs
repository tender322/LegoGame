using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class JoyStick : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    private Image joystickBg;
    private Image joystick;
    private Vector2 inputVector;
    private GameManager GM;
    private void Start()
    {
        joystickBg = GetComponent<Image>();
        joystick = transform.GetChild(0).GetComponent<Image>();
        GM = GameObject.FindObjectOfType<GameManager>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
        GM.SetControllLego(true);
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 pos;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(joystickBg.rectTransform, eventData.position,
            eventData.pressEventCamera, out pos))
        {
            pos.x = pos.x / joystickBg.rectTransform.sizeDelta.x;
            pos.y = pos.y / joystickBg.rectTransform.sizeDelta.y;
        }
        inputVector = new Vector2(pos.x , pos.y);
        
        inputVector = (inputVector.magnitude > 1.0f) ? inputVector.normalized : inputVector;
        joystick.rectTransform.anchoredPosition = new Vector2(inputVector.x * (joystickBg.rectTransform.sizeDelta.x / 2), inputVector.y * (joystickBg.rectTransform.sizeDelta.y / 2));
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        inputVector = Vector2.zero;
        joystick.rectTransform.anchoredPosition = Vector2.zero;
        GM.SetControllLego(false);

        
    }


    public float Horizontal()
    {
        if (inputVector.x != 0)
            return inputVector.x;
        else return 0;
    }

    public float Vertical()
    {
        if (inputVector.y != 0)
            return inputVector.y;
        else return 0;
    }
}
