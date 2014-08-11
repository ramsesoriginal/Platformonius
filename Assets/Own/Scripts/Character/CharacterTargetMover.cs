using UnityEngine;
using System.Collections;

public class CharacterTargetMover : MonoBehaviour {

	public Transform Character;
	public float MaxDistance;
	public float MaxSpeed;
	public float MaxStrafeSpeed;
	public float MaxRotateSpeed;
	
	private Vector3 moveDirection;
	private Vector3 forward;
	private Vector3 right;

	void Reset() {
		MaxDistance = 2;
		MaxSpeed = 4;
		MaxRotateSpeed = 200;
		MaxStrafeSpeed = 0;
	}

	// Update is called once per frame
	void Update () {
		forward = transform.forward;
		right = new Vector3(forward.z, 0, -forward.x);
		var horizontalInput = Input.GetAxisRaw("Horizontal");
		var verticalInput = Input.GetAxisRaw("Vertical");

		var targetDirection = horizontalInput * right + verticalInput * forward;
		moveDirection = Vector3.RotateTowards(moveDirection, targetDirection, MaxRotateSpeed * Mathf.Deg2Rad * Time.deltaTime, 1000);
		var movement = moveDirection  * Time.deltaTime * MaxSpeed;
		var newPos = transform.position + movement;
		newPos.y = Character.position.y;
		var dst = Vector3.Distance(newPos, Character.position);
		if (dst < (MaxDistance+(MaxSpeed/2))) {
			transform.position = newPos;
		}

		if (targetDirection != Vector3.zero) {
			transform.rotation = Quaternion.LookRotation (moveDirection);
		}

	}

	void OnDrawGizmos() {
		Gizmos.color = Color.yellow;
		Gizmos.DrawWireSphere(transform.position, 0.2f);
	}
}
