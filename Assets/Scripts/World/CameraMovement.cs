using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour 
{
    private Vector3 m_CamPos;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        m_CamPos = gameObject.transform.position;
        gameObject.transform.position = new Vector3(0f, m_CamPos.y + 8.0f * Time.deltaTime, -10f);
	}
}
