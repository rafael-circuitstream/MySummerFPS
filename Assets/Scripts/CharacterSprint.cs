using UnityEngine;

public class CharacterSprint : MonoBehaviour
{
    [SerializeField] private CharacterMovement movement;

    public void StartSprinting()
    {
        movement.SetMoveSpeed(5);
    }

    public void StopSprinting()
    {
        movement.SetMoveSpeed(-5);
    }
}
