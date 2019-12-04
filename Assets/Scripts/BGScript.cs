using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScript : MonoBehaviour {

    public GameObject star;
    public float p;
    public int lx, ly;
    Vector3 makan;
    

    void Start () {
        makan.z = 10;
	}
	

	void Update () {
        makan.x = Random.Range(-lx, lx);
        makan.y = Random.Range(-ly + 50, ly);
        Instantiate(star, makan, star.transform.rotation);
       
    }

}
