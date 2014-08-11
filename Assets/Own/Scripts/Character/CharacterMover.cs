using UnityEngine;
using System.Collections;

[RequireComponent (typeof (CharacterController))]
public class CharacterMover : MonoBehaviour {
	
	public Transform Target;
	private CharacterController controller;
	public float gravity;
	public Animator anim;
	int speed = Animator.StringToHash("Speed");

	void Reset() {
		gravity = 20.0f;
	}

	void Start() {
		controller = gameObject.GetComponent<CharacterController>();
	}

	// Update is called once per frame
	void Update () {
		var newPos = Vector3.Lerp (transform.position, Target.position, Time.deltaTime);
		var moveVector = newPos - transform.position;
		moveVector.y -= gravity * Time.deltaTime;
		controller.Move (moveVector);
		anim.SetFloat (speed, controller.velocity.magnitude);
		transform.LookAt (Target.transform);
	}

	
	
	void OnDrawGizmos() {
		Gizmos.color = Color.green;
		Gizmos.DrawWireSphere(transform.position, 1);
	}
}
