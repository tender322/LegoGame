using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCast : MonoBehaviour
{

    
    public bool busy;
    public int _distance;
    public Color DefaultColor;
    public Color SelectColor;
    public float RayCastObjectY;
    
    private MeshRenderer MR;
    public GameObject _LO = null;
    private void Start()
    {
        busy = false;
        if(GetComponent<MeshRenderer>())
            MR = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        Vector3 down = transform.TransformDirection(Vector3.down);
        RaycastHit hit;
        if (Physics.Raycast(this.transform.position, down, out hit, _distance))
        {
            Debug.DrawRay(transform.position, down, Color.red);
        }
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
           if (hit.collider.gameObject.GetComponent<RayCast>().busy)
               RayCastObjectY = 0;
           _LO = hit.collider.gameObject;
       }else
       {
           if(_LO)
                _LO.gameObject.GetComponent<RayCast>().ChangeDefaultMaterial();
           _LO = null;
           RayCastObjectY = 0;
       }
    }

    public void SetBusy()
    {
        _LO.GetComponent<RayCast>().ChangeBusy();
        _LO.GetComponent<BoxCollider>().enabled = false;
        
    }

    public void ChangeBusy()
    {
        busy = true;
    }

    public void OffLego()
    {
        if(_LO)
            _LO.gameObject.GetComponent<RayCast>().ChangeDefaultMaterial();
    }

    

    public void ChangeMaterial()
    {
        if(gameObject.GetComponent<MeshRenderer>())
            MR.material.color = SelectColor;
    }

    public void ChangeLastLego()
    {
        if(_LO)
            _LO.GetComponent<RayCast>().ChangeDefaultMaterial();
    }

    public void ChangeDefaultMaterial()
    {
        if(gameObject.GetComponent<MeshRenderer>())
            MR.material.color = DefaultColor;
    }

}
