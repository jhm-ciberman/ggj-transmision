using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
	NavMeshAgent agent;

	LayerMask maskClickToWalk;
	LayerMask maskInteractable;

	private Interactable targetInteractable; 

	private float walkingSpeed = 4f; 
	void Start()
	{
		agent = GetComponent<NavMeshAgent>();
		maskClickToWalk = LayerMask.GetMask("ClickToWalk");
		maskInteractable = LayerMask.GetMask("World");
	}

	public bool isWalking {
		get {
			return !agent.isStopped;
		}
	}
	void Update()
	{

		if (targetInteractable)
		{
			if (agent.remainingDistance < 0.2f)
			{
				agent.speed = 0;
				agent.isStopped = true;
				targetInteractable.Interact();
				targetInteractable = null;
			}
		}

		if (Input.GetMouseButtonDown(0))
		{
			RaycastHit hit;
			if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100, maskInteractable))
			{
				Interactable interactable = hit.transform.GetComponent<Interactable>();
				if (interactable)
				{
					
					targetInteractable = interactable;
					agent.SetDestination(targetInteractable.interactionPoint.position);
					agent.speed = walkingSpeed;
					agent.isStopped = false;
				}
			} 
			else if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100, maskClickToWalk))
			{
				agent.SetDestination(hit.point);
			} 
		}




	}
}
