using System.Collections.Generic;
using UnityEngine;

public class EnemyDetector : MonoBehaviour
{
    //========================================#
    // DETECTION AREA
    //========================================#

    [Header("Detection Area")]
    [SerializeField]
    private float detectionRadius = 1.5f;

    //========================================#
    // DETECTED ENEMIES
    //========================================#

    private readonly List<Enemy> detectedEnemies =
        new List<Enemy>();

    //========================================#
    // DETECTOR CACHE
    //========================================#

    private Enemy closestEnemy;
    private Enemy farthestEnemy;

    private Enemy closestLeftEnemy;
    private Enemy closestRightEnemy;
    private Enemy closestTopEnemy;
    private Enemy closestBottomEnemy;

    private int totalEnemies;
    private int enemiesInsideArea;
    private int enemiesOutsideArea;

    //========================================#
    // GIZMOS
    //========================================#

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere(
            transform.position,
            detectionRadius);

        DrawEnemyConnections();
    }

    //========================================#
    // GIZMOS ENEMIES
    //========================================#

    private void DrawEnemyConnections()
    {
        if (HORDES_ADMIN.Instance == null)
            return;

        IReadOnlyList<Enemy> enemies =
            HORDES_ADMIN.Instance.GetEnemies();

        float detectionRadiusSqr =
            detectionRadius * detectionRadius;

        foreach (Enemy enemy in enemies)
        {
            if (enemy == null)
                continue;

            if (!enemy.gameObject.activeInHierarchy)
                continue;

            float sqrDistance =
                ((Vector2)enemy.transform.position -
                 (Vector2)transform.position).sqrMagnitude;

            Gizmos.color =
                sqrDistance <= detectionRadiusSqr
                ? Color.green
                : Color.red;

            Gizmos.DrawLine(
                transform.position,
                enemy.transform.position);
        }
    }

    //========================================#
    // START
    //========================================#

    private void Start()
    {
        if (HORDES_ADMIN.Instance == null)
        {
            Debug.LogError("HORDES_ADMIN não encontrado.");
            enabled = false;
        }
    }

    //========================================#
    // UPDATE DETECTED ENEMIES
    //========================================#

    public void UpdateDetectedEnemies()
    {
        detectedEnemies.Clear();

        closestEnemy = null;
        farthestEnemy = null;

        closestLeftEnemy = null;
        closestRightEnemy = null;
        closestTopEnemy = null;
        closestBottomEnemy = null;

        totalEnemies = 0;
        enemiesInsideArea = 0;
        enemiesOutsideArea = 0;

        float detectionRadiusSqr =
            detectionRadius * detectionRadius;

        float closestDistance = float.MaxValue;
        float farthestDistance = 0f;

        float closestLeftDistance = float.MaxValue;
        float closestRightDistance = float.MaxValue;
        float closestTopDistance = float.MaxValue;
        float closestBottomDistance = float.MaxValue;

        IReadOnlyList<Enemy> enemies =
            HORDES_ADMIN.Instance.GetEnemies();

        foreach (Enemy enemy in enemies)
        {
            if (enemy == null)
                continue;

            if (!enemy.gameObject.activeInHierarchy)
                continue;

            totalEnemies++;

            Vector2 direction =
                (Vector2)enemy.transform.position -
                (Vector2)transform.position;

            float sqrDistance =
                direction.sqrMagnitude;

            //----------------------------------
            // Fora da área
            //----------------------------------

            if (sqrDistance > detectionRadiusSqr)
            {
                enemiesOutsideArea++;
                continue;
            }

            //----------------------------------
            // Dentro da área
            //----------------------------------

            enemiesInsideArea++;

            detectedEnemies.Add(enemy);

            //----------------------------------
            // Mais próximo geral
            //----------------------------------

            if (sqrDistance < closestDistance)
            {
                closestDistance = sqrDistance;
                closestEnemy = enemy;
            }

            //----------------------------------
            // Mais distante geral
            //----------------------------------

            if (sqrDistance > farthestDistance)
            {
                farthestDistance = sqrDistance;
                farthestEnemy = enemy;
            }

            //----------------------------------
            // ESQUERDA
            //----------------------------------

            if (direction.x < 0f)
            {
                if (sqrDistance < closestLeftDistance)
                {
                    closestLeftDistance = sqrDistance;
                    closestLeftEnemy = enemy;
                }
            }

            //----------------------------------
            // DIREITA
            //----------------------------------

            if (direction.x > 0f)
            {
                if (sqrDistance < closestRightDistance)
                {
                    closestRightDistance = sqrDistance;
                    closestRightEnemy = enemy;
                }
            }

            //----------------------------------
            // CIMA
            //----------------------------------

            if (direction.y > 0f)
            {
                if (sqrDistance < closestTopDistance)
                {
                    closestTopDistance = sqrDistance;
                    closestTopEnemy = enemy;
                }
            }

            //----------------------------------
            // BAIXO
            //----------------------------------

            if (direction.y < 0f)
            {
                if (sqrDistance < closestBottomDistance)
                {
                    closestBottomDistance = sqrDistance;
                    closestBottomEnemy = enemy;
                }
            }
        }
    }

    //========================================#
    // GET DETECTED ENEMIES
    //========================================#

    public IReadOnlyList<Enemy> GetDetectedEnemies()
    {
        return detectedEnemies;
    }

    //========================================#
    // GET CLOSEST ENEMY
    //========================================#

    public Enemy GetClosestEnemy()
    {
        return closestEnemy;
    }

    //========================================#
    // GET FARTHEST ENEMY
    //========================================#

    public Enemy GetFarthestEnemy()
    {
        return farthestEnemy;
    }

    //========================================#
    // GET TOTAL ENEMIES
    //========================================#

    public int GetTotalEnemies()
    {
        return totalEnemies;
    }

    //========================================#
    // GET ENEMIES INSIDE AREA
    //========================================#

    public int GetEnemiesInsideArea()
    {
        return enemiesInsideArea;
    }

    //========================================#
    // GET ENEMIES OUTSIDE AREA
    //========================================#

    public int GetEnemiesOutsideArea()
    {
        return enemiesOutsideArea;
    }

    //========================================#
    // LEFT
    //========================================#

    public Enemy GetClosestLeftEnemy()
    {
        return closestLeftEnemy;
    }

    //========================================#
    // RIGHT
    //========================================#

    public Enemy GetClosestRightEnemy()
    {
        return closestRightEnemy;
    }

    //========================================#
    // TOP
    //========================================#

    public Enemy GetClosestTopEnemy()
    {
        return closestTopEnemy;
    }

    //========================================#
    // BOTTOM
    //========================================#

    public Enemy GetClosestBottomEnemy()
    {
        return closestBottomEnemy;
    }
}