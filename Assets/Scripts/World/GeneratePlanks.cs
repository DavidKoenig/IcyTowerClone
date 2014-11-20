using UnityEngine;
using System.Collections;
using System.Diagnostics;

public class GeneratePlanks : MonoBehaviour {

    public GameObject[] planks;   
    public float m_InvokeStart  = 1f;
    public float m_InvokeRepeat = 5f;

    private GameObject m_Clone;

    // Use this for initialization
    void Start()
    {
        InvokeRepeating("CreateObstacle", m_InvokeStart, m_InvokeRepeat);
    }

    void CreateObstacle()
    {
        for (int i = 0; i < planks.Length; i++)
        {
            new WaitForSeconds(3);

            m_Clone = (GameObject) Instantiate(planks[i]);
            m_Clone.AddComponent("CloneDeleter");
        }
    }
}
