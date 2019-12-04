using UnityEngine;
using System.Collections;

public class ScrollUV : MonoBehaviour {
    public static float speedDamper = 0.1f;
	void Update () {
        if (speedDamper < 3)
        speedDamper += 0.0001f;

        MeshRenderer mr = GetComponent<MeshRenderer>();

		Material mat = mr.material;

		Vector2 offset = mat.mainTextureOffset;

		offset.y += Time.deltaTime * speedDamper;

		mat.mainTextureOffset = offset;
        
    }

}
