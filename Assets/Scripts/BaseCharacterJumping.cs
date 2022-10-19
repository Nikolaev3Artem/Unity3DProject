using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCharacterJumping : MonoBehaviour
{
    [SerializeField] private float JumpForce;
    [SerializeField] private Transform CheckGround;
    [SerializeField] private LayerMask Mask;
    [SerializeField] private bool OnGround;
    private Rigidbody rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckGrounded();
        if (OnGround == false){
            if (Input.GetKeyDown(KeyCode.Space)){
                rb.velocity = new Vector3 (rb.velocity.x, JumpForce, rb.velocity.z);
            }
        }
    }

    void CheckGrounded(){
        RaycastHit hitInfo = new RaycastHit();

        Debug.DrawRay(transform.position, Vector3.down * 0.3f, Color.red);

        if (Physics.Raycast(transform.position, -Vector3.up, out hitInfo, 0.3f, Mask)){
            OnGround = false;
        }
        else {
            OnGround = true;
        }
    }
}
