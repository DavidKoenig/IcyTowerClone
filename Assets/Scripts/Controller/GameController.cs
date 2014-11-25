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
       
        m_GUIHurry.color = new Color(m_GUIHurry.color.r, m_GUIHurry.color.g, m_GUIHurry.color.b, 0f);
	}
	
	// Update is called once per frame
	void FixedUpdate () 
    {	    
        m_GUIScore.text     = "Score: " + m_sScore.ToString();
        m_GUIHighscore.text = "Highscore: " + m_sHighscore.ToString();
	}

    void OnGUI()
    {
        GUI.color = Color.black;
        GUI.skin.label.fontSize = 25;
        GUI.Label(new Rect(Screen.width - 390, 610, 200, 50), "Score: " + m_sScore.ToString());

        GUI.color = Color.black;
        GUI.skin.label.fontSize = 25;
        GUI.Label(new Rect(Screen.width - 1170, 610, 200, 50), "Highscore: " + m_sScore.ToString());

        GUI.color = Color.white;
        GUILayout.Label("Score: " + m_sScore.ToString());
        GUI.color = Color.white;
        GUILayout.Label("Highscore: " + m_sScore.ToString());
    }

    public void IncreaseScore ()
    {
        m_sScore += 10;
        if (m_sScore >= 50 && (m_sScore % 50) == 0)
        {
            StartCoroutine(FadingIn());
            m_GUIHurry.color = new Color(m_GUIHurry.color.r, m_GUIHurry.color.g, m_GUIHurry.color.b, 0f);
            CameraMovement.IncreaseCameraSpeed();       
        }
    }

    IEnumerator FadingIn()
    {
       yield return new WaitForSeconds(0.1f);
       while (true)
       {
           m_GUIHurry.color = new Color(m_GUIHurry.color.r, m_GUIHurry.color.g, m_GUIHurry.color.b, 1f);
           yield return new WaitForSeconds(0.1f);
       }
    }

    private void FadingOut()
    {
        for (float a = 1f; a >= 0f; a -= 0.1f)
        {
            m_GUIHurry.color = new Color(m_GUIHurry.color.r, m_GUIHurry.color.g, m_GUIHurry.color.b, a);
        }
        m_GUIHurry.color = new Color(m_GUIHurry.color.r, m_GUIHurry.color.g, m_GUIHurry.color.b, 0f);
    }
}
