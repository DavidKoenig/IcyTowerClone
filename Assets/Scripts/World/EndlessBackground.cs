using UnityEngine;
using System.Collections;

public class EndlessBackground : MonoBehaviour 
{
    private Vector3 m_BackPos;
    private const float m_sMoveHeight = 53f;
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
	void Start () 
    {
        while (waited)
        { }
	}
	
	// Update is called once per frame
	void Update () {
	}

    void OnBecameInvisible()
    {
        //calculate current position
        m_BackPos = gameObject.transform.position;

        //move to new position when invisible
        gameObject.transform.position = new Vector3(m_BackPos.x, m_BackPos.y + m_sMoveHeight + m_sMoveHeight / 2, m_BackPos.z);
    }
}
