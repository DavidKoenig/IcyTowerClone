using UnityEngine;
using System.Collections;

public class RobotControllerScript : MonoBehaviour {

    public float maxSpeed = 10f;

    bool facingRight = true;
    
    // ground
    bool grounded = false;
    public Transform groundCheck;
    float groundRadius = 0.2f;
    public LayerMask whatIsGround;
    public float jumpForce = 300;
    GameObject[] planks;

    bool doubleJump = false;

	Animator anim;

    private GameController m_GameController;

	// Use this for initialization
	void Start () 
	{
		anim = GetComponent<Animator>();

        m_GameController = GameObject.Find("GameController").GetComponent("GameController") as GameController;
	}
	
	// Update is called once per frame
	void FixedUpdate () 
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        anim.SetBool("Ground", grounded);

        if (grounded)
            doubleJump = false;

        anim.SetFloat("vSpeed", rigidbody2D.velocity.y);
        
        float move = Input.GetAxis("Horizontal");

		anim.SetFloat ("Speed", Mathf.Abs(move));

        rigidbody2D.velocity = new Vector2(move * maxSpeed, rigidbody2D.velocity.y);

        if (move > 0 && !facingRight)
        {
            Flip();
        }
        else if (move < 0 && facingRight)
        {
            Flip();
        }
	}

    void Update()
    {
        if ((grounded || !doubleJump) && Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetBool("Ground", false);
            rigidbody2D.AddForce(new Vector2(0, jumpForce));
            audio.Play();

            if (!doubleJump && !grounded)
                doubleJump = true;
        }

        if (rigidbody2D.velocity.y > 0)
            gameObject.layer = 13;
        else
            gameObject.layer = 9;

        //planks = GameObject.FindGameObjectsWithTag("Wall") as GameObject[];
        //foreach (GameObject plank in planks)
        //{
        //    if (plank.transform.position.y < gameObject.transform.position.y)
        //    {
        //        plank.collider.enabled = true;
        //        Debug.Log("Bam");
        //    }
        //}

    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Ice")
            Die();

        //if (coll.gameObject.transform.position.y > groundCheck.position.y && gameObject.layer != 13)
        //    coll.collider.enabled = false;
        if (coll.gameObject.name == "PlankIceS" || coll.gameObject.name == "PlankIceM" || coll.gameObject.name == "PlankIceXL")
        {
            print("test2");
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    void Die()
    {
        // Save the Highscore to PlayerPrefs if higher than existing.
        if (PlayerPrefs.GetInt("highscore") < m_GameController.getScore())
        { 
            PlayerPrefs.SetInt("highscore", m_GameController.getScore());
        }
        PlayerPrefs.Save();
        PlayerPrefs.SetInt("score", m_GameController.getScore());

        Application.LoadLevel("Menu");
    }
}
