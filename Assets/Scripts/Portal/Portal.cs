using UnityEngine;
using UnityEngine.AI;

class Portal: MonoBehaviour {

	public GameObject currentScene;
	public GameObject targetScene;

	public Portal endPoint = null;

	public static bool teleportEnabled = true; 

	void Start() {
		targetScene.SetActive(false);
	}

	void OnTriggerEnter(Collider col) {
		if (Portal.teleportEnabled) {
			if (col.tag.Equals("Player")) {
				Portal.teleportEnabled = false;
				targetScene.SetActive(true);
				col.GetComponent<NavMeshAgent>().enabled = false;
				if (endPoint == null) {
					throw new System.Exception("Not defined");
				} else {
					col.transform.position = endPoint.transform.position;
				}
				col.GetComponent<NavMeshAgent>().enabled = true;
				currentScene.SetActive(false);
			}
		}
	}

	void OnTriggerExit(Collider col) {
		if (!Portal.teleportEnabled) {
			Portal.teleportEnabled = true; 
		}
	}
	

}