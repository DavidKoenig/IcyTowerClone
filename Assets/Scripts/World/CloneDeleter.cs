using UnityEngine;
using System.Collections;

public class CloneDeleter : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
            //Vector3 viewPos = Camera.main.WorldToViewportPoint(gameObject.transform.position);

            //if (viewPos.y > 0F)
            //{
            //    Destroy(gameObject);
            //}     
	}

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}