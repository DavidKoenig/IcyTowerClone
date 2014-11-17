using UnityEngine;
using System.Collections;

public class GeneratePlanks : MonoBehaviour {

    public GameObject planks;

    // Use this for initialization
    void Start()
    {
        InvokeRepeating("CreateObstacle", 1f, 5f);
    }

    void CreateObstacle()
    {
        Instantiate(planks);
    }
}
