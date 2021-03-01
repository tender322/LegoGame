using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Mining", menuName = "Zone/Tools", order = 51)]

public class Tools : ScriptableObject
{
    [SerializeField] private string name;
    [SerializeField] private Image image;
    [SerializeField] private int level;
    [SerializeField] private float speed;
    [SerializeField] private float cost;

    public string Name => name;
    public Image Image => image;
    public int Level => level;
    public float Speed => speed;
    public float Cost => cost;
}
