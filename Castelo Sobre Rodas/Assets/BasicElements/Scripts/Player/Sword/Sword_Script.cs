using UnityEngine;

public class Sword_Script : MonoBehaviour
{
    //========================================#
    // BODY REFERENCE
    //========================================#

    [Header("Referências")]
    public Transform body;
    public Transform hand;

    //========================================#
    // RESTING STATE
    //========================================#

    private Vector3 idleLocalPosition;
    private Quaternion idleLocalRotation;

    private Vector3 handIdleLocalPosition;

    private bool isMoving;

    [Header("Idle Animation")]
    public float swordBobSpeed = 8f;
    public float swordBobAmount = 0.05f;

    public float handBobSpeed = 8f;
    public float handBobAmount = 0.05f;

    //========================================#
    // ATTACK LOGIC
    //========================================#

    [Header("Teste")]
    public bool test;
    public int testnumb;

    [Header("Ataque")]
    public float attackArc = 90f;
    public float attackDuration = 0.2f;
    public float distanceFromBody = 1.5f;

    [Header("Curva")]
    public AnimationCurve attackCurve =
        AnimationCurve.EaseInOut(0, 0, 1, 1);

    //========================================#
    // VISUAL LOGIC OF THE SWORD
    //========================================#

    [Header("Visual")]
    [SerializeField]
    private float spriteAngleOffset = -90f;

    private bool attacking;
    private float timer;

    private float startAngle;
    private float endAngle;

    //========================================#
    // INITIALIZATION
    //========================================#

    private void Start()
    {
        // Guarda a pose de descanso da espada
        idleLocalPosition = transform.localPosition;
        idleLocalRotation = transform.localRotation;

        // Guarda a pose de descanso da mão
        if (hand != null)
            handIdleLocalPosition = hand.localPosition;
    }

    //========================================#
    // UPDATE
    //========================================#

    private void Update()
    {
        // TEST BUTTON FOR ATTACK

        if (test)
        {
           if(testnumb == 0)
            {
                test = false;
                Attack(Vector2.left);
            }
            if (testnumb == 1)
            {
                test = false;
                Attack(Vector2.down);
            }
            if (testnumb == 2)
            {
                test = false;
                Attack(Vector2.up);
            }
            if (testnumb == 3)
            {
                test = false;
                Attack(Vector2.right);
            }
        }

        if (attacking)
        {
            UpdateAttack();
        }
        else
        {
            UpdateIdle();
        }
    }

    //========================================#
    // IDLE LOGIC
    //========================================#

    private void UpdateIdle()
    {
        // Personagem parado

        if (!isMoving)
        {
            transform.localPosition = idleLocalPosition;
            transform.localRotation = idleLocalRotation;

            if (hand != null)
                hand.localPosition = handIdleLocalPosition;

            return;
        }

        // Animação de balanço

        float swordOffset =
            -Mathf.Sin(Time.time * swordBobSpeed) * swordBobAmount;

        float handOffset =
             Mathf.Sin(Time.time * handBobSpeed) * handBobAmount;

        transform.localPosition =
            idleLocalPosition + new Vector3(0.439f, swordOffset);

        transform.localRotation =
            idleLocalRotation;

        if (hand != null)
        {
            hand.localPosition =
                handIdleLocalPosition + new Vector3(-0.38f, handOffset);
        }
    }

    //========================================#
    // ATTACK
    //========================================#

    public void Attack(Vector2 direction)
    {
        direction.Normalize();

        float baseAngle =
            Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        startAngle =
            baseAngle - attackArc * 0.5f;

        endAngle =
            baseAngle + attackArc * 0.5f;

        timer = 0f;
        attacking = true;
    }

    //========================================#
    // UPDATE ATTACK
    //========================================#

    private void UpdateAttack()
    {
        timer += Time.deltaTime;

        float t = timer / attackDuration;

        if (t >= 1f)
        {
            FinishAttack();
            return;
        }

        float curveValue =
            attackCurve.Evaluate(t);

        float currentAngle =
            Mathf.Lerp(startAngle, endAngle, curveValue);

        UpdateSwordPosition(currentAngle);
    }

    //========================================#
    // SWORD POSITION
    //========================================#

    private void UpdateSwordPosition(float angle)
    {
        float radians =
            angle * Mathf.Deg2Rad;

        Vector2 offset =
            new Vector2(
                Mathf.Cos(radians),
                Mathf.Sin(radians))
            * distanceFromBody;

        transform.position =
            body.position + (Vector3)offset;

        transform.rotation =
            Quaternion.Euler(
                0,
                0,
                angle + spriteAngleOffset);
    }

    //========================================#
    // FINISH ATTACK
    //========================================#

    private void FinishAttack()
    {
        attacking = false;

        // Retorna imediatamente para a pose inicial

        transform.localPosition = idleLocalPosition;
        transform.localRotation = idleLocalRotation;

        if (hand != null)
            hand.localPosition = handIdleLocalPosition;
    }

    //========================================#
    // PUBLIC METHODS
    //========================================#

    public void SetMoving(bool moving)
    {
        isMoving = moving;
    }

    public bool IsAttacking()
    {
        return attacking;
    }
}