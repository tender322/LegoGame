using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    [SerializeField] private String _Type;
    [SerializeField] private Transform Content;


    public delegate void SomeStep();
    public static event SomeStep _step;        // EVENT PROFIT
    private void Start()
    {
        if (_Type == "Mining")
        {
            foreach (Transform child in Content) { child.gameObject.AddComponent<Mine>(); } // ADD COMPONENT MINE FOR MINING
            
        }
        
        _refresh();
        Mine._refresh += _refresh;
    }


    public void _refresh() { _step?.Invoke(); }

    IEnumerator refresh()
    {
        yield return new WaitForSeconds(1f);
        _step?.Invoke();
    }
}
