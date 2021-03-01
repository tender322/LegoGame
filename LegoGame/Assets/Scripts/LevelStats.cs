using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelStats : MonoBehaviour
{
    public Vector2 Field;


    private void Start()
    {
        foreach (Transform child in this.gameObject.transform)
        {
            if (child.GetComponent<Controller>())
            {
                Destroy(child.GetComponent<Controller>());
            }

            CheckChild(child);   
        }
    }

    public void CheckChild( Transform parent)
    {
        if (parent.childCount > 0)
        {
            foreach (Transform child in parent)
            {
                CheckChild(child);
            }
        }
        else
        {
            if (parent.GetComponent<Controller>())
            {
                Destroy(parent.GetComponent<Controller>());Destroy(parent.GetComponent<Controller>());
            }else if (parent.GetComponent<RayCast>())
            {
                Destroy(parent.GetComponent<RayCast>());Destroy(parent.GetComponent<RayCast>());
            }
        }
    }
}
