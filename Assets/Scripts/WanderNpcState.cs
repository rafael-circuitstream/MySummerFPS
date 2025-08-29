using UnityEngine;

public class WanderNpcState : NpcState
{
    public override void OnStateEnter()
    {
        character.SetAgentDestination( new Vector3( Random.Range(-10, 10) , 0, Random.Range(-10, 10) ));
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
