using UnityEngine;

public class CubeGrab : MonoBehaviour, IInteractable
{

    [SerializeField] private Rigidbody cubeRigidbody;
    
    private Transform grabPoint;
    private bool isGrabbed;

    public void OnInteract()
    {
        if(isGrabbed == true)
        {
            //STOPPED GRABBING THE CUBE
            isGrabbed = false;
            cubeRigidbody.isKinematic = false;

            //Set parent to be the original parent
            cubeRigidbody.transform.SetParent(null);
        }
        else
        {
            //STARTED GRABBING THE CUBE
            isGrabbed = true;
            cubeRigidbody.isKinematic = true;

            

            //Set parent to be = camera / player
            cubeRigidbody.transform.SetParent(grabPoint);

            //Set position to be 1.5 meters away from camera
            cubeRigidbody.transform.position = grabPoint.position + (grabPoint.forward * 2f);
            cubeRigidbody.transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
    }
    public void SetGrabPointOrigin(Transform point)
    {
        grabPoint = point;
    }

    public void OnInteractionHoverEnter()
    {
        
    }

    public void OnInteractionHoverExit()
    {
        
    }



}
