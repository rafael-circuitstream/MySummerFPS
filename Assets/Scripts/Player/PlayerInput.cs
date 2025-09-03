using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private Vector3 moveDirection;
    [SerializeField] private Vector3 lookRotation;

    [SerializeField] private CharacterMovement movement;
    [SerializeField] private CharacterRotation rotation;
    [SerializeField] private CharacterSprint sprint;
    [SerializeField] private CharacterJump jump;
    [SerializeField] private CharacterShooting shooting;
    [SerializeField] private CommandGiver commandGiver;

    [SerializeField] private MouseClickStrategy currentMouseClickStrategy;

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

        if (movement != null)
        {
            movement.MoveCharacter(moveDirection);
        }

        if (rotation != null)
        {
            rotation.RotateByAngles(lookRotation);
        }
        
        if (sprint != null)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                sprint.StartSprinting();
            }
            else if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                sprint.StopSprinting();
            }
        }

        if(jump != null)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                jump.Jump();
            }
        }

        if(currentMouseClickStrategy != null)
        {
            if(Input.GetMouseButtonDown(0))
            {
                currentMouseClickStrategy.ExecuteStrategy();
            }
        }


        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentMouseClickStrategy = shooting;
        }
        else if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentMouseClickStrategy = commandGiver;
        }
    }
}
