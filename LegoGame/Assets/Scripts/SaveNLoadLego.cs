using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveNLoadLego : MonoBehaviour
{
    [SerializeField]private  LegoScene _legoScene = new LegoScene();

    private void Start()
    {
        SaveJson();
        LoadScene();
    }

    [ContextMenu("SaveJson")]
    public void SaveJson()
    {
        var _path = Application.persistentDataPath + "/LegoScenes.json";
        File.WriteAllText(_path,JsonUtility.ToJson(_legoScene));
    }
    [ContextMenu("LoadJson")]
    public void LoadJson()
    {
        var _path = Application.persistentDataPath + "/LegoScenes.json";
        _legoScene = JsonUtility.FromJson<LegoScene>(File.ReadAllText(_path));
    }
    
    public void LoadScene()
    { 
        LoadJson();
        var LS = gameObject.GetComponent<SceneController>();
       for (int i = 0; i < _legoScene._scenes.Count; i++)
       {
           bool _status = _legoScene._scenes[i]._status;
           if (_status)
           {
               LS.SetScenes(_legoScene._scenes[i]._SceneName, true);
           }
           else
           { LS.SetScenes(_legoScene._scenes[i]._SceneName, false); }
       }
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



