using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class CharacterCompanion : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private CharacterShooting shooting;
    [SerializeField] private Queue<Command> commands = new Queue<Command>();

    private Command currentCommand;

    public NavMeshAgent GetAgent()
    {
        return agent;
    }

    public CharacterShooting GetShooting()
    {
        return shooting;
    }
    public void RemoveCommand(Command toRemove)
    {
        //list.Remove(toRemove);
    }

    public void AddCommandToQueue(Command newCommand)
    {
        if(commands.Count >= 10)
        {
            Debug.LogWarning("TOO MANY COMMANDS");
            return;
        }

        newCommand.characterTarget = this;

        commands.Enqueue(newCommand);
    }

    private void Update()
    {
        if (currentCommand != null)
        {
            if (currentCommand.IsComplete())
            {
                currentCommand = null;
            }

            return;
        }


        if (commands.Count > 0)
        {
            currentCommand = commands.Dequeue();
            currentCommand.Execute();
        }
    }
}
