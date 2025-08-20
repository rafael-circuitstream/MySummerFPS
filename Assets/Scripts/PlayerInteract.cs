using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] private Transform eyeOrigin;
    [SerializeField] private LayerMask interactionLayer;

    private IInteractable currentInteraction;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(eyeOrigin.position, eyeOrigin.forward * 5f);

        RaycastHit hitInfo;

        IInteractable interactable = null;

        if(Physics.Raycast(eyeOrigin.position, eyeOrigin.forward, out hitInfo, 5f, interactionLayer))
        {
            interactable = hitInfo.collider.GetComponent<IInteractable>();
            
            if(interactable != null)
            {
                //DETECTED INTERACTION ON MOUSE POSITION

                currentInteraction = interactable;
                interactable.OnInteractionHoverEnter();
            }

        }

        if(interactable == null) //NO NEW INTERACTION DETECTED
        {
            if(currentInteraction != null) //IF THERE ARE ANY CURRENT INTERACTION, THEN "HOVER EXIT"
            {
                currentInteraction.OnInteractionHoverExit();
            }

            currentInteraction = null;
        }


        if(Input.GetKeyDown(KeyCode.F) && currentInteraction != null)
        {
            if(currentInteraction is CubeGrab cube)
            {
                cube.SetGrabPointOrigin(eyeOrigin);
            }

            currentInteraction.OnInteract();
        }

        
    }
}
