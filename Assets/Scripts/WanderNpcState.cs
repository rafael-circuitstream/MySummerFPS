using UnityEngine;

public class WanderNpcState : NpcState
{
    public override void OnStateEnter()
    {
        character.SetAgentDestination( new Vector3( Random.Range(-50, 50) , 0, Random.Range(-50, 50) ));
    }

    public override void OnStateExit()
    {
        
    }

    public override void OnStateRun()
    {
        if( !character.IsMoving() )
        {
            character.ChangeState(new IdleNpcState(character));
        }
    }

    public WanderNpcState(CharacterAI owner) : base(owner)
    {

    }
}
