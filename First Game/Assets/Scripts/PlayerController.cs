using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float jumpForce = 25.0f;
    private Rigidbody2D rigidBody;
    public LayerMask groundLayerMask;
    public Animator animator;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        animator.SetBool("isAlive", true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            Jump();
        }

        animator.SetBool("isGrounded", IsOnTheFloor());
    }

    void Jump()
    {
        if (IsOnTheFloor())
        {
            rigidBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }        
    }

    bool IsOnTheFloor()
    {
        if (Physics2D.Raycast(transform.position, Vector2.down, 1.0f, groundLayerMask.value))
        {
            Debug.Log(true);
            return true;
        }
        else
        {
            Debug.Log(false);
            return false;
        }
    }
}
