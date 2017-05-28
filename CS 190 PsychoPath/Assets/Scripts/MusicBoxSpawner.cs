using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicBoxSpawner : MonoBehaviour {



	// Use this for initialization
	void Start () {

        GameObject Box1 = Instantiate(Resources.Load("Box1"), new Vector2(Random.Range(-58, 58), Random.Range(48, -18)), Quaternion.identity) as GameObject;
        GameObject Box2 = Instantiate(Resources.Load("Box2"), new Vector2(Random.Range(-58, 58), Random.Range(48, -18)), Quaternion.identity) as GameObject;
        GameObject Box3 = Instantiate(Resources.Load("Box3"), new Vector2(Random.Range(-58, 58), Random.Range(48, -18)), Quaternion.identity) as GameObject;
        GameObject Box4 = Instantiate(Resources.Load("Box4"), new Vector2(Random.Range(-58, 58), Random.Range(48, -18)), Quaternion.identity) as GameObject;
        GameObject Box5 = Instantiate(Resources.Load("Box5"), new Vector2(Random.Range(-58, 58), Random.Range(48, -18)), Quaternion.identity) as GameObject;
        GameObject Box6 = Instantiate(Resources.Load("Box6"), new Vector2(Random.Range(-58, 58), Random.Range(48, -18)), Quaternion.identity) as GameObject;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
