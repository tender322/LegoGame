using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneGenerator : MonoBehaviour
{
    private GameObject Preview;
    public List<objects> _objectses = new List<objects>();
    
    void Start()
    {
        string _levelname = SelectLevel.getLevel();
        var preview = Instantiate(Resources.Load("levels/" + _levelname));
        Preview = (GameObject)preview;
        gameObject.GetComponent<CheckerLevel>().PreViewScen = (GameObject)preview;
        Vector2 field = Preview.GetComponent<LevelStats>().Field;
        GameObject.Find("StartField").GetComponent<GeneratorField>().GenerateField(field);
        GameObject.Find("StartField_1").GetComponent<GeneratorField>().GenerateField(field);
        gameObject.GetComponent<CheckerLevel>().BeforeLoadView();
        foreach (Transform d in Preview.transform)
        {
            objects v = new objects();
            v.lego = d.transform.gameObject;
            //v.color = d.GetChild(0).GetComponent<MeshRenderer>().material.color;
            v.color = d.GetComponent<Controller>().DefaultColor;
            _objectses.Add(v);
        }
        GenerateScene();
    }

    public void GenerateScene()
    {
        ScrollController SC = GameObject.Find("Content").GetComponent<ScrollController>();
        foreach (var LegoObject in _objectses)
        {
            SC.AddListLego(LegoObject.lego,LegoObject.color);
        }
    }


}

[System.Serializable]
public class objects
{
    public GameObject lego;
    public Color color;

}