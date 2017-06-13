using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class start_menu_script : MonoBehaviour {
    public string scene_name;

	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void NextScene()
    {
        AkSoundEngine.StopAll();
        AkBankManager.UnloadBank("Main");
        UnityEngine.SceneManagement.SceneManager.LoadScene(scene_name);
    }
}
