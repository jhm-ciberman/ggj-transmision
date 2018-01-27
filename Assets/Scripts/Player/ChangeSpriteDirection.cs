using UnityEngine;

class ChangeSpriteDirection: MonoBehaviour {

	public Animator animator;

	public Transform playerSpriteTransform;

	private Vector3 _lastPosition;

	private float _speed;

	private PlayerController _playerController; 

	private Vector3 _initialScale;
	public float minSpeedForWalk = 0.05f;

	void Start() {
		_playerController = GetComponent<PlayerController>();
		_initialScale = playerSpriteTransform.localScale;
	}
	void Update() {
		Vector3 dir = transform.position - _lastPosition;
		Vector3 scale = playerSpriteTransform.localScale;
		scale.x = _initialScale.x * ((dir.x > 0) ? 1f : -1f);
		playerSpriteTransform.localScale = scale; 

		animator.SetBool("walking", _playerController.isWalking);
		
		_lastPosition = transform.position;
	}

	private void SetDir() {

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