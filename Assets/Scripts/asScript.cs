using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asScript : MonoBehaviour {
    public GameObject target, source;
    public Rigidbody2D rb;
    public float strens = 1;
    Vector2 hitMe;

    void Start () {
         hitMe = target.transform.position - source.transform.position;
        
        rb.AddForce(hitMe * strens);
	}
	
	// Update is called once per frame
	void Update () {
        if (this.transform.position.y < -250)
            Destroy(source);
	}
}
