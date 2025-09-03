using UnityEngine;

public class CharacterSprint : MonoBehaviour
{
    [SerializeField] private CharacterMovement movement;

    public void StartSprinting()
    {
        movement.IncreaseMoveSpeed(5);
    }

    public void StopSprinting()
    {
        movement.IncreaseMoveSpeed(-5);
    }
}
