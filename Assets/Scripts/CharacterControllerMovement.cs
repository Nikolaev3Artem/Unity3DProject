using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CharacterControllerMovement : BaseCharacterMovement
{
    private Animator animator;
    private CharacterController characterController;
    private void Start()
    {
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
    }
    private new void Update()
    {
        base.Update();
        characterController.Move(movementVector * movementSpeed * Time.deltaTime);
        animator.SetFloat("speed", Vector3.ClampMagnitude(movementVector, 1).magnitude);
    }
}
