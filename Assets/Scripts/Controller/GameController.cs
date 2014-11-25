using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    private static int m_sScore;
    private static int m_sHighscore;
    private GUIText m_GUIScore;
    private GUIText m_GUIHighscore;
    private GUIText m_GUIHurry;
	
    // Use this for initialization
	void Start () {
        Physics2D.IgnoreLayerCollision(13, 12, true);

        m_sScore     = 0;
        m_sHighscore = 0;
       
        m_GUIScore      = GameObject.Find("Score").GetComponent<GUIText>() as GUIText;
        m_GUIHighscore  = GameObject.Find("Highscore").GetComponent<GUIText>() as GUIText;
        m_GUIHurry      = GameObject.Find("Hurry").GetComponent<GUIText>() as GUIText;
	}
	
	// Update is called once per frame
	void FixedUpdate () 
    {	    
        m_GUIScore.text     = "Score: " + m_sScore.ToString();
        m_GUIHighscore.text = "Highscore: " + m_sHighscore.ToString();
	}

    public void IncreaseScore()
    {
        m_sScore += 10;
        if (m_sScore >= 50 && (m_sScore % 50) == 0)
        {
            m_GUIHurry.animation.Play("HurryText");
            CameraMovement.IncreaseCameraSpeed();
        }
    }
}
