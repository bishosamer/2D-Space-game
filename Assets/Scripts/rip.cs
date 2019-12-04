using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rip : MonoBehaviour {

	
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {







        if (this.transform.position.y < -250)
			Destroy (this.gameObject);
	}
}
