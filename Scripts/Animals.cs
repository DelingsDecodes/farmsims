using UnityEngine;

public class Animal : MonoBehaviour
{
    public GameObject productPrefab; // Egg Prefab
    public float produceInterval = 10f; // Time between laying eggs
    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= produceInterval)
        {
            Produce();
            timer = 0f;
        }
    }

    void Produce()
    {
        Instantiate(productPrefab, transform.position + Vector3.right, Quaternion.identity);
        Debug.Log("Animal produced an item!");
    }
}
