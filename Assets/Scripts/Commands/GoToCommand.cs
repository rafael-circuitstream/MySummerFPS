using UnityEngine;

public class GoToCommand : Command
{
    private bool isCanceled;
    private Vector3 goToDestination;
    public override void Cancel()
    {
        characterTarget.RemoveCommand(this);
    }

    public override void Execute()
    {
        characterTarget.GetAgent().SetDestination(goToDestination);
    }

    public override bool IsComplete()
    {
        if(isCanceled)
        {
            return true;
        }

        return characterTarget.GetAgent().remainingDistance <= characterTarget.GetAgent().stoppingDistance;
    }

    public GoToCommand(Vector3 destination)
    {
        goToDestination = destination;
    }
}
