using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PreViewScript : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    
    
    public void OnPointerDown(PointerEventData eventData) {SetPreView(); }

    public void OnPointerUp(PointerEventData eventData) {}

    public Camera ViewCam;
    public GameObject _settings;
    public GameObject _paste;
    public GameObject _rot;
    public GameObject _zoom;

    private bool _main;

    public void SetPreView()
    {
        if (_main)
        {
            _main = false;
            Camera.main.depth = -10;
            _settings.SetActive(false);
            _paste.SetActive(false);
            _rot.SetActive(false);
            _zoom.SetActive(false);
        }
        else
        {
            _main = true;
            Camera.main.depth = -1;
            _settings.SetActive(true);
            _paste.SetActive(true);
            _rot.SetActive(true); 
            _zoom.SetActive(true);
        }

    }
}
