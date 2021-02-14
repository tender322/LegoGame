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
        ScenesCompleted.LoadCompleted();
        MainWindow.SetActive(true);
        ScrollCanvas.SetActive(false);
        Text _sctext0 = Scene_0.transform.GetChild(1).GetChild(0).GetComponent<Text>();
        Text _sctext1 = Scene_1.transform.GetChild(1).GetChild(0).GetComponent<Text>();
        Text _sctext2 = Scene_2.transform.GetChild(1).GetChild(0).GetComponent<Text>();
        Scene_0.transform.GetChild(0).GetComponent<RawImage>().texture =
            (Texture) Resources.Load("sceneicons/" + _nameScenes + "_0");
        _sctext0.text = "НАЧАТЬ";
        Scene_1.transform.GetChild(0).GetComponent<RawImage>().texture =
            (Texture) Resources.Load("sceneicons/" + _nameScenes + "_1");
        _sctext1.text = "НАЧАТЬ";
        Scene_2.transform.GetChild(0).GetComponent<RawImage>().texture =
            (Texture) Resources.Load("sceneicons/" + _nameScenes + "_2");
        _sctext2.text = "НАЧАТЬ";

        Button _sc_0 = Scene_0.GetComponent<Button>();
        _sc_0.onClick.AddListener(()=>LoadScene(_nameScenes+"_0"));
        Button _sc_1 = Scene_1.GetComponent<Button>();
        _sc_1.onClick.AddListener(()=>LoadScene(_nameScenes+"_1"));
        Button _sc_2 = Scene_2.GetComponent<Button>();
        _sc_2.onClick.AddListener(()=>LoadScene(_nameScenes+"_2"));

        if (ScenesCompleted.GetBoolCompleted(_nameScenes + "_0"))
        { _sctext0.text = "ЗАВЕРШЕНО"; _sctext0.GetComponentInParent<Image>().color = Color.green; }
        if (ScenesCompleted.GetBoolCompleted(_nameScenes + "_1"))
        { _sctext0.text = "ЗАВЕРШЕНО"; _sctext1.GetComponentInParent<Image>().color = Color.green; }
        if (ScenesCompleted.GetBoolCompleted(_nameScenes + "_2"))
        { _sctext0.text = "ЗАВЕРШЕНО"; _sctext2.GetComponentInParent<Image>().color = Color.green; }

    }

    public void LoadScene(string _name)
    {
        SceneManager.LoadScene(_name);
    }

}
