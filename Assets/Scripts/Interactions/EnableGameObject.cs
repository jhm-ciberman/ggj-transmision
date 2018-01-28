using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableGameObject : MonoBehaviour
{
	public GameObject targetGameObject = null;

	public void Enable() {
		this.targetGameObject.SetActive(true);
	}
}

