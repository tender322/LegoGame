using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Vector3 DefualtPosition;
    public int YY;             // Высота лего 
    public float sensitivity; // Чувстительность перемещения 
    public float sensivity_cam;
    public float SpeedPlace;
    private bool controllable = false;
    
    public int _distance;     //Дистанция RayCast
    
    public Color SelectColor;
    public Color DefaulColor;

    private Slider CameraSensivity;
    private Slider LegoSensivity;
    public int AudioSatatus;
    public int _lastrotation;

    public GameObject EndObject;
    private void Start()
    {
        gameObject.GetComponent<SceneGenerator>().GenerateScene();
    }

    public void SetControllLego(bool _bool) {controllable = _bool;}
    public bool GetControllLego() {return controllable;}


    public void GetSetting()
    {
        CameraSensivity = GameObject.Find("SensivityCamera").GetComponent<Slider>();
        LegoSensivity = GameObject.Find("SensivityLego").GetComponent<Slider>();
        sensitivity = LegoSensivity.value;
        sensivity_cam = CameraSensivity.value;
    }

    public void Ended()
    {
        EndObject.SetActive(true);
    }

    public void GoMainMenu()
    {
        SceneManager.LoadScene("MainSceneGame");
    }

    public void SetSceneCompleted()
    {
        ScenesCompleted.SetCompleted(SceneManager.GetActiveScene().name);
    }

}
