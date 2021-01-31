using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveNLoadLego : MonoBehaviour
{
    [SerializeField]private  LegoScene _legoScene = new LegoScene();

    private void Start()
    {
        LoadScene();
    }

    [ContextMenu("SaveJson")]
    public void SaveJson(String name, bool status)
    {
        ScenesLegoClass SLC = new ScenesLegoClass();
        SLC._SceneName = name;
        SLC._status = status;
        _legoScene._scenes.Add(SLC);
        File.WriteAllText(Application.streamingAssetsPath +"/LegoScenes.json",JsonUtility.ToJson(_legoScene));
    }
    [ContextMenu("LoadJson")]
    public void LoadJson()
    {
        _legoScene = JsonUtility.FromJson<LegoScene>(File.ReadAllText(Application.streamingAssetsPath + "/LegoScenes.json"));
    }
    
    public void LoadScene()
    {
        LoadJson();
       //for (int i = 0; i < _legoScene._scenes.Count; i++)
       //{
       //    bool _status = _legoScene._scenes[i]._status;
       //    if (_status)
       //    { gameObject.GetComponent<Scenes>().SetSceneReady(_legoScene._scenes[i]._SceneName); }
       //    else
       //    { gameObject.GetComponent<Scenes>().SetCloseScene(_legoScene._scenes[i]._SceneName); }
       //}
        this.gameObject.GetComponent<SceneController>().LoadEnding();
        
    }

}
[System.Serializable]
public class LegoScene
{
    public List<ScenesLegoClass> _scenes = new List<ScenesLegoClass>();
}
[System.Serializable]
public class ScenesLegoClass
{
     public String _SceneName;
     public bool _status;

}



