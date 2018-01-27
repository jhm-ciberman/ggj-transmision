using UnityEngine;
using UnityEngine.AI;

public class ClickToMove : MonoBehaviour
{
	NavMeshAgent agent;

	LayerMask layerMask;

	void Start()
	{
		agent = GetComponent<NavMeshAgent>();
		layerMask = LayerMask.GetMask("ClickToWalk");
	}

	void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			RaycastHit hit;
			if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100, layerMask))
			{
				agent.SetDestination(hit.point);
			}
		}

		

	}
}
