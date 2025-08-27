using UnityEngine;
using UnityEngine.AI;
using System.Collections;
public class CharacterAI : MonoBehaviour
{
    [SerializeField] private NavMeshAgent myAgent;
    [SerializeField] private Transform target;

    private Vector3 lastPosition;
    private NpcState CurrentState;

    private void Start()
    {
        ChangeState(new WanderNpcState(this));
    }

    public void ChangeState(NpcState newState)
    {
        if (CurrentState != null)
        {
            CurrentState.OnStateExit();
        }

        CurrentState = newState;

        CurrentState.OnStateEnter();
    }

    void Update()
    {
        if (CurrentState != null)
        {
            CurrentState.OnStateRun();
            
        }

        Vector3 deltaPosition = transform.position - lastPosition;
        if(deltaPosition.magnitude > 0.75f)
        {
            //Play footstep sound
        }

        lastPosition = transform.position;
    }

    public bool IsMoving()
    {
        return myAgent.remainingDistance > myAgent.stoppingDistance && myAgent.velocity.magnitude > 0.5f;
    }

    public void SetAgentDestination(Vector3 destination)
    {
        myAgent.SetDestination(destination);
    }

    IEnumerator FindPathCoroutine()
    {
        while(true)
        {
            myAgent.SetDestination(target.position);
            yield return new WaitForSeconds(2f);
        }

    }
    
}
