using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToolController : MonoBehaviour
{
    [SerializeField]private Tools _tool;
    [SerializeField] private List<Tools> _pickaxes = new List<Tools>();

    public delegate void NewTool(Tools _tool);
    public static event NewTool _newtool;
    
    private void Start()
    {
        this.gameObject.GetComponent<Button>().onClick.AddListener(upgrade);
    }


    private void upgrade()
    {
       if (_tool)                    // UPGRADE PICKAXE
       {
           int _index = _pickaxes.IndexOf(_tool);
           if (_index + 1 <= _pickaxes.Count-1)
           {
               if (_pickaxes[_index + 1].Cost <= StaticManager.Money)
               {
                   _tool = _pickaxes[_index + 1];
                   _newtool?.Invoke(_tool);
               }
           }
       }
       else
       {
           _tool = _pickaxes[0];
           _newtool?.Invoke(_tool);
       } // BUY FIRST PICKAXE
    }
}
