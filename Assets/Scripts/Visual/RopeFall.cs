using UnityEngine;

class RopeFall: MonoBehaviour {

	public Animator animator = null;

	void Start() {
		this.animator.StopPlayback();
		this.animator.enabled = false;
	}
	public void Fall() {
		this.animator.enabled = true;
		this.animator.Play("RopeFall", -1);
	}
}