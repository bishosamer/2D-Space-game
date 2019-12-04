using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour
{
	public GameObject sp;
	public int delay;
	public int lim,y;
	Vector3 place;
	private bool isCoroutineExecuting = false;
	void Start()
	{
		place.y = y; place.z = 0;
	}

	// Update is called once per frame
	void Update()
	{
		StartCoroutine(spawnMe());
		//StopCoroutine(spawnMe());
	}
	IEnumerator spawnMe()
	{
		if (isCoroutineExecuting)
			yield break;

		isCoroutineExecuting = true;

		yield return new WaitForSeconds(delay);

		// Code to execute after the delay
		place.x = Random.Range(lim, -lim);
		Instantiate(sp, place, sp.transform.rotation);

		isCoroutineExecuting = false;
	}
}