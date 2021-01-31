using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollController : MonoBehaviour
{
    private List<GameObject> Legos = new List<GameObject>();

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

    public List<GameObject> GetObjects()
    {
        return Legos;
    }

    public void AddListLego(GameObject Lego, Color _color)
    {
        
        GameObject ico = Instantiate(IconFab, this.transform);
        var texture = Resources.Load("icons/" + Lego.tag);
        var icoObj = ico.GetComponent<RawImage>();
        icoObj.texture = (Texture) texture;
        icoObj.color = _color;
        Legos.Add(Lego);
    }

    public void SetActiveListLego(GameObject Lego,bool _active)
    {
        Lego.SetActive(_active);
        if (_active)
            Legos.Add(Lego);
        else
            Legos.Remove(Lego);
    }

    public void CreateStartField(Vector2 _vector)
    {
        if (StartField)
        {
            StartField = false;
            Vector2 center = _vector / 2;
            Vector2 start = center - _vector;
            var SF = GameObject.Find("StartField");
            for (int i = 0; i < _vector.x; i += 2)
            {
                for (int j = 0; j < _vector.y; j += 2)
                {
                    var lego = Instantiate((GameObject) Resources.Load("objects/Lego2x2"), SF.transform);
                    var _pos = new Vector3(start.x + i+1, 0, start.y + j+1);
                    lego.transform.position = _pos;
                }
            }
        }
    }

}
