using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    [SerializeField]private int audiostatus;
    public GameObject OnAudio;
    public GameObject OffAudio;
    private void Start()
    {
        LoadSettings();
        this.gameObject.GetComponent<Button>().onClick.AddListener(()=>AudioActive(audiostatus));
    }

    public void SaveSettings()
    {
        var CamSens = GameObject.Find("SensivityCamera").GetComponent<Slider>().value;
        var LegoSens = GameObject.Find("SensivityLego").GetComponent<Slider>().value;
        PlayerPrefs.SetFloat("CamSens",CamSens);
        PlayerPrefs.SetFloat("LegoSens",LegoSens);
        PlayerPrefs.SetInt("AudioStatus",audiostatus);
        
        LoadSettings();
    }

    public void AudioActive(int _status)
    {
        if (_status == 0)
        { OnAudio.SetActive(false);
            OffAudio.SetActive(true); }
        else
        { OnAudio.SetActive(true);
            OffAudio.SetActive(false); }

        GameObject.Find("SensivityCamera").GetComponent<Slider>().value = PlayerPrefs.GetFloat("CamSens");
        GameObject.Find("SensivityLego").GetComponent<Slider>().value =  PlayerPrefs.GetFloat("LegoSens");
    }

    public void LoadSettings()
    {
         GameManager GM = GameObject.FindObjectOfType<GameManager>().GetComponent<GameManager>();
        GM.sensivity_cam = PlayerPrefs.GetFloat("CamSens");
        GM.sensitivity = PlayerPrefs.GetFloat("LegoSens");
        audiostatus = PlayerPrefs.GetInt("AudioStatus");
        GM.AudioSatatus = PlayerPrefs.GetInt("AudioStatus");

    }

    public void ToggleAudio(int _status)
    {
        audiostatus = _status;
    }
    
}
