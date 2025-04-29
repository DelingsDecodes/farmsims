using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Storage : MonoBehaviour
{
    public List<string> storedItems = new List<string>();

    public void StoreItem(string itemName)
    {
        storedItems.Add(itemName);
        Debug.Log(itemName + " stored in storage!");
    }
}
