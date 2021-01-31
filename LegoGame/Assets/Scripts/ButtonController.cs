using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    private LegoController LC;
    private GameManager GM;
    private void Start()
    {
        var name = this.gameObject.GetComponent<RawImage>().texture.name;
        this.gameObject.GetComponent<Button>().onClick.AddListener(()=>InstantiateLego(name));
        LC = GameObject.FindObjectOfType<LegoController>();
        GM = GameObject.FindObjectOfType<GameManager>();
    }

    public void repeatInstaniateLego()
    {
        var name = this.gameObject.GetComponent<RawImage>().texture.name;
        InstantiateLego(name);
    }

    public void InstantiateLego(String name)
    {
        CheckerLego();
        var _color = this.gameObject.GetComponent<RawImage>().color;
        var _ref = Resources.Load("objects/" + name);
        var _obj = Instantiate((GameObject)_ref);
        _obj.transform.position = GM.DefualtPosition;
        foreach (Transform c in _obj.transform)
        {
            if(c.GetComponent<MeshRenderer>())
                c.GetComponent<MeshRenderer>().material.color = _color;
        }
        _obj.GetComponent<Controller>().SetDefaultColor(_color);
        _obj.GetComponent<Controller>().Parent = this.gameObject;
        LC.ActiveLego = _obj;
    }

    
    public void CheckerLego()
    {
        if (LC.ActiveLego)
        {
            LC.ActiveLego.gameObject.GetComponent<Controller>().DeleteDefaultColor();
            Destroy(LC.ActiveLego.gameObject);
        }
    }
    
}
