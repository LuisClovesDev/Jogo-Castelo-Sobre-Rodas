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


    public virtual void ApplyMovement(Vector2 direction)
    {
        moveDirection = direction;
        animator.SetInteger("Direction", GetCardinalDirection(moveDirection));
    }

    // Física
    protected virtual void FixedUpdate()
    {
        rigidBody.linearVelocity = moveDirection * playerClass.moveSpeed;
    }

    // Hooks para inputs (serão sobrescritos)
    protected virtual void LeftClickAction(bool pressed) { }

    protected virtual void RightClickAction(bool pressed)
    {
        if (pressed)
            playerClass.specialSkill.OnPerformed(this);
        else
            playerClass.specialSkill.OnCanceled(this);
    }
}
