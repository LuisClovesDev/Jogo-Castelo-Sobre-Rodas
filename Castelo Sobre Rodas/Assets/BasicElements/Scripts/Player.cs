using UnityEngine;
using UnityEngine.InputSystem;

public class PlayableCharacter : MonoBehaviour
{

	private Rigidbody2D rigidBody;
	private Animator animator;

	public float moveSpeed;

	private Vector2 moveDirection;

	// Puxa os componentes para uso no código
	private void Start()
	{
		rigidBody = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
	}

	// Retorna direção cardinal do personagem
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

	// Função puxada somente quando houver alteração no input
	public virtual void ApplyMovement(InputAction.CallbackContext context)
	{
		moveDirection = context.ReadValue<Vector2>();

		// Troca a direção na qual o personagem está andando na animação
		animator.SetInteger("Direction", GetCardinalDirection(moveDirection));
	}

	// Aplica movimentação quando o frame não for pulado
	public virtual void FixedUpdate()
	{
		rigidBody.linearVelocity = moveDirection * moveSpeed;
	}

	// Para uso nas classes que herdarem dessa
	public virtual void LeftClickAction(InputAction.CallbackContext context)
	{

	}


	public virtual void RightClickAction(InputAction.CallbackContext context)
	{

	}

}
