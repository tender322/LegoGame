using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mine : MonoBehaviour
{
    [SerializeField] private Mining _mining;
    [SerializeField] private Tools _tool ;
    private float timer = 0;

    public delegate void refresh();
    public static event refresh _refresh;


    void Start()
    {
        Controller._step += Profit;
        ToolController._newtool += upgradetool;
        _mining = (Mining) Resources.Load("mining/" + this.gameObject.name);

        if (_mining.Name != "Empty")
        {
            if (_mining.Statuswork)
            {
                gameObject.transform.GetChild(1).GetComponent<Text>().text = _mining.Profit.ToString();
                Destroy(gameObject.transform.GetChild(2));
            }
            else if (_mining.Statusbuy && !_mining.Statuswork)
            {
                gameObject.transform.GetChild(0).gameObject.SetActive(false);
                gameObject.transform.GetChild(1).gameObject.SetActive(false);
                this.gameObject.GetComponent<Button>().onClick.AddListener(buymine);
            }
            else
            {
                gameObject.transform.GetChild(0).gameObject.SetActive(false);
                gameObject.transform.GetChild(1).gameObject.SetActive(false);
                gameObject.transform.GetChild(2).gameObject.SetActive(false);
            }

            Profit();
        }
    }


    private void Update()
    {
        if (_mining)
        {
            if (_mining.Statuswork)
            {
                if (_tool)
                {
                    timer -= Time.deltaTime;
                    if (timer < 0)
                    {
                        timer = _mining.Health / _tool.Speed;
                    }
                }
            }
        }
    }

    private void upgradetool(Tools _tool) { this._tool = _tool; }

    private void buymine()
    {
        if (_mining.Cost <= StaticManager.Money)
        {
            _mining.Statuswork = true;
            _refresh?.Invoke();
        }
    }

    public void Profit()
    {
        var _color = this.gameObject.GetComponent<Image>();
        if (_mining)
        {
           
            var parent = transform.parent;
            int index = transform.GetSiblingIndex();
            if (index == 0) { index = 1; } // ОШИБКА 0
            if (!parent.GetChild(index - 1).GetComponent<Mine>()._mining.Statusbuy)  // ЧЕРНЫЙ закрытый
            { _color.color = Color.black; }
            else if (parent.GetChild(index - 1).GetComponent<Mine>()._mining.Statusbuy && !this._mining.Statusbuy) // Серый недоотрыктый
            { _color.color = Color.gray; }
            else
            { _color.color = Color.white; }    // Белый открытый
        }
    }  

}
