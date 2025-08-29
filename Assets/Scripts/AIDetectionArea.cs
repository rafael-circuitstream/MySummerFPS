using UnityEngine;

public class AIDetectionArea : MonoBehaviour
{
    [SerializeField] private bool canSeeTarget;
    [SerializeField] private Transform eyeOrigin;
    private CharacterAI characterAiReference;

    private void Awake()
    {
        characterAiReference = GetComponentInParent<CharacterAI>();
    }

    private void OnTriggerStay(Collider other)
    {   
        
        if(canSeeTarget == false)
        {
            RaycastHit hitInfo = new RaycastHit();

            CharacterController character = other.GetComponent<CharacterController>();

            if(character == null)
            {
                return;
            }

            Vector3 directionToPlayer = (character.transform.position + character.center) - eyeOrigin.position;

            bool hasHit = Physics.Raycast(eyeOrigin.position, directionToPlayer, out hitInfo);

            if (hasHit && hitInfo.collider.transform == character.transform)
            {
                canSeeTarget = true;
                ChaseTarget(character.transform);
            }
        }


    }


    private void OnTriggerExit(Collider other)
    {
        characterAiReference.ChangeState( new IdleNpcState(characterAiReference) );
        canSeeTarget = false;
    }

    private void ChaseTarget(Transform target)
    {
        ChaseNpcState chaseState = new ChaseNpcState(characterAiReference);
        chaseState.targetToChase = target;

        characterAiReference.ChangeState(chaseState);
    }

}
