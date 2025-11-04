using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{

    public Rigidbody2D rb;
    public Animator animator;
    public InputActionReference Move;

    public float moveSpeed;

    private Vector2 moveDirection;





    private void OnEnable()
    {
        Move.action.Enable(); 
    }
    private void OnDisable()
    {
        Move.action.Disable();
    }


    private int GetCardinalDirection(Vector2 direction)
    {
        // Define direção do personagem na animação
        
        if (direction == Vector2.zero) return 0;
        

        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            if (direction.x > 0) {return 1;} else {return 3;};
        }
        else
        {
            if (direction.y > 0) {return 2;} else {return 4;}
        }
    }


    private void Update()
    {
        // Altera moveDirection todos os frames
        moveDirection = Move.action.ReadValue<Vector2>();

        // Faz a animação usando moveDirection todos os frames
        int directionCode = GetCardinalDirection(moveDirection);
        animator.SetInteger("Direction", directionCode);
    }


    private void FixedUpdate()
    {
        rb.linearVelocity = moveDirection * moveSpeed; // Aplica movimentação
    }
}
