using UnityEngine;
using System.Collections;
using System.Diagnostics;

public class GeneratePlanks : MonoBehaviour {

    public GameObject[] planks;

    private GameObject m_Clone;
    private float m_InvokeRepeat = 5f;

    void Start()
    {
        StartCoroutine(Spawn());
    }

    void Update()
    {
        if (CameraMovement.m_sCameraSpeed <= 10f)
        {
            print("invoke 1");
            m_InvokeRepeat = 4f;
        }
        else if (CameraMovement.m_sCameraSpeed <= 12f && CameraMovement.m_sCameraSpeed >= 10f)
        {
            print("invoke 2");
            m_InvokeRepeat = 3.5f;
        }
        else if (CameraMovement.m_sCameraSpeed <= 14f && CameraMovement.m_sCameraSpeed >= 12f)
        {
            print("invoke 3");
            m_InvokeRepeat = 3.3f;
        }
        else if (CameraMovement.m_sCameraSpeed <= 16f && CameraMovement.m_sCameraSpeed >= 14f)
        {
            print("invoke 4");
            m_InvokeRepeat = 2.5f;
        }
        else if (CameraMovement.m_sCameraSpeed <= 18f && CameraMovement.m_sCameraSpeed >= 16f)
        {
            print("invoke 5");
            m_InvokeRepeat = 2.2f;
        }
    }

    IEnumerator Spawn() 
    {
        yield return new WaitForSeconds(m_InvokeRepeat);
        while (true)
        {
            for (int i = 0; i < planks.Length; i++)
            {
                print("Invoke Call " + m_InvokeRepeat);
                m_Clone = (GameObject)Instantiate(planks[i]);
                m_Clone.AddComponent("CloneDeleter");
                m_Clone.layer = 12;
            }
            yield return new WaitForSeconds(m_InvokeRepeat);
        }
    }
}
