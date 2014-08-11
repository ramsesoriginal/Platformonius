using UnityEngine;
using System.Collections;

public class OffsetedPositioner : MonoBehaviour {
	
	public Transform Origin;
	public Vector3 Offset;
	
	void Start() {
		Offset = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = Origin.TransformPoint (Offset);//Origin.position + Offset;
		transform.rotation = Origin.rotation;
	}
}

