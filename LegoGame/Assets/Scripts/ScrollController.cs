using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollController : MonoBehaviour
{
    public List<GameObject> Legos = new List<GameObject>();

    public GameObject IconFab;
    private bool StartField;

    private void Start()
    {
        StartField = true;
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
        
    }

    public void Checker()
    {
        if(Legos.Count < 4)
            GameObject.FindObjectOfType<CheckerLevel>().LevelCheck();
    }


    public List<GameObject> GetObjects()
    {
        return Legos;
    }

    public void AddListLego(GameObject Lego, Color _color)
    {
        GameObject ico = Instantiate(IconFab, this.transform);
        ico.name = Lego.name;
        var texture = Resources.Load("icons/" + Lego.tag);
        var icoObj = ico.GetComponent<RawImage>();
        icoObj.texture = (Texture) texture;
        icoObj.color = _color;
        Legos.Add(Lego);
    }
    
    public void SetActiveListLego(GameObject Lego,bool _active)
    {
        Lego.SetActive(_active);
        for (int i = 0; i < Legos.Count; i++)
        {
            if (Legos[i].name == Lego.name)
            {
                if (_active)
                    Legos.Add(Legos[i]);
                else
                    Legos.Remove(Legos[i]);
            }
        }
        
    }
}
