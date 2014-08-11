using UnityEngine;
using System.Collections;

public class FollowCam : MonoBehaviour {

	public Transform Target;
	public Transform DefaultPos;
	public GameObject Camera;
	public Vector3 Offset;

	void Start() {
		if (Camera == null)
			Camera = GameObject.FindGameObjectsWithTag("MainCamera")[0];
		Camera.transform.parent = transform;
		Offset = DefaultPos.position;
	}

	void Update () {
		var targetPos = DefaultPos.position;
		RaycastHit hit;
		if (Physics.Raycast(targetPos, Vector3.down, out hit)) {
			if (Vector3.Distance(hit.point, targetPos) < Offset.y) {
				targetPos.y += Offset.y;
			}
		} else if (Physics.Raycast(targetPos, Vector3.up, out hit)) {
			targetPos.y += Offset.y + Vector3.Distance(hit.point, targetPos);
		}
		var newPos = Vector3.Lerp (transform.position, targetPos, Time.deltaTime);
		transform.position = newPos;
		transform.LookAt (Target.transform);
	}
}
