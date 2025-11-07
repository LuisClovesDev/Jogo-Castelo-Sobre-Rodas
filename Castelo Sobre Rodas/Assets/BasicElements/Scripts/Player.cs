using UnityEngine;
using UnityEngine.InputSystem;

public class PlayableCharacter : MonoBehaviour
{

    private Rigidbody2D rigidBody;
    private Animator animator;
    public InputActionReference movementInput;

    public float moveSpeed;

    private Vector2 moveDirection;



	private void Start()
	{
		rigidBody = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
	}

    private void OnEnable()
    {
        movementInput.action.Enable(); 
    }
    private void OnDisable()
    {
        movementInput.action.Disable();
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


    public virtual void Update()
    {
        // Altera moveDirection todos os frames
        moveDirection = movementInput.action.ReadValue<Vector2>();

        // Faz a animação usando moveDirection todos os frames
        int directionCode = GetCardinalDirection(moveDirection);
        animator.SetInteger("Direction", directionCode);
    }


    public virtual void FixedUpdate()
    {
		// Aplica movimentação quando o frame não for pulado
        rigidBody.linearVelocity = moveDirection * moveSpeed;
    }
}
