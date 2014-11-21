using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    private static int m_sScore;
	
    // Use this for initialization
	void Start () {
        m_sScore = 0;
	}
	
	// Update is called once per frame
	void FixedUpdate () 
    {
	    
	}

    void OnGUI()
    {
        GUI.color = Color.black;
        GUILayout.Label("Score: " + m_sScore.ToString());
        GUI.color = Color.black;
        GUILayout.Label("Highscore: " + m_sScore.ToString());
    }

    public static void IncreaseScore ()
    {
        m_sScore += 10;
        if (m_sScore >= 50 && (m_sScore % 50) == 0)
        {
            CameraMovement.IncreaseCameraSpeed();
        }
    }
}
