using UnityEngine;
using System.Collections;

public class MenuController : MonoBehaviour {

    private GUIText m_GUIHighscore;
    private static int m_sHighscore;
    private static int m_sScore;
    private GUIText m_GUIScore;
	// Use this for initialization
	void Start () {
        m_GUIHighscore = GameObject.Find("Highscore").GetComponent<GUIText>() as GUIText;
        m_GUIScore = GameObject.Find("Score").GetComponent<GUIText>() as GUIText;
        m_sHighscore = PlayerPrefs.GetInt("highscore");
        m_GUIHighscore.text = "Highscore: " + m_sHighscore.ToString();
        m_sScore  = PlayerPrefs.GetInt("score");
        m_GUIScore.text = "Last Score: " + m_sScore.ToString();
	}
	
	// Update is called once per frame
	void Update () 
    {
	    if (Input.GetKeyDown(KeyCode.Space))
        {
            Application.LoadLevel("SimpleGamePlay");
        }

        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
	}
}
