using UnityEngine;

public class Door : MonoBehaviour
{
    public bool isDoorUnlocked;

    [SerializeField] private Animator doorAnimator;
    private void OnTriggerEnter(Collider other)
    {
        OpenDoor();
    }

    private void OnTriggerExit(Collider other)
    {
        CloseDoor();
    }

    public void OpenDoor()
    {
        if (isDoorUnlocked)
        {
            //Debug.Log(other.gameObject.name + " entered the trigger");

            //set animator bool to true
            doorAnimator.SetBool("Open", true);
        }
    }

    public void CloseDoor()
    {

        if (isDoorUnlocked)
        {
            //Debug.Log(other.gameObject.name + " exited the trigger");

            //set animator bool to false
            doorAnimator.SetBool("Open", false);
        }
    }

    public void UnlockDoor(bool unlocked)
    {
        isDoorUnlocked = unlocked;
    }
}
