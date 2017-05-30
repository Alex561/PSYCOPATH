using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEditor.SceneManagement;

public class Player_Behavior : MonoBehaviour {

    bool can_Hide = false;

    int counter = 1;
    GameObject frontWall;
    GameObject[] monsters;
    // Use this for initialization


	void Start () {

        Sprite player = this.GetComponent<SpriteRenderer>().sprite;
        frontWall = GameObject.FindGameObjectWithTag("FrontWall");
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Hide")
        {
            can_Hide = true;

        }

        if (collision.tag == "MusicBox")
        {
            float x = Random.Range(this.transform.position.x + 15.0f, this.transform.position.x - 15.0f);
            while (x > 58 | x < -58)
            {
                x = Random.Range(this.transform.position.x + 15.0f, this.transform.position.x - 15.0f);
            }
            float y = Random.Range(this.transform.position.y + 15.0f, this.transform.position.y + 15.0f * -1);
            while (y > 48 | y<-18)
            {
                y = Random.Range(this.transform.position.y + 15.0f, this.transform.position.y + 15.0f * -1);
            }
            if (counter <= 2)
            {
                GameObject clown = Instantiate(Resources.Load("clown"), new Vector2(x,y), Quaternion.identity) as GameObject;          

            }
            else if (counter <=4)
            {
                GameObject doll = Instantiate(Resources.Load("doll"), new Vector2(x, y), Quaternion.identity) as GameObject;

            }
            else if (counter <=6)
            {
                GameObject robot = Instantiate(Resources.Load("robot"), new Vector2(x, y), Quaternion.identity) as GameObject;

            }

            //stop the music box sound
            AkSoundEngine.ExecuteActionOnEvent(3940140778, AkActionOnEventType.AkActionOnEventType_Stop, collision.gameObject, 1);

            Destroy(collision.gameObject);
            counter += 1;
        }

        if (collision.tag == "Clown")
            {
               if (this.GetComponent<PlayerMovement>().hide == false)
                {
                    Debug.Log("Clown sees you");
                    collision.GetComponent<Vision>().chase = true;
                }
            }
        if (collision.tag == "Exit")
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Win");
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if( collision.gameObject.tag == "ObstacleC"&& !this.GetComponent<PlayerMovement>().hide)
        {

            UnityEngine.SceneManagement.SceneManager.LoadScene("ClownDeath");
        }
        if (collision.gameObject.tag == "ObstacleD" && !this.GetComponent<PlayerMovement>().hide)
        {

            UnityEngine.SceneManagement.SceneManager.LoadScene("DollDeath");
        }
        if (collision.gameObject.tag == "ObstacleR" && !this.GetComponent<PlayerMovement>().hide)
        {

            UnityEngine.SceneManagement.SceneManager.LoadScene("RobotDeath");
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

                monsters = GameObject.FindGameObjectsWithTag("Obstacle");
                for (int i = 0; i != monsters.Length; i++)
                {
                    monsters[i].GetComponent<Collider2D>().enabled = true;
                }
            }
        }
        if (counter == 7)
        {
            endGame();
        }

	}
    
    void endGame()
    {
        monsters = GameObject.FindGameObjectsWithTag("Clown");
        for(int i = 0; i != monsters.Length; i++)
        {
            monsters[i].GetComponent<Vision>().chase = true;
        }
        Destroy(frontWall);
    }

    void hide()
    {
        this.GetComponent<SpriteRenderer>().enabled = false;
        this.GetComponent<PlayerMovement>().hide = true;
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);

        monsters = GameObject.FindGameObjectsWithTag("Clown");
        for (int i = 0; i != monsters.Length; i++)
        {
            monsters[i].GetComponent<Vision>().chase = false;
        }

        monsters = GameObject.FindGameObjectsWithTag("Obstacle");
        for (int i = 0; i != monsters.Length; i++)
        {
            monsters[i].GetComponent<Collider2D>().enabled = false;
        }

    }


}
