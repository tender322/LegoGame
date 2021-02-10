using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WindowsController : MonoBehaviour
{
    public GameObject MainWindow;
    public GameObject ScrollCanvas;

    public GameObject Scene_0;
    public GameObject Scene_1;
    public GameObject Scene_2;

    public void ChangeCanvas()
    {
        ScrollCanvas.SetActive(true);
        MainWindow.SetActive(false);
    }

    public void StartScenes(string _nameScenes)
    {
        MainWindow.SetActive(true);
        ScrollCanvas.SetActive(false);
        Scene_0.transform.GetChild(0).GetComponent<RawImage>().texture =
            (Texture) Resources.Load("sceneicons/" + _nameScenes + "_0");
        Scene_1.transform.GetChild(0).GetComponent<RawImage>().texture =
            (Texture) Resources.Load("sceneicons/" + _nameScenes + "_1");
        Scene_2.transform.GetChild(0).GetComponent<RawImage>().texture =
            (Texture) Resources.Load("sceneicons/" + _nameScenes + "_2");

        Button _sc_0 = Scene_0.AddComponent<Button>();
        _sc_0.onClick.AddListener(()=>LoadScene(_nameScenes+"_0"));
        Button _sc_1 = Scene_1.AddComponent<Button>();
        _sc_1.onClick.AddListener(()=>LoadScene(_nameScenes+"_1"));
        Button _sc_2 = Scene_2.AddComponent<Button>();
        _sc_2.onClick.AddListener(()=>LoadScene(_nameScenes+"_2"));
    }

    public void LoadScene(string _name)
    {
        SceneManager.LoadScene(_name);
    }

}
