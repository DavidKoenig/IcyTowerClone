using UnityEngine;
using System.Collections;

public class EndlessSW : MonoBehaviour {

    private Vector3 m_BackPos;
    private float m_sMoveHeight;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnBecameInvisible()
    {
        m_sMoveHeight = gameObject.renderer.bounds.size.y - 10f;
        // get current position
        m_BackPos = gameObject.transform.position;

        // move to new position when invisible
        gameObject.transform.position = new Vector3(m_BackPos.x, m_BackPos.y + 3 * m_sMoveHeight);
    }
}
