using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundScript : MonoBehaviour
{
    public Color _Color;

    void Start()
    {
        foreach (Transform firstparent in this.gameObject.transform)
        {
            foreach (Transform second in firstparent.transform)
            {
                foreach (Transform child in second.transform)
                {
                    child.GetComponent<MeshRenderer>().material.color = _Color;
                }
            }
        }
        InvokeRepeating("changelerpcamera",1f,5f);
        
    }


    public void changelerpcamera()
    {
        Vector3 _target = new Vector3(Random.Range(-9,3),Random.Range(1,13),-10f);
        StartCoroutine(LerpPosition(Camera.main,_target,5f));

    }
    
    IEnumerator LerpPosition(Camera Lego, Vector3 _target, float duration)
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
