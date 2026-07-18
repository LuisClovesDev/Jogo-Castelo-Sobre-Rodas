using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Inimigo_DATA data;

    private float currentHP;
    private Transform player;


    void OnEnable()
    {
        currentHP = data.Vida_Maxima;
        transform.localScale = Vector2.one * data.Tamanho;

        if (player == null)
            player = GameObject.FindGameObjectWithTag("Player").transform;

        if (HORDES_ADMIN.Instance != null)
            HORDES_ADMIN.Instance.Register(this);
    }

    void OnDisable()
    {
        if (HORDES_ADMIN.Instance != null)
            HORDES_ADMIN.Instance.Unregister(this);
    }

    int frameSkip = 2;

    void Update()
    {
        if (Time.frameCount % frameSkip == 0)
            ExecuteBehavior();
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, separationRadius);
    }

    void ExecuteBehavior()
{
    switch (data.behaviorType)
    {
        case EnemyBehaviorType.Mini_Arvore:
            MoveTowardsPlayer();
            break;

        case EnemyBehaviorType.Passaro:
            MoveTowardsPlayer();
            break;

        case EnemyBehaviorType.Arvore_Grande:
            MoveTowardsPlayer();
            break;

      //  case EnemyBehaviorType.ZigZag:
      //      MoveZigZag();
      //      break;
    }
}

    [SerializeField] float stopDistance = 0.5f;
    void MoveTowardsPlayer()
    {
        Vector3 toPlayer = player.position - transform.position;
        float distance = toPlayer.magnitude;

        Vector3 moveDir = toPlayer.normalized;

        float playerWeight = distance <= stopDistance ? 0f : 1f;

        Vector3 separation = GetSeparationVector();

        Vector3 finalMove =
            moveDir * playerWeight +
            separation * separationStrength;

        transform.position += finalMove * data.Velocidade * Time.deltaTime;
    }

    [SerializeField] float separationRadius = 0.6f;
    [SerializeField] float separationStrength = 0.5f;
    Vector3 GetSeparationVector()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(
            transform.position,
            separationRadius
        );

        Vector3 separation = Vector2.zero;
        int count = 0;

        foreach (var hit in hits)
        {
            if (hit.gameObject == gameObject)
                continue;

            if (!hit.CompareTag("Enemy"))
                continue;

            Vector3 diff = transform.position - hit.transform.position;
            float dist = diff.magnitude;

            if (dist > 0)
            {
                separation += diff.normalized / dist;
                count++;
            }
        }

        if (count > 0)
            separation /= count;

        return separation;
    }

}