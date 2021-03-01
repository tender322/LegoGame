using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Mining", menuName = "Zone/Mining", order = 51)]
public class Mining : ScriptableObject
{
  [SerializeField] private string name;
  [SerializeField] private Image image;
  [SerializeField] private int level;
  [SerializeField] private int health;
  [SerializeField] private float profit;
  [SerializeField] private float cost;
  [SerializeField] private float bonus;
  [SerializeField] private bool statusbuy;
  [SerializeField] private bool statuswork;

  public string SetName
  { set => name = value; }

  public string Name => name;
  public Image Image => image;
  public int Level => level;
  public int Health => health;
  public float Profit => profit;
  public float Cost => cost;
  public float Bonus => bonus;
  public bool Statusbuy => statusbuy;

  public bool Statuswork
  { get => statuswork;
    set => statuswork = value; }
}
