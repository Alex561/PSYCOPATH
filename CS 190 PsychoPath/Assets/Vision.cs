using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vision : MonoBehaviour {

    GameObject Parent_Hunter;
    GameObject player; 
    Vector3 Prey;

    Rigidbody2D rigid;
    public float hunter_speed = 4000; //MaxDistance
    public float acceleration = 10; //hunter acceleration


    public bool chase = false;

    //Patrolls
    public float timer = 5;//time per rotate
    float patroll_time;

    float targetRotation = 0;


	// Use this for initialization
	void Start () {

        rigid = GetComponentInParent<Rigidbody2D>();
        Parent_Hunter = transform.root.gameObject;//chasing elements

        player = player = GameObject.FindGameObjectWithTag("Player"); // setup for look at 2D
        patroll_time -= timer;
    }


    private void patroll()
    {
         if (Time.time >= patroll_time)
            {

                targetRotation = Random.value * 360;
            
                patroll_time += timer;
            }
    }


    // Update is called once per frame
    void Update () {
		
        //chasing Player
        if(chase)
        {

            float angle = 0; //look at 2D
            Vector3 relative = rigid.transform.InverseTransformPoint(player.transform.position);
            angle = Mathf.Atan2(relative.x, relative.y) * Mathf.Rad2Deg;
            rigid.transform.Rotate(0, 0, -angle);

            //chasing
            Prey = GameObject.FindGameObjectWithTag("Player").transform.position;
            Vector2 targetDirection = Prey - this.transform.position;
            targetDirection.Normalize();
            rigid.velocity = Vector2.MoveTowards(rigid.velocity, hunter_speed*targetDirection, Time.deltaTime *acceleration);

        }
        else
        {

            patroll();
            float angle = Mathf.MoveTowardsAngle(rigid.rotation, targetRotation, 100 * Time.deltaTime);
            rigid.transform.eulerAngles = new Vector3(0, 0, angle);
        }
    }
}
