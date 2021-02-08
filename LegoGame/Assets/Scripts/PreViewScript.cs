using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PreViewScript : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    
    
    public void OnPointerDown(PointerEventData eventData) {SetPreView(true); }

    public void OnPointerUp(PointerEventData eventData) { SetPreView(false); }
    
    public GameObject ImageLevel;
    public GameObject Window;
    
    private void Start()
    {
        if(Resources.Load("sceneicons/" + SceneManager.GetActiveScene().name))
            ImageLevel.GetComponent<RawImage>().texture = (Texture)Resources.Load("sceneicons/" + SceneManager.GetActiveScene().name);
    }

    public void SetPreView(bool _status)
    {
        Window.SetActive(_status);
        
    }
}
