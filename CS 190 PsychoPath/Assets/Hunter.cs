using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hunter : MonoBehaviour {

 
    // Use this for initialization
    void Start () {


    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.name == "Player")
        {
            Debug.Log("I've got you in my sight.");
        }
    }
    // Update is called once per frame
    void Update () {


    }
}
