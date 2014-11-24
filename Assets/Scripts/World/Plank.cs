using UnityEngine;
using System.Collections;

public class Plank : MonoBehaviour
{
    private GameObject m_LeftBorder;
    private GameObject m_RightBorder;
    private GameObject m_GoPlank;
    private Vector3 m_PlankPos;
    private float m_Width;

    // Use this for initialization
    void Start()
    {
        m_LeftBorder            = GameObject.Find("LeftBorder");
        m_RightBorder           = GameObject.Find("RightBorder");
        m_GoPlank               = gameObject;
        Collider2D collider2D   = m_GoPlank.GetComponent<Collider2D>();
        m_Width                 = collider2D.bounds.size.x;             

        MovePlank();
    }

    void FixedUpdate()
    {     
    }

    void MovePlank()
    {
        float leftBorderX   = m_LeftBorder.transform.position.x;
        float rightBorderX  = m_RightBorder.transform.position.x;
        //float cameraY       = Camera.main.gameObject.transform.position.y;

        float highestY      = FindHighestPlank();
        float minY          = highestY + 3f;
        float maxY          = highestY + 10f;

        m_PlankPos = m_GoPlank.transform.position;

        float randomPosX = Random.Range(leftBorderX + m_Width / 2, rightBorderX - m_Width / 2);
        float randomPosY = Random.Range(minY, maxY);

        m_PlankPos.x = randomPosX;
        m_PlankPos.y = randomPosY;
        m_PlankPos.z = 0f;

        m_GoPlank.transform.position = new Vector3(m_PlankPos.x, m_PlankPos.y, m_PlankPos.z);
    }

    float FindHighestPlank()
    {
        float highestY = 0;

        GameObject[] planks = GameObject.FindGameObjectsWithTag("Plank");

        foreach (GameObject plank in planks)
        {
            float plankY = plank.transform.position.y;

            if (plankY > highestY)
            {
                highestY = plankY;
            }
        }
        return highestY;
    }

    void OnBecameVisible()
    {
        GameController.IncreaseScore();
    }
}
