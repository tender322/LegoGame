using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public GameObject FabIconsLegoGame;
    public Transform ContentScene;
    private List<string> ReadyScene = new List<string>(); 
    private List<string> CloseClose = new List<string>(); 
    private List<string> StartScenes =  new List<string>();

    LoadScenes LS = new LoadScenes();
    private void Start()
    {
        SaveNLoadLego SNL = gameObject.GetComponent<SaveNLoadLego>();
        
    }

    public void LoadEnding()
    {
        StartScenes.Add("LegoHome");
        ReadyScene = LS.GetScenesReady();
        CloseClose = LS.GetCloseScene();
        ReadySceneCreate();
    }


    private void ReadySceneCreate()
    {
        for (int i = 0; i < StartScenes.Count; i++)
        {
            Debug.Log("ISTANT");
            var _scene = Instantiate(FabIconsLegoGame, ContentScene);
            var _SB = _scene.AddComponent<SceneButton>();
            _SB.ControllButton(StartScenes[i],true);
        }
        
        for (int i = 0; i < ReadyScene.Count; i++)
        {
            Debug.Log("ISTANT2");
            var _scene = Instantiate(FabIconsLegoGame, ContentScene);
            var _SB = _scene.AddComponent<SceneButton>();
            _SB.ControllButton(ReadyScene[i],true);
        }
        
        for (int i = 0; i < CloseClose.Count; i++)
        {
            Debug.Log("ISTANT3");
            var _scene = Instantiate(FabIconsLegoGame, ContentScene);
            var _SB = _scene.AddComponent<SceneButton>();
            _SB.ControllButton(CloseClose[i],false);
        }
    }

    public void SetScenes(string _name, bool status)
    {
        if (status){ LS.SetSceneReady(_name);}
        else{LS.SetCloseScene(_name);}
    }
}
public class LoadScenes
{
    private  List<string> ReadyScene = new List<string>();
    private  List<string> CloseScene = new List<string>();

    public  List<string> GetScenesReady() { return ReadyScene; }
    public  void SetSceneReady(string _scene) { ReadyScene.Add(_scene); }

    public  List<string> GetCloseScene() { return CloseScene; }
    public  void SetCloseScene(string _scene){CloseScene.Add(_scene);}
   
}


