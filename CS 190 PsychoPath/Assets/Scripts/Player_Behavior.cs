using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Behavior : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Hide")
        {
            Debug.Log("barrel");
            this.GetComponent<SpriteRenderer>().enabled = false;
        }

        if (collision.tag =="MusicBox")
        {
            Debug.Log("Pickup");
            Destroy(collision.gameObject);
        }

        if (collision.tag == "Clown")
            {
            Debug.Log("Clown sees you");
            collision.GetComponent<Vision>().chase = true;
            }

    }
    

    // Update is called once per frame
    void Update () {
		
	}
}
