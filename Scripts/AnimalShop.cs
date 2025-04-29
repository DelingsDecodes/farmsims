using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalShop : MonoBehaviour
{
    public GameObject chickenPrefab;
    public GameObject cowPrefab;
    public GameObject goatPrefab;

    public Transform chickenSpawnPoint;
    public Transform cowSpawnPoint;
    public Transform goatSpawnPoint;

    private int chickenPrice = 50;
    private int cowPrice = 200;
    private int goatPrice = 150;

    private bool cowsUnlocked = false;
    private bool goatsUnlocked = false;

    private bool isPlayerNear = false;

    private void Update()
    {
        if (isPlayerNear && Input.GetKeyDown(KeyCode.E))
        {
            OpenShop();
        }
    }

    void OpenShop()
    {
        Debug.Log("=== Animal Shop ===");

        Debug.Log("1. Buy Chicken ($" + chickenPrice + ")");

        if (cowsUnlocked)
            Debug.Log("2. Buy Cow ($" + cowPrice + ")");
        else
            Debug.Log("2. Buy Cow (Locked)");

        if (goatsUnlocked)
            Debug.Log("3. Buy Goat ($" + goatPrice + ")");
        else
            Debug.Log("3. Buy Goat (Locked)");

        Debug.Log("Press 1, 2 or 3 to buy an animal");

        // Start listening for input
        StartCoroutine(WaitForAnimalSelection());
    }

    IEnumerator WaitForAnimalSelection()
    {
        bool boughtSomething = false;

        while (!boughtSomething)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                TryBuyChicken();
                boughtSomething = true;
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                if (cowsUnlocked)
                {
                    TryBuyCow();
                    boughtSomething = true;
                }
                else
                {
                    Debug.Log("Cows are locked!");
                }
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                if (goatsUnlocked)
                {
                    TryBuyGoat();
                    boughtSomething = true;
                }
                else
                {
                    Debug.Log("Goats are locked!");
                }
            }
            yield return null;
        }
    }

    void TryBuyChicken()
    {
        if (MoneyManager.instance.SpendMoney(chickenPrice))
        {
            Instantiate(chickenPrefab, chickenSpawnPoint.position, Quaternion.identity);
            chickenPrice += 50; // Increase price for next chicken
            Debug.Log("Chicken bought!");
        }
    }

    void TryBuyCow()
    {
        if (MoneyManager.instance.SpendMoney(cowPrice))
        {
            Instantiate(cowPrefab, cowSpawnPoint.position, Quaternion.identity);
            cowPrice += 100; // Increase price for next cow
            Debug.Log("Cow bought!");
        }
    }

    void TryBuyGoat()
    {
        if (MoneyManager.instance.SpendMoney(goatPrice))
        {
            Instantiate(goatPrefab, goatSpawnPoint.position, Quaternion.identity);
            goatPrice += 75; // Increase price for next goat
            Debug.Log("Goat bought!");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = true;
            Debug.Log("Press E to open Animal Shop");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = false;
        }
    }

    // Unlock functions for later progression
    public void UnlockCows()
    {
        cowsUnlocked = true;
        Debug.Log("Cows are now available to buy!");
    }

    public void UnlockGoats()
    {
        goatsUnlocked = true;
        Debug.Log("Goats are now available to buy!");
    }
}
