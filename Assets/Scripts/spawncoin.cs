using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawncoin : MonoBehaviour
{
    public GameObject coi;
    public int stop;
    public int lims, ly;
    Vector3 makan;
 
    // Update is called once per frame

    IEnumerator Start()
    {
        makan.y = ly; makan.z = 0;
        while (true)
        {
            yield return new WaitForSeconds(stop);

            // Code to execute after the delay  
            makan.x = Random.Range(lims, -lims);
            makan.y = ly;
            Instantiate(coi, makan, coi.transform.rotation);
        }

    }
}