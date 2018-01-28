using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnimator : MonoBehaviour
{
	public Animator target = null;

	public string hash = "";

	public void Enable() {
		this.target.Play(hash);
	}
}

