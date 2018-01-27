using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
	NavMeshAgent agent;

	LayerMask maskClickToWalk;
	LayerMask maskInteractable;

	private Interactable targetInteractable; 

	void Start()
	{
		agent = GetComponent<NavMeshAgent>();
		maskClickToWalk = LayerMask.GetMask("ClickToWalk");
		maskInteractable = LayerMask.GetMask("World");
	}

	void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			RaycastHit hit;
			if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100, maskInteractable))
			{
				Interactable interactable = hit.transform.GetComponent<Interactable>();
				if (interactable)
				{
					targetInteractable = interactable;
					agent.SetDestination(hit.point);
					
				}
			} 
			else if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100, maskClickToWalk))
			{
				agent.SetDestination(hit.point);
			} 
		}


		if (targetInteractable) {
			if (agent.pathStatus == NavMeshPathStatus.PathComplete || agent.remainingDistance < 0.2f)
			{
				agent.isStopped = true;
				targetInteractable.Interact();
				targetInteractable = null; 
			}
		}

	}
}
