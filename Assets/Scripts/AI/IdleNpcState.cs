using UnityEngine;

public class IdleNpcState : NpcState
{
    private float timer = 0;
    public override void OnStateEnter()
    {
        //Debug.Log("Start Idle");
        timer = Random.Range(2f, 4f);
    }

    public override void OnStateExit()
    {
        //Debug.Log("Not Idle anymore");
    }

    public override void OnStateRun()
    {
        //Debug.Log("Waiting for command");
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            character.ChangeState(new WanderNpcState(character));
        }
    }

    public IdleNpcState(CharacterAI owner) : base(owner)
    {

    }
}
