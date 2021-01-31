using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenes : MonoBehaviour
{
    private  List<string> ReadyScene = new List<string>();
    private  List<string> CloseScene = new List<string>();

    public  List<string> GetScenesReady() { return ReadyScene; }
    public  void SetSceneReady(string _scene) { ReadyScene.Add(_scene); }

    public  List<string> GetCloseScene() { return CloseScene; }
    public  void SetCloseScene(string _scene){CloseScene.Add(_scene);}
   
}
