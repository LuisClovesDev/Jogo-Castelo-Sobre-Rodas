using UnityEngine;
using UnityEngine.InputSystem;

public class PlayableCharacter : MonoBehaviour
{
    // Componentes
    private Rigidbody2D rigidBody;
    private Animator animator;

    // Estados públicos (acessíveis por habilidades)
    public float moveSpeed;
    public bool isInvincible = false;

    private Vector2 moveDirection;

    
    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();


    }

    // Método de extensão para inicialização (chamado uma vez)
    protected virtual void OnStart() { }

    private void Start()
    {
        OnStart();
    }

    // Input de movimento
    public virtual void ApplyMovement(InputAction.CallbackContext context)
    {
        moveDirection = context.ReadValue<Vector2>();
        int dir = GetCardinalDirection(moveDirection);
        animator?.SetInteger("Direction", dir);
    }

    private int GetCardinalDirection(Vector2 direction)
    {
        if (direction == Vector2.zero) return 0;
        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
            return direction.x > 0 ? 1 : 3;
        else
            return direction.y > 0 ? 2 : 4;
    }

    // Física
    public virtual void FixedUpdate()
    {
        if (rigidBody != null)
            rigidBody.linearVelocity = moveDirection * moveSpeed;
    }

    // Hooks para inputs (serão sobrescritos)
    public virtual void LeftClickAction(InputAction.CallbackContext context) { }
    public virtual void RightClickAction(InputAction.CallbackContext context) { }
}