using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    private GameManager GM;
    public GameObject Parent;
    public GameObject DontChange;
    public bool _pasteobject;
    
    private int[] CountCylinder;
    
    private Color DefaultColor;

    private List<Transform> ActiveRaycast = new List<Transform>();
    
    public int c = 0;    // Определение кол-во цилиндров - точек

    public List<Transform> ActiveBusyObjects = new List<Transform>();


    void Start()
    {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        DefaultColor = transform.GetChild(0).GetComponent<MeshRenderer>().material.color;
       
        foreach (Transform d in this.gameObject.transform)
        {
            if (d.GetComponent<MeshRenderer>())
            {
                if(d.gameObject.tag != "DontChangeColor")
                    d.GetComponent<MeshRenderer>().material.color = DefaultColor;
            }

            if (d.transform.tag == "cylinder")
            {
                c++;
                d.gameObject.AddComponent<BoxCollider>();
                var dd = d.gameObject.AddComponent<RayCast>();
                dd._distance = GM._distance;
                dd.SelectColor = GM.SelectColor;
                dd.DefaultColor = DefaultColor;
                ActiveRaycast.Add(d);
            }

            if (d.transform.tag == "ended")
            {
                c++;
                d.gameObject.AddComponent<BoxCollider>();
                d.gameObject.GetComponent<BoxCollider>().enabled = false;
                var dd = d.gameObject.AddComponent<RayCast>();
                dd._distance = GM._distance;
                dd.SelectColor = GM.SelectColor;
                dd.DefaultColor = DefaultColor;
                ActiveRaycast.Add(d);
            }
        }
        CountCylinder = new int[c];


        if (DontChange)
        {
            if(gameObject.tag=="misk")
                DontChange.GetComponent<MeshRenderer>().material.color = new Color(87/255f,26/255f,0f,255f);
        }
    }

    public void ChangePositionRayCast()
    {
        foreach (Transform child in this.gameObject.transform)
        {
            if (child.tag == "cylinder")
            {
                child.GetComponent<RayCast>().ChangePositionRayCastCheck();
            }
            if (child.tag == "ended")
            {
                child.GetComponent<RayCast>().ChangePositionRayCastCheck();
            }
        }
    }

    public void DeleteDefaultColor()
    { 
        foreach (Transform child in this.gameObject.transform)
        {
            if (child.tag == "cylinder")
            {
                child.GetComponent<RayCast>().ChangeLastLego();
            }
            if (child.tag == "ended")
            {
                child.GetComponent<RayCast>().ChangeLastLego();
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
            if (child.tag == "ended")
            {
                child.GetComponent<RayCast>().OffLego();
            }
        }
    }
    

    public void SetDefaultColor(Color _color) { DefaultColor = _color; }
    

}
