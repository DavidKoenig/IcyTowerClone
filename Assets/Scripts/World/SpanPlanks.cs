using UnityEngine;
using System.Collections;

public class SpanPlanks : MonoBehaviour 
{
    public GameObject Plank;
    int score = 0;
    private Vector3 m_PlankPos;

    // Use this for initialization
    void Start()
    {
        InvokeRepeating("CreateObstacle", Random.Range(2f, 6f), Random.Range(4f, 15f));
    }

    void OnGUI()
    {
        GUI.color = Color.black;
        GUI.Label(new Rect(0, 0, 100, 50), " Score: " + score.ToString());
    }

    // Update is called once per frame
    void CreateObstacle()
    {
        Instantiate(Plank);
        float randomPosX = Random.Range(-15f, 20f);
        float randomPosY = Random.Range(5f, 20f);

        m_PlankPos.x = randomPosX;
        m_PlankPos.y = Camera.main.gameObject.transform.position.y + randomPosY;
        m_PlankPos.z = 0f;

        Plank.transform.position = m_PlankPos;
        score++;
    }

    void OnBecameInvisible()
    {
        enabled = false;
        //Destroy(Plank);
    }
}
