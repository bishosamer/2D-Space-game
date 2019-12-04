using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu_Audio_Script : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Music");
        if (objs.Length > 1)
            Destroy(this.gameObject);

        DontDestroyOnLoad(this.gameObject);		
	}

}
