using UnityEngine;
using UnityEngine.AI;

public class MonsterAI : MonoBehaviour
{
    public Transform player;
    public Light lanterna; // Referência à lanterna do jogador
    public NavMeshAgent agent;
    public Animator animator;

    void Start()
    {
    }

    void Update()
    {
        if (lanterna.enabled) // Se a lanterna estiver ligada
        {
            agent.SetDestination(player.position); // Sempre persegue o jogador
            animator.SetBool("isWalking", true); // Ativa animação de caminhada
        }
        else
        {
            agent.SetDestination(transform.position); // Monstro para
            animator.SetBool("isWalking", false); // Volta para animação Idle
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Game Over - O monstro te pegou!");
        }
    }
}
