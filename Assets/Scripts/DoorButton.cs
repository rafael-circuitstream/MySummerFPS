using UnityEngine;

public class DoorButton : MonoBehaviour, IInteractable
{
    public void OnInteract()
    {
        //Open the door
    }

    public void OnInteractionHoverEnter()
    {
        Debug.Log("Press F to interact");
    }

    public void OnInteractionHoverExit()
    {
        
    }

}
