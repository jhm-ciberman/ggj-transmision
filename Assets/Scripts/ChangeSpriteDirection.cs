using UnityEngine;

class ChangeSpriteDirection: MonoBehaviour {

	public Animator animator;

	Vector3 lastPosition;

	float speed;

	public float minSpeedForWalk = 0.05f;

	void Update() {
		Vector3 direction = transform.position - lastPosition;
		
		//float angle = Vector3.Angle(Camera.main.transform.forward, direction);
		speed = (transform.position - lastPosition).magnitude;

		animator.SetBool("walking", (speed > minSpeedForWalk));
		 
		
		lastPosition = transform.position;
	}

	void GetDirection()
	{
		float headingAngle = transform.rotation.eulerAngles.y;
		Debug.Log(headingAngle);
		/*if (headingAngle > 315 || headingAngle < 45) {
			animator.SetBool("GoForward", true);
		} else if (headingAngle < 225) {
			animator.SetBool("GoLeft", true);
		} else if (headingAngle < 135) {
			animator.SetBool("GoBackward", true);
		} else {
			animator.SetBool("GoRight", true);
		}*/
			
	}
}