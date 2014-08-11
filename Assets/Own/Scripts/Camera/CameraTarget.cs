using UnityEngine;
using System.Collections;

public class CameraTarget : MonoBehaviour {

	public Transform DefaultTarget;

	// Update is called once per frame
	void Update () {
		var newPos = DefaultTarget.position;
		transform.position = newPos;
	}
}
