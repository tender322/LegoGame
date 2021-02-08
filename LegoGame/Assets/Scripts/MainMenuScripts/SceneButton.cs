using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneButton : MonoBehaviour
{
    public bool StatusScene;
    public string SceneLoad;
    void Start()
    {
      
        this.gameObject.GetComponent<Button>().onClick.AddListener(LoadScene);
    }
    public void ControllButton(string _scene, bool status)
    {
        SceneLoad = _scene;
        StatusScene = status;
        transform.GetChild(0).GetChild(0).GetComponent<Text>().text = _scene;
        transform.GetChild(1).GetComponent<RawImage>().texture = (Texture)Resources.Load("sceneicons/"+_scene);
        //transform.GetChild(0).GetComponent<Text>().text = _scene;
        //this.gameObject.GetComponent<RawImage>().texture = (Texture)Resources.Load("sceneicons/"+_scene);
        if (!status)
        {
            this.gameObject.GetComponent<RawImage>().color = Color.gray;
        }
    }
    public void LoadScene()
    {
        if (StatusScene)
        {
            SceneManager.LoadScene(SceneLoad);
        }
    }
}
