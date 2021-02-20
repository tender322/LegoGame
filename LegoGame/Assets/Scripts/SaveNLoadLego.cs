using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveNLoadLego : MonoBehaviour
{
    [SerializeField]private  LegoScene _legoScene = new LegoScene();

    private void Start()
    {
        LoadScene();
    }

    [ContextMenu("SaveJson")]
    public void SaveJson()
    {
        var _path = Application.persistentDataPath + "/LegoScenes.dat";
        //File.WriteAllText(_path,JsonUtility.ToJson(_legoScene));
        BinaryFormatter bf = new BinaryFormatter();
        FileStream fs = File.Open(_path, FileMode.OpenOrCreate);
        bf.Serialize(fs,_legoScene);
        fs.Close();
    }
    [ContextMenu("LoadJson")]
    public void LoadJson()
    {
        var _path = Application.persistentDataPath + "/LegoScenes.dat";
        //_legoScene = JsonUtility.FromJson<LegoScene>(File.ReadAllText(_path));
        if (File.Exists(_path))
        {
            using (Stream stream = File.Open(_path, FileMode.Open))
            {
                
                var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                Debug.Log("STARTFDH");
                _legoScene = (LegoScene)bformatter.Deserialize(stream);
                Debug.Log("ENDLOADJSNO");
            }
        }else{SaveJson();}
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
       Debug.Log("LOADSCENE");
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



