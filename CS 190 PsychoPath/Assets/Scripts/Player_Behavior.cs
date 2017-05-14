using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Behavior : MonoBehaviour {

    bool can_Hide = false;

	// Use this for initialization
	void Start () {

        Sprite player = this.GetComponent<SpriteRenderer>().sprite;
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Hide")
        {
            can_Hide = true;

        }

        if (collision.tag =="MusicBox")
        {
            Debug.Log("Pickup");
            Destroy(collision.gameObject);
        }

        if (collision.tag == "Clown")
            {
            if (this.GetComponent<PlayerMovement>().hide == false)
            {
                Debug.Log("Clown sees you");
                collision.GetComponent<Vision>().chase = true;
            }
  
            }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Hide")
        {
            can_Hide = false;
        }
    }


    // Update is called once per frame
    void Update () {
		if (can_Hide)
        {
            if(Input.GetKeyDown("space") && (this.GetComponent<PlayerMovement>().hide == false))
            {
                hide();
            }
            
            else if (Input.GetKeyDown("space") && (this.GetComponent<PlayerMovement>().hide == true))
            {
                this.GetComponent<SpriteRenderer>().enabled = true;
                this.GetComponent<PlayerMovement>().hide = false;
            }


        }

	}

    void hide()
    {
        this.GetComponent<SpriteRenderer>().enabled = false;
        this.GetComponent<PlayerMovement>().hide = true;
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
    }
}
