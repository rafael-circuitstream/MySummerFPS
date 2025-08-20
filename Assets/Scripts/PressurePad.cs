using UnityEngine;
using UnityEngine.Events;

public class PressurePad : MonoBehaviour
{
    [SerializeField] private Rigidbody correctRigidbody;
    public UnityEvent OnPressureEnter = new UnityEvent();
    public UnityEvent OnPressureExit = new UnityEvent();
    

    private void OnTriggerEnter(Collider other)
    {
        if(other.attachedRigidbody == correctRigidbody)
        {
            OnPressureEnter.Invoke();
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.attachedRigidbody == correctRigidbody)
        {
            OnPressureExit.Invoke();
        }
        
    }
}
