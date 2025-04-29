using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Customer : MonoBehaviour
{
    public Transform sellCounter;

    void Start()
    {
        GetComponent<NavMeshAgent>().SetDestination(sellCounter.position);
    }
}

