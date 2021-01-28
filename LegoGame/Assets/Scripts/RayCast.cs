using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCast : MonoBehaviour
{

    
    public bool uses;
    public int _distance;
    public Color DefaultColor;
    public Color SelectColor;
    public float RayCastObjectY;
    
    private MeshRenderer MR;
    public GameObject _LO = null;
    private void Start()
    {
        MR = GetComponent<MeshRenderer>();
    }

    public void ChangePositionRayCastCheck()
    {
       
       Vector3 down = transform.TransformDirection(Vector3.down);
       RaycastHit hit;
       if (Physics.Raycast(this.transform.position, down, out hit, _distance))
       {
           if(_LO)
               _LO.gameObject.GetComponent<RayCast>().ChangeDefaultMaterial();
           hit.collider.gameObject.GetComponent<RayCast>().ChangeMaterial();
           RayCastObjectY = hit.collider.gameObject.GetComponent<Transform>().position.y;
           _LO = hit.collider.gameObject;
       }else
       {
           if(_LO)
                _LO.gameObject.GetComponent<RayCast>().ChangeDefaultMaterial();
           _LO = null;
           RayCastObjectY = 0;
       }
    }

    public void OffLego()
    {
        if(_LO)
            _LO.gameObject.GetComponent<RayCast>().ChangeDefaultMaterial();
    }
    
    public void ChangeMaterial()
    {
        MR.material.color = SelectColor;
    }

    public void ChangeDefaultMaterial()
    {
        MR.material.color = DefaultColor;
    }

}
