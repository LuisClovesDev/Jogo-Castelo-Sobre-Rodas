using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{

    public Rigidbody2D rb;

    public float Movespeed;

    private Vector2 _moveDirection;

    public Animator animator;
   

    private float _horizontalInput; // Movimento horizontal (esquerda/direita)
    private float _verticalInput;   // Movimento vertical (cima/baixo)


    public InputActionReference Move;

    private void Start()
    {
        int direcao = animator.GetInteger("Direction"); // le parameter
    }

    private void OnEnable()
    {
        Move.action.Enable(); 
    }
    private void OnDisable()
    {
        Move.action.Disable();
    }

    private void Update()
    {
        _moveDirection = Move.action.ReadValue<Vector2>();

        if (_moveDirection != Vector2.zero)
        {
            Debug.Log("Movimento: " + _moveDirection);
        }

        StoreInputValues(_moveDirection);

        // Define Direction com base na direção dominante (4 direções)
        int directionCode = GetCardinalDirection(_moveDirection);
        animator.SetInteger("Direction", directionCode);
    }

    /// <summary>
    /// Retorna um código de direção com base no eixo dominante (ignora diagonais):
    /// 0 = parado
    /// 1 = direita
    /// 2 = cima
    /// 3 = esquerda
    /// 4 = baixo
    /// </summary>
    private int GetCardinalDirection(Vector2 direction)
    {
        if (direction == Vector2.zero)
            return 0;

        // Compara os valores absolutos para ver qual eixo é dominante
        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            // Movimento horizontal é mais forte
            return direction.x > 0 ? 1 : 3; // 1 = direita, 3 = esquerda
        }
        else
        {
            // Movimento vertical é mais forte (ou igual)
            return direction.y > 0 ? 2 : 4; // 2 = cima, 4 = baixo
        }
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(_moveDirection.x * Movespeed, _moveDirection.y * Movespeed);
    }

    private void StoreInputValues(Vector2 direction)
    {
        _horizontalInput = direction.x;
        _verticalInput = direction.y;
    }
}
