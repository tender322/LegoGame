using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    private GameManager GM;
    public GameObject Parent;
    
    private int[] CountCylinder;
    
    private Color DefaultColor;
    
    public int c = 0;    // Определение кол-во цилиндров - точек


    void Start()
    {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        DefaultColor = transform.GetChild(0).GetComponent<MeshRenderer>().material.color;
       
        foreach (Transform d in this.gameObject.transform)
        {
            if(d.GetComponent<MeshRenderer>())
                d.GetComponent<MeshRenderer>().material.color = DefaultColor;
            if (d.transform.tag == "cylinder")
            {
                c++;
                d.gameObject.AddComponent<BoxCollider>();
                var dd = d.gameObject.AddComponent<RayCast>();
                dd._distance = GM._distance;
                dd.SelectColor = GM.SelectColor;
                dd.DefaultColor = DefaultColor;
            }

            if (d.transform.tag == "ended")
            {
                var dd = d.gameObject.AddComponent<RayCast>();
                dd._distance = GM._distance;
                dd.SelectColor = GM.SelectColor;
                dd.DefaultColor = DefaultColor;
            }
        }
        CountCylinder = new int[c];
    }

    public void ChangePositionRayCast()
    {
        foreach (Transform child in this.gameObject.transform)
        {
            if (child.tag == "cylinder")
            {
                child.GetComponent<RayCast>().ChangePositionRayCastCheck();
            }
        }
    }

    public void PasteLego()
    {
        foreach (Transform child in this.gameObject.transform)
        {
            if (child.tag == "cylinder")
            {
                child.GetComponent<RayCast>().OffLego();
            }
        }
    }

    public void SetDefaultColor(Color _color) { DefaultColor = _color; }

}
