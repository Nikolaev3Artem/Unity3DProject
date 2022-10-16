using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class RigidbodyMovement : BaseCharacterMovement
{
    private Animator animator;
    private new Rigidbody rigidbody;
    private void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        base.Update();
        rigidbody.MovePosition(transform.position + movementVector * movementSpeed * Time.fixedDeltaTime);
        animator.SetFloat("speed", Vector3.ClampMagnitude(movementVector, 1).magnitude);
    }
}