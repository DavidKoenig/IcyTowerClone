using UnityEngine;
using System.Collections;

public class EndlessBG : MonoBehaviour {

    private Vector3 m_BackPos;
    private float m_sMoveHeight = 20f;
    private bool waited;

    IEnumerator Wait()
    {
        print(Time.time);
        waited = false;
        yield return new WaitForSeconds(5f);
        waited = true;
        print(Time.time);
    }

    // Use this for initialization
    void Start()
    {
        while (waited)
        { }
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnBecameInvisible()
    {
        m_sMoveHeight = gameObject.renderer.bounds.size.y - 0.03f;
        // get current position
        m_BackPos = gameObject.transform.position;

        // move to new position when invisible
        gameObject.transform.position = new Vector3(m_BackPos.x, m_BackPos.y + 3 * m_sMoveHeight);
    }
}
