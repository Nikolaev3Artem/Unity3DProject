using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class RigidbodyMovement : BaseCharacterMovement
{
    // Прости почти все переписал)
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
        //animator.SetFloat("speed", Vector3.ClampMagnitude(movementVector, 1).magnitude);
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        if (v > 0 || v < 0 || h > 0 || h < 0){ // Так надо чтобы мы смогли сделать чтобы у персонажа были анимации во все стороны :3
            animator.SetBool("Run", true);
        }
        if (v == 0){
            if (h == 0){
            animator.SetBool("Run", false);
            }
        }
    }
}