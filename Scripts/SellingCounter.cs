using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellingCounter : MonoBehaviour
{
    public int itemPrice = 5;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Customer"))
        {
            // Assume 1 item sold
            Debug.Log("Customer bought an item for $" + itemPrice);
            Destroy(other.gameObject); // Customer leaves
        }
    }
}

