using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StaticManager
{
    [SerializeField] public static float speed;

    [SerializeField] private static float _money;


    public static float Money
    {
        get => _money;
        set => _money = value;
    }
}
