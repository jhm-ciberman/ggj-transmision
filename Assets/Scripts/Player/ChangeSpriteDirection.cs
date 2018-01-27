using UnityEngine;

class ChangeSpriteDirection: MonoBehaviour {

	public Animator animator;

	private Vector3 _lastPosition;

	private float _speed;

	private PlayerController _playerController; 

	public float minSpeedForWalk = 0.05f;

	void Start() {
		_playerController = GetComponent<PlayerController>();
	}
	void Update() {
		// Vector3 direction = transform.position - lastPosition;
		//float angle = Vector3.Angle(Camera.main.transform.forward, direction);

		_speed = (transform.position - _lastPosition).magnitude;
		animator.SetBool("walking", _playerController.isWalking);
		
		_lastPosition = transform.position;
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