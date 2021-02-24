using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CheckerLevel : MonoBehaviour
{
    public GameObject PreViewScen;
    public GameObject StartScene;
    [SerializeField]private List<_onilelego> PreViewList = new List<_onilelego>();
    [SerializeField]private List<_onilelego> OnlineViewList = new List<_onilelego>();
    private int _procent;
    private int alllegocount;

    private GameManager GM;
    private void Start()
    {
        GM = GameObject.FindObjectOfType<GameManager>();
    }

    public void BeforeLoadView()
    {
        _procent = 0;
        foreach (Transform child in PreViewScen.transform)
        {
            _onilelego _child = new _onilelego();
            _child._objtag = child.gameObject.tag;
            _child._pos = child.transform.localPosition;
            PreViewList.Add(_child);
        }
    }

    public void LevelCheck()
    {
        Debug.Log("LEVELCHECK");
        _procent = 0;
        alllegocount = StartScene.transform.childCount;
        foreach (Transform child in StartScene.transform)
        {
            Debug.Log("TRYTOCHECK");
            var _check = PreViewList.Any(x => x._objtag == child.tag && 
                                              (x._pos.x == child.transform.localPosition.x && x._pos.z == child.transform.localPosition.z));
            if (_check)
            {Debug.Log("CHECKTRUE ++");
                _procent++;
            }
        }
    }

    private void Update()
    {
        if (_procent > alllegocount * .75f)
        {
            Debug.Log("PROCENT > *.75f");
            GM.Ended();
        }
    }
}

public class _onilelego
{
    public string _objtag;
    public Vector3 _pos;
}