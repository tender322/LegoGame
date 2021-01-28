using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveNLoadLego : MonoBehaviour
{
    [SerializeField] private LegoScene _legoScene = new LegoScene();

    [ContextMenu("SaveJson")]
    public void SaveJson()
    {
        File.WriteAllText(Application.streamingAssetsPath+"/LegoScenes.json",JsonUtility.ToJson(_legoScene));
    }
    [ContextMenu("LoadJson")]
    public void LoadJson()
    {
        _legoScene = JsonUtility.FromJson<LegoScene>(File.ReadAllText(Application.streamingAssetsPath + "/LegoScenes.json"));
    }

    
    public void LoadScene(String SceneName)
    {
        ScrollController SC = GameObject.Find("Content").GetComponent<ScrollController>();
        
        
        foreach (var Legos in _legoScene.Scenes)
        {
            if (Legos.SceneName == SceneName)
            {
                foreach (var LegoObject in Legos.lego)
                {
                    SC.AddListLego(LegoObject.LegoObject,LegoObject.ColorName);
                    SC.CreateStartField(Legos.StartLegoCount_2);
                }
            }
        }
    }

}
[System.Serializable]
public class LegoScene
{
    public List<LegoScenesList> Scenes = new List<LegoScenesList>();
}

[System.Serializable]
public class LegoScenesList
{
    public string SceneName;
    public Vector2 StartLegoCount_2;
    public List<LegoLists> lego = new List<LegoLists>();
}
[System.Serializable]
public class LegoLists
{
    public GameObject LegoObject;
    public Color ColorName;
}
