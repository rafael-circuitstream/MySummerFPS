using UnityEngine;

public class ChaseNpcState : NpcState
{
    public Transform targetToChase;


    public override void OnStateEnter()
    {
        Debug.Log("PLAYER DETECTED! ...initiating chase...");
    }

    public override void OnStateExit()
    {

    }

    public override void OnStateRun()
    {
        character.SetAgentDestination(targetToChase.position);
    }

    public ChaseNpcState(CharacterAI owner) : base(owner)
    {

    }
}
