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
    public Transform busyObject;
    
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

    public Collider FilterRayCast(RaycastHit[] hits)
    {
        if (hits.Length > 0)
        {
            List<RaycastHit> FilteredRay = new List<RaycastHit>();
            for (int i = 0; i < hits.Length; i++)
            {
                if (!hits[i].transform.gameObject.GetComponent<Controller>())
                {
                    FilteredRay.Add(hits[i]);
                }
            }


            if (FilteredRay.Count > 0)
            {
                float maxRayPosition = FilteredRay[0].transform.position.y;
                RaycastHit maxRayCast = FilteredRay[0];
                for (int i = 0; i < FilteredRay.Count; i++)
                {
                    if (maxRayPosition > FilteredRay[i].transform.position.y)
                    {
                        maxRayPosition = FilteredRay[i].transform.position.y;
                        maxRayCast = FilteredRay[i];
                    }
                }
                return maxRayCast.collider;
            }
          
        }
        return null;
    }

    public void ChangePositionRayCastCheck()
    {
       
       Vector3 down = transform.TransformDirection(Vector3.down);
       RaycastHit[] hits;
       hits = Physics.RaycastAll(transform.position, down, _distance);
       Collider hit = FilterRayCast(hits);

       if (hit != null)
       {
           if (_LO) { _LO.gameObject.GetComponent<RayCast>().ChangeDefaultMaterial(); }

           hit.gameObject.GetComponent<RayCast>().ChangeMaterial();
           RayCastObjectY = hit.gameObject.GetComponent<Transform>().position.y;
           if (hit.gameObject.GetComponent<RayCast>().busy)
               RayCastObjectY = 0;
           _LO = hit.gameObject;
       }
       if(hit == null)
       {
           if (_LO) { _LO.gameObject.GetComponent<RayCast>().ChangeDefaultMaterial(); }
           _LO = null;
           RayCastObjectY = 0;
       }



       //RaycastHit hit;
       //if (Physics.Raycast(this.transform.position, down, out hit, _distance))
       //{
       //    
       //        if (_LO)
       //            _LO.gameObject.GetComponent<RayCast>().ChangeDefaultMaterial();
       //        hit.collider.gameObject.GetComponent<RayCast>().ChangeMaterial();
       //        RayCastObjectY = hit.collider.gameObject.GetComponent<Transform>().position.y;
       //        if (hit.collider.gameObject.GetComponent<RayCast>().busy)
       //            RayCastObjectY = 0;
       //        _LO = hit.collider.gameObject;
       //}else
       //{
       //    if (_LO)
       //            _LO.gameObject.GetComponent<RayCast>().ChangeDefaultMaterial();
       //        _LO = null;
       //        RayCastObjectY = 0;
       //    
       //}
    }


    public void DefualtLegoComponent()
    {
        busy = false;
        GetComponent<BoxCollider>().enabled = true;
    }

    public void SetBusy()
    {
        _LO.GetComponent<RayCast>().ChangeBusy();
        _LO.GetComponent<RayCast>().busyObject = this.gameObject.transform;
        _LO.GetComponent<BoxCollider>().enabled = false;
        this.gameObject.GetComponentInParent<Controller>().ActiveBusyObjects.Add(_LO.transform);
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
