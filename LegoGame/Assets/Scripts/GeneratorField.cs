using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorField : MonoBehaviour
{
    public void GenerateField(Vector2 _vector)
    {
        GameObject field = (GameObject)Resources.Load("objects/Lego2x2");
        field.GetComponent<Controller>().DefaultColor = Color.green;
        float startposX = -_vector.x + 1;
        float startposY = -_vector.y + 1;
        
        if (_vector.x % 2 == 0)
        {
            startposX = -_vector.x + 1;
            if (_vector.y % 2 == 0)
            { startposY = -_vector.y + 1; }
            else
            { startposY = -_vector.y + .5f; this.gameObject.transform.position += new Vector3(0,0,0.5f);}
        }
        else
        {
            startposX = -_vector.x + .5f;
            this.gameObject.transform.position += new Vector3(0,0,0.5f);
            if (_vector.y % 2 == 0)
            { startposY = -_vector.y + 1; }
            else
            { startposY = -_vector.y + .5f;this.gameObject.transform.position += new Vector3(0,0,0.5f); }
        }
        for (int i = 0; i < _vector.x; i++)
        {
            for (int j = 0; j < _vector.y; j++)
            {
                var child = Instantiate(field, this.gameObject.transform);
                Vector2 _pos = new Vector2(startposX + (2 * i),startposY + (2 * j));
                child.transform.localPosition = new Vector3(_pos.x,0,_pos.y);
            }
        }
    }


}
