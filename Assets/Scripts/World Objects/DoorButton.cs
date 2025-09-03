using UnityEngine;

public class DoorButton : MonoBehaviour, IInteractable
{
    [SerializeField] private Door doorReference;

    [SerializeField] private MeshRenderer buttonRenderer;
    [SerializeField] private Material hoverEnterMat;
    [SerializeField] private Material hoverExitMat;

    public void OnInteract()
    {
        //Open the door
        doorReference.isDoorUnlocked = true;
        doorReference.OpenDoor();
    }

    public void OnInteractionHoverEnter()
    {
        Debug.Log("Press F to interact");
        buttonRenderer.material = hoverEnterMat;
    }

    public void OnInteractionHoverExit()
    {
        buttonRenderer.material = hoverExitMat;
    }

}
