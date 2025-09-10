using UnityEngine;

public class ColliderReaction : MonoBehaviour
{
    [SerializeField] private float detectionRange;
    [SerializeField] private LayerMask targetLayer;


    private void OnCollisionEnter(Collision collision)
    {

        Collider[] hitColliders = Physics.OverlapSphere(transform.position, detectionRange, targetLayer);

        foreach (Collider hitCollider in hitColliders)
        {
            Debug.Log(hitCollider.name);
            //hitCollider.GetComponent<CharacterAI>().SetAgentDestination(transform.position);
        }


        /*
        if (Physics.SphereCast(transform.position, detectionRange, Vector3.zero, out hitInfo, detectionRange, targetLayer))
        {
            if(hitInfo.rigidbody)
            {
                Debug.Log(hitInfo.collider.name);
            }
            
            if(hitInfo.collider.CompareTag("Enemy"))
            {
                //Creating a state of "Investigating" and set destination to be transform.position
                hitInfo.collider.GetComponent<CharacterAI>().SetAgentDestination(transform.position);
            }
        }
        */

        if(collision.collider.GetComponent<IInteractable>() != null)
        {
            collision.collider.GetComponent<IInteractable>().OnInteract();
        }


    }
}
