using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    private GameManager GM;
    public GameObject Parent;
    
    private int[] CountCylinder;
    
    private bool Uses = true;
    public Color DefaultColor;
    
    public int c = 0;    // Определение кол-во цилиндров - точек


    void Start()
    {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
       
        foreach (Transform d in this.gameObject.transform)
        {
            d.GetComponent<MeshRenderer>().material.color = DefaultColor;
            if (d.transform.tag == "cylinder")
            {
                c++;
                d.gameObject.AddComponent<BoxCollider>();
                var dd = d.gameObject.AddComponent<RayCast>();
                dd.uses = Uses;
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


}
