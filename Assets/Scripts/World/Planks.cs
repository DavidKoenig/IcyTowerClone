using UnityEngine;
using System.Collections;

public class Planks : MonoBehaviour 
{
    private Vector3 m_PlankPos;

    private const float m_sRandomXMin = -10f;
    private const float m_sRandomXMax = 15f;
    private const float m_sRandomYMin = 35f;
    private const float m_sRandomYMax = 60f;

	// Use this for initialization
	void Start () 
    {
        MovePlank();
	}
	
	// Update is called once per frame
	void Update () 
    {
        Vector2 screenPosition = Camera.main.WorldToScreenPoint(transform.position);
        if (screenPosition.x > Screen.width)
        {
            MovePlank();
        }
	}

    void OnCollisionEnter2D (Collision2D col)
    {
        Debug.Log("Collision");
        if (col.gameObject.tag == "Wall")
        {
            MovePlank();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        print("CollisionTrigger");
        MovePlank();
    }

    void MovePlank()
    {
        print("Moved");
        m_PlankPos = gameObject.transform.position;

        float randomPosX = Random.Range(m_sRandomXMin, m_sRandomXMax);
        float randomPosY = Random.Range(m_sRandomYMin, m_sRandomYMax);

        m_PlankPos.x = randomPosX;
        m_PlankPos.y = Camera.main.gameObject.transform.position.y + randomPosY;
        m_PlankPos.z = 0f;

        gameObject.transform.position = new Vector3(m_PlankPos.x, m_PlankPos.y, m_PlankPos.z);
    }
}
