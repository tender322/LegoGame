using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PreViewScript : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public object ImageLevel;
    public GameObject Window;
    
    public void OnPointerDown(PointerEventData eventData) {SetPreView(true); }

    public void OnPointerUp(PointerEventData eventData) { SetPreView(false); }

    
    private void Start()
    {
        if(Resources.Load("sceneicons/" + SceneManager.GetActiveScene().name))
            ImageLevel = Resources.Load("sceneicons/" + SceneManager.GetActiveScene().name);
    }

    public void SetPreView(bool _status)
    {
        Window.SetActive(_status);
    }
}
