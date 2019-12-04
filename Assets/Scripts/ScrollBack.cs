using UnityEngine;
using System.Collections;

public class ScrollBack : MonoBehaviour {
    public float speedDamper;
	void Update () {

		MeshRenderer mr = GetComponent<MeshRenderer>();

		Material mat = mr.material;

		Vector2 offset = mat.mainTextureOffset;

		offset.y += Time.deltaTime / speedDamper;

		mat.mainTextureOffset = offset;

	}

}
