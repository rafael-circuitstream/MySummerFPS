using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private Vector3 moveDirection;
    [SerializeField] private Vector3 lookRotation;

    [SerializeField] private CharacterMovement movement;
    [SerializeField] private CharacterRotation rotation;
    [SerializeField] private CharacterSprint sprint;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        moveDirection.x = Input.GetAxisRaw("Horizontal");
        moveDirection.z = Input.GetAxisRaw("Vertical");
        moveDirection = moveDirection.normalized;

        lookRotation.x = -Input.GetAxisRaw("Mouse Y");
        lookRotation.y = Input.GetAxisRaw("Mouse X");

        movement.MoveCharacter(moveDirection);
        rotation.RotateByAngles(lookRotation);

        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            sprint.StartSprinting();
        }
        else if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            sprint.StopSprinting();
        }
    }
}
