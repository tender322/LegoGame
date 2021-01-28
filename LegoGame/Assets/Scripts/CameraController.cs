using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameManager GM;
    public JoyStick JS;
    public Transform StartField;

    void Update()
    {
        transform.LookAt(StartField, Vector3.up);

        Vector2 _pos = new Vector2(JS.Horizontal(), JS.Vertical());

        float deltaX = 0;
        float deltaY = 0;
        if (_pos.x > .5f)
        {
            deltaX = -1;
        }
        else if (_pos.x < -.5f)
        {
            deltaX = 1;
        }

        if (_pos.y > .5f)
        {
            deltaY = -1;
        }else if (_pos.y < -.5f)
        {
            deltaY = 1;
        }
        transform.RotateAround(StartField.transform.position,Vector3.up, deltaX*GM.sensivity_cam);
        transform.RotateAround(StartField.transform.position,transform.right, deltaY*-GM.sensivity_cam);

    }
}
