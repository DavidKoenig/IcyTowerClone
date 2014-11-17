﻿using UnityEngine;
using System.Collections;

public class SpanPlanks : MonoBehaviour 
{
    //public GameObject Plank;
    private int score = 0;

    private Vector3 m_PlankPos;

    private const float m_sRandomXMin = -15f;
    private const float m_sRandomXMax =  20f;
    private const float m_sRandomYMin =  17f;
    private const float m_sRandomYMax =  40f;

    // Use this for initialization
    void Start()
    {
    }

    void FixedUpdate()
    {
    }

    void OnBecameInvisible()
    {
        MovePlank();
    }

    void OnCollisionEnter(Collision col)
    {
        Debug.Log("Collision");
        if (col.gameObject.tag == "Wall")
        {
            MovePlank();
        }
    }

    void MovePlank()
    {
        Debug.Log("Moved");
        m_PlankPos = gameObject.transform.position;

        float randomPosX = Random.Range(m_sRandomXMin, m_sRandomXMax);
        float randomPosY = Random.Range(m_sRandomYMin, m_sRandomYMax);

        m_PlankPos.x = randomPosX;
        m_PlankPos.y = Camera.main.gameObject.transform.position.y + randomPosY;
        m_PlankPos.z = 0f;

        gameObject.transform.position = new Vector3(m_PlankPos.x, m_PlankPos.y, m_PlankPos.z);
    }
}
