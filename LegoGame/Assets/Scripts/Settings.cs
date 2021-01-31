using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    private void Start()
    {
        LoadSettings();
    }

    public void SaveSettings()
    {
        var CamSens = GameObject.Find("SensivityCamera").GetComponent<Slider>().value;
        var LegoSens = GameObject.Find("SensivityLego").GetComponent<Slider>().value;
        PlayerPrefs.SetFloat("CamSens",CamSens);
        PlayerPrefs.SetFloat("LegoSens",LegoSens);
        LoadSettings();
    }

    public void LoadSettings()
    {
         GameManager GM = GameObject.FindObjectOfType<GameManager>().GetComponent<GameManager>();
        GM.sensivity_cam = PlayerPrefs.GetFloat("CamSens");
        GM.sensitivity = PlayerPrefs.GetFloat("LegoSens");

    }
}
