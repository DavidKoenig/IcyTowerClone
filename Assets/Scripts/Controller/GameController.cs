using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    private static int m_sScore;
	
    // Use this for initialization
	void Start () {
        m_sScore = 0;
        Physics2D.IgnoreLayerCollision(13, 12, true);
	}
	
	// Update is called once per frame
	void FixedUpdate () 
    {	    
	}

    void OnGUI()
    {
        //GUI.color = Color.black;
        //GUI.skin.label.fontSize = 25;
        //GUI.Label(new Rect(Screen.width - 390, 610, 200, 50), "Score: " + m_sScore.ToString());

        //GUI.color = Color.black;
        //GUI.skin.label.fontSize = 25;
        //GUI.Label(new Rect(Screen.width - 1170, 610, 200, 50), "Highscore: " + m_sScore.ToString());

        GUI.color = Color.white;
        GUILayout.Label("Score: " + m_sScore.ToString());
        GUI.color = Color.white;
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
