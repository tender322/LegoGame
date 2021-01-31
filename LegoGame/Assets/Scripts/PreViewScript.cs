using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PreViewScript : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public GameObject PreView;
    public void OnPointerDown(PointerEventData eventData)
    {SetPreView(true); }

    public void OnPointerUp(PointerEventData eventData)
    { SetPreView(false); }
    
    public void SetPreView(bool _status)
    {
        PreView.SetActive(_status);
    }
}
