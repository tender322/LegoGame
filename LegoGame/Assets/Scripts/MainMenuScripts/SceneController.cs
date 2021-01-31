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


    private void Start()
    {
        SaveNLoadLego SNL = gameObject.GetComponent<SaveNLoadLego>();
       // SNL.SaveJson();
    }

    public void LoadEnding()
    {
        StartScenes.Add("LegoHome");
        //Scenes SC = gameObject.GetComponent<Scenes>();
        //ReadyScene = SC.GetScenesReady();
        //CloseClose = SC.GetCloseScene();
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
            var _scene = Instantiate(FabIconsLegoGame, ContentScene);
            var _SB = _scene.AddComponent<SceneButton>();
            _SB.ControllButton(CloseClose[i],false);
        }
    }
}


