using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour 
{
    private Vector3 m_CamPos;
    public static float m_sCameraSpeed;
	// Use this for initialization
	void Start () 
    {
        m_sCameraSpeed = 8f;
	}
	
	// Update is called once per frame
	void Update () 
    {
        m_CamPos = gameObject.transform.position;
        gameObject.transform.position = new Vector3(0f, m_CamPos.y + m_sCameraSpeed * Time.deltaTime, -10f);
	}

    public static void IncreaseCameraSpeed()
    {
        if (m_sCameraSpeed < 18f)
        {
            //m_sCameraSpeed += 2f;
            //print("Speed: " + m_sCameraSpeed);
        }
    }
}
