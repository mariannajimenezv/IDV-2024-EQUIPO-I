using UnityEngine;
using UnityEngine.AI;

public class BadEnemy : MonoBehaviour
{
    [Header("Configuración")]
    public NavMeshAgent agent;

    public Transform player;

    public LayerMask Ground, Player;
    
    
    [Header("Estadisticas del enemigo")]
    
    public int health = 5;
    public float sightRange; 
    public float attackRange;
    public float attackCooldown;

    public int damage = 1;
    public bool hasAttacked;

    [Header("Ruta de Patrulla")]
    public Vector3 patrolPoint;
    bool patrolPointSet;
    public float patrolPointRange;

    public bool inSightRange, inAttackRange;


    private void Awake()
    {
        player = GameObject.Find("Lumi").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        // Definicion del rango de vision y ataque del enemigo
        inSightRange = Physics.CheckSphere(transform.position, sightRange, Player);
        inAttackRange = Physics.CheckSphere(transform.position, attackRange, Player);

        if (!inSightRange && !inAttackRange) IdlePatrol();
        if (inSightRange && !inAttackRange) ChasingPlayer();
        if (inSightRange && inAttackRange) Attack();
        if (health < 0) Die();;
    }


    private void IdlePatrol()
    {
        if (!patrolPointSet) SetPatrolPoint();

        if(patrolPointSet) agent.SetDestination(patrolPoint);

        Vector3 patrolPointDistance = transform.position - patrolPoint;

        if(patrolPointDistance.magnitude < 1f) patrolPointSet = false;
    }
    private void SetPatrolPoint()
    {
        float randomZ = Random.Range(-patrolPointRange, patrolPointRange);
        float randomX = Random.Range(-patrolPointRange, patrolPointRange);

        patrolPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        // Comprobacion que el punto de destino este en el mapa
        if(Physics.Raycast(patrolPoint, -transform.up, 2f, Ground)) patrolPointSet = true;
    }

    private void ChasingPlayer()
    {
        agent.SetDestination(player.position);
    }
    private void Attack()
    {
        if(inAttackRange)
        {
            Debug.Log("Enemigo golpea a Lumi ");
        }
        
        hasAttacked = true;
        Invoke(nameof(ResetAttack), attackCooldown);
    }
    private void ResetAttack()
    {
        hasAttacked = false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            LumiController player = collision.gameObject.GetComponent<LumiController>();

            if (player != null)
            {
                if (player.isInvincible)
                {
                    Debug.Log("¡El enemigo tocó a Lumi invencible y murió!");
                    Die();
                }
                else
                {
                    player.TakeDamage(damage);
                }
            }
        }
    }

    public void Die()
    {
        
        Destroy(gameObject);
    }
}
