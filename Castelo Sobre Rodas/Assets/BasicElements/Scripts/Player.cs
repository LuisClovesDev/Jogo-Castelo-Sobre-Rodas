using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    // Componentes
    private Rigidbody2D rigidBody;
    private Animator animator;

<<<<<<< Updated upstream
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
        // Define direÁ„o do personagem na animaÁ„o
        
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

        // Faz a animaÁ„o usando moveDirection todos os frames
        int directionCode = GetCardinalDirection(moveDirection);
        animator.SetInteger("Direction", directionCode);
    }


    private void FixedUpdate()
    {
        rb.linearVelocity = moveDirection * moveSpeed; // Aplica movimentaÁ„o
    }
}
=======
    // Estados p√∫blicos (acess√≠veis por habilidades)
    public float moveSpeed;
    public bool isInvincible = false;


    // Em PlayableCharacter.cs
    public float baseMoveSpeed; // ‚Üê valor base (nunca muda)
    private float currentMoveSpeed; // ‚Üê usado para restaurar
    public float savedMoveSpeed;

    private Vector2 moveDirection;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        baseMoveSpeed = moveSpeed; // salva o valor inicial uma vez

    }

    // M√©todo de extens√£o para inicializa√ß√£o (chamado uma vez)
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

    // F√≠sica
    public virtual void FixedUpdate()
    {
        if (rigidBody != null)
            rigidBody.linearVelocity = moveDirection * moveSpeed;
    }

    // Hooks para inputs (ser√£o sobrescritos)
    public virtual void LeftClickAction(InputAction.CallbackContext context) { }
    public virtual void RightClickAction(InputAction.CallbackContext context) { }
}
>>>>>>> Stashed changes
