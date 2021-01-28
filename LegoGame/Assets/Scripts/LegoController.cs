using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegoController : MonoBehaviour
{
    public GameObject ActiveLego;
    private ScrollController SC;
    
    
    private GameManager GM;
    private Vector3 _lp; // Last Position PC
    private Vector2 _mlp; // Last Position Mobile
    private Vector3[] frame = new Vector3[2];
    bool _next = false;
    private void Start()
    {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        SC = GameObject.FindObjectOfType<ScrollController>();
    }

    public int CamRotation()
    {
        Transform CamRot = Camera.main.transform;
        if (CamRot.eulerAngles.y >= 0 && CamRot.eulerAngles.y < 45)
            return 0;
        if (CamRot.eulerAngles.y >= 45 && CamRot.eulerAngles.y < 135)
            return 1;
        if (CamRot.eulerAngles.y >= 135 && CamRot.eulerAngles.y < 225)
            return 2;
        if (CamRot.eulerAngles.y >= 225 && CamRot.eulerAngles.y < 315)
            return 3;
        else return -1;
    }

    private void Update()
    {
        if (!GM.GetControllLego())
        {
            if (ActiveLego)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    if (Input.mousePosition.y > Screen.height / 6)
                    {
                        _lp = Input.mousePosition;
                        _next = true;
                    }
                }
                else if (Input.GetMouseButton(0))
                {
                    if (_next)
                    {
                        Vector3 delta = (Input.mousePosition - _lp); // DELTA
                        delta *= GM.sensitivity;
                        Vector3 _pos = new Vector3();
                        int checkRot = CamRotation();

                        if (delta.x > .75f)
                        {
                            _pos = new Vector3(1, 0, 0);
                            _lp = Input.mousePosition;
                        }
                        else if (delta.x < -.75f)
                        {
                            _pos = new Vector3(-1, 0, 0);
                            _lp = Input.mousePosition;
                        }

                        if (delta.y > .75f)
                        {
                            _pos = new Vector3(0, 0, 1);
                            _lp = Input.mousePosition;
                        }
                        else if (delta.y < -.75f)
                        {
                            _pos = new Vector3(0, 0, -1);
                            _lp = Input.mousePosition;
                        }

                        Vector3 intern = _pos;
                        switch (checkRot)
                        {
                            case 1:
                                _pos.x = intern.z;
                                _pos.z = -intern.x;
                                break;
                            case 2:
                                _pos.x = -intern.x;
                                _pos.z = -intern.z;
                                break;
                            case 3:
                                _pos.x = -intern.z;
                                _pos.z = intern.x;
                                break;
                        }

                        ActiveLego.transform.position += _pos;
                        ActiveLego.GetComponent<Controller>().ChangePositionRayCast();
                    }
                }
                else if (Input.GetMouseButtonUp(0))
                {
                    _next = false;
                }

                //if (Input.touchCount > 0)
                //{
                //    Touch touch = Input.GetTouch(0);
                //    switch (touch.phase)
                //    {
                //        case TouchPhase.Began:
                //            if (touch.position.y > Screen.height / 6)
                //            {
                //                _mlp = touch.position;
                //                _next = true;
                //            }
                //            break;
                //        case TouchPhase.Moved:
                //            if (_next)
                //            {
                //                Vector3 delta = (touch.position - _mlp); // DELTA
                //                delta *= GM.sensitivity;
                //                Vector3 _pos = new Vector3();
                //                int checkRot = CamRotation();

                //                if (delta.x > .75f)
                //                {
                //                    _pos= new Vector3(1, 0, 0);
                //                    _mlp = touch.position;
                //                }
                //                else if (delta.x < -.75f)
                //                {
                //                    _pos= new Vector3(-1, 0, 0);
                //                    _mlp = touch.position;
                //                }

                //                if (delta.y > .75f)
                //                {
                //                    _pos= new Vector3(0, 0, 1);
                //                    _mlp = touch.position;
                //                }
                //                else if (delta.y < -.75f)
                //                {
                //                    _pos= new Vector3(0, 0, -1);
                //                    _mlp = touch.position;
                //                }
                //                Vector3 intern = _pos;
                //                switch (checkRot)
                //                {
                //                    case 1:
                //                        _pos.x = intern.z;
                //                        _pos.z = -intern.x;
                //                        break;
                //                    case 2:
                //                        _pos.x = -intern.x;
                //                        _pos.z = -intern.z;
                //                        break;
                //                    case 3:
                //                        _pos.x = -intern.z;
                //                        _pos.z = intern.x;
                //                        break;
                //                }
                //                ActiveLego.transform.position += _pos;
                //                ActiveLego.GetComponent<Controller>().ChangePositionRayCast();
                //            }
                //            break;
                //        case TouchPhase.Ended:
                //            _next = false;
                //            break;
                //    }
                //}
            }
        }
    }

    public void LegoPaste()
    {
        if (ActiveLego)
        {
            float MinDistance = -Mathf.Infinity;
            bool next = false;
            foreach (Transform d in ActiveLego.gameObject.transform)
            {
                if (d.transform.tag == "cylinder")
                {
                    if (d.GetComponent<RayCast>().RayCastObjectY != 0 )
                    {
                        if (MinDistance < d.GetComponent<RayCast>().RayCastObjectY)
                        {
                            MinDistance = d.GetComponent<RayCast>().RayCastObjectY;
                            next = true;
                        }
                    }

                    d.GetComponent<RayCast>().SetBusy();
                }

            }

            if (next)
            {
                var delta = ActiveLego.transform.position.y - MinDistance;

                Vector3 _target = new Vector3(ActiveLego.transform.position.x,
                    ActiveLego.transform.position.y - delta,
                    ActiveLego.transform.position.z);
                StartCoroutine(LerpPosition(ActiveLego, _target, GM.SpeedPlace));
                //ActiveLego.GetComponent<Controller>().Parent.SetActive(false);
                SC.SetActiveListLego(ActiveLego.GetComponent<Controller>().Parent,false);
                ActiveLego.GetComponent<Controller>().PasteLego();
                ActiveLego = null;
            }
        }
    }

    public void ChangeRotation()
    {
        if (ActiveLego)
        {
            ActiveLego.transform.eulerAngles += new Vector3(0, 90, 0);
            ActiveLego.GetComponent<Controller>().ChangePositionRayCast();
        }
    }
    
    
    IEnumerator LerpPosition(GameObject Lego, Vector3 _target, float duration)
    {
        float time = 0;
        Vector3 _object = Lego.transform.position;
        while (time < duration)
        {
            Lego.transform.position = Vector3.Lerp(_object, _target, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        Lego.transform.position = _target;
    }
}
