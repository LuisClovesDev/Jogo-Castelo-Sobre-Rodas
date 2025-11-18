using UnityEngine;
using UnityEngine.InputSystem;

public abstract class PlayableCharacter : MonoBehaviour
{
    // Componentes
    private Rigidbody2D rigidBody;
    private Animator animator;

    public bool isInvincible = false;
    public PlayerClass playerClass;

    private Vector2 moveDirection;


    protected virtual void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }


    protected virtual void Start() { }


    private int GetCardinalDirection(Vector2 direction)
    {
        if (direction == Vector2.zero) return 0;
    
        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            if (direction.x > 0) return 1; else return 3;
        }
        else
        {
            if (direction.y > 0) return 2; else return 4;
        }
    }


    public virtual void ApplyMovement(InputAction.CallbackContext context)
    {
        moveDirection = context.ReadValue<Vector2>();

        animator.SetInteger("Direction", GetCardinalDirection(moveDirection));
    }

    // Física
    protected virtual void FixedUpdate()
    {
        rigidBody.linearVelocity = moveDirection * playerClass.moveSpeed;
    }

    // Hooks para inputs (serão sobrescritos)
    protected virtual void LeftClickAction(InputAction.CallbackContext context) { }
    protected virtual void RightClickAction(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            playerClass.specialSkill.OnPerformed(this, context);
        }
        else if (context.canceled)
        {
            playerClass.specialSkill.OnCanceled(this, context);
        }
    }
}
