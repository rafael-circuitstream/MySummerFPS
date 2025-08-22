using UnityEngine;
using UnityEngine.AI;

public class CharacterAI : MonoBehaviour
{
    [SerializeField] private NavMeshAgent myAgent;
    [SerializeField] private Transform target;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        myAgent.SetDestination(target.position);

    }
}
