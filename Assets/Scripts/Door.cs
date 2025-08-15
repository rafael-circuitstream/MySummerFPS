using UnityEngine;

public class Door : MonoBehaviour
{
    public bool isDoorUnlocked;


    [SerializeField] private Animator doorAnimator;
    private void OnTriggerEnter(Collider other)
    {
        if(isDoorUnlocked)
        {
            //Debug.Log(other.gameObject.name + " entered the trigger");

            //set animator bool to true
            doorAnimator.SetBool("Open", true);
        }

    }

    private void OnTriggerExit(Collider other)
    {

        if(isDoorUnlocked)
        {
            //Debug.Log(other.gameObject.name + " exited the trigger");

            //set animator bool to false
            doorAnimator.SetBool("Open", false);
        }

    }
}
