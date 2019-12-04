using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGAnim : MonoBehaviour
{

    public GameObject star;
    public float stop;
    public int lims, ly;
    Vector3 makan;
    private bool isExecuting = false;
    Vector3 temp;
    void Start()
    {

    }


    void Update()
    {
        StartCoroutine(spawnMee());
    }

    IEnumerator spawnMee()
    {
        if (isExecuting)
            yield break;

        isExecuting = true;

        yield return new WaitForSeconds(stop);


        makan.x = Random.Range(lims, -lims);
        makan.y = Random.Range(90, ly);
        Instantiate(star, makan, star.transform.rotation);

        isExecuting = false;

    }
  }