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

    void FixedUpdate()
    {
        //if (CameraMovement.m_sCameraSpeed == 10f)
        //{
        //    m_InvokeRepeat = 7f;
        //    CancelInvoke("CreateObstacle");
        //    InvokeRepeating("CreateObstacle", m_InvokeStart, m_InvokeRepeat);
        //}
        //else if (CameraMovement.m_sCameraSpeed == 12f)
        //{
        //    m_InvokeRepeat = 9f;
        //    CancelInvoke("CreateObstacle");
        //    InvokeRepeating("CreateObstacle", m_InvokeStart, m_InvokeRepeat);
        //}
        //else if (CameraMovement.m_sCameraSpeed == 14f)
        //{
        //    m_InvokeRepeat = 11f;
        //    CancelInvoke("CreateObstacle");
        //    InvokeRepeating("CreateObstacle", m_InvokeStart, m_InvokeRepeat);
        //}
        //else if (CameraMovement.m_sCameraSpeed == 16f)
        //{
        //    m_InvokeRepeat = 13f;
        //    CancelInvoke("CreateObstacle");
        //    InvokeRepeating("CreateObstacle", m_InvokeStart, m_InvokeRepeat);
        //}
        //else if (CameraMovement.m_sCameraSpeed == 18f)
        //{
        //    m_InvokeRepeat = 15f;
        //    CancelInvoke("CreateObstacle");
        //    InvokeRepeating("CreateObstacle", m_InvokeStart, m_InvokeRepeat);
        //}
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
