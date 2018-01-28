using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
	NavMeshAgent agent;

	LayerMask maskClickToWalk;
	LayerMask maskInteractable;

	//private Interactable _targetInteractable; 

	private float walkingSpeed = 4f;

	private bool _isWalking = false;

	void Start()
	{
		agent = GetComponent<NavMeshAgent>();
		maskClickToWalk = LayerMask.GetMask("ClickToWalk");
		maskInteractable = LayerMask.GetMask("World");
	}

	public bool isWalking {
		get {
			return _isWalking;
		}
	}
	void Update()
	{

		if (agent.remainingDistance < 0.5f)
		{
			agent.speed = 0;
			agent.isStopped = true;
			_isWalking = false;
			/*if (targetInteractable)
			{
				targetInteractable.Interact();
				targetInteractable = null;
			}
			*/
			
		}

		if (Input.GetMouseButtonDown(0))
		{
			RaycastHit hit;
			/*if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100, maskInteractable))
			{
				/*Interactable interactable = hit.transform.GetComponent<Interactable>();
				if (interactable)
				{
					
					targetInteractable = interactable;
					agent.SetDestination(targetInteractable.interactionPoint.position);
					agent.speed = walkingSpeed;
					agent.isStopped = false;
					_isWalking = true;
				}
				
			} 
			else 
			*/
			if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100, maskClickToWalk))
			{
				agent.speed = walkingSpeed;
				agent.isStopped = false;
				agent.SetDestination(hit.point);
				_isWalking = true;
			} 
		}




	}
}
