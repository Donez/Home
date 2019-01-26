using System;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    // public event Action
    public HashSet<Item> Items;

    public bool TryAdd(Item item)
    {
        return Items.Add(item);
    }
}
