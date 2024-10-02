using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    public int id;
    public string nameItem;
    public string description;
    public Sprite image;
    public int hpGiven;
    public int speedGiven;
    public int JumpGiven;
    public float speedDuration;
    public float jumpDuration;
    public int price;
}
