using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehavior : MonoBehaviour
{
    [Header("Reference")]
    protected NavMeshAgent agent;
    public Health health;
    public Animator animator;

    [Header("Variables")]
    protected Vector2 movementDirection;

    void Start()
    {
        StartCoroutine(HoldNavAgent());
        // Navmesh agent setup
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;

        // health setup
        health = GetComponent<Health>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Animate();
    }

    public IEnumerator HoldNavAgent()
    {
        yield return new WaitForSeconds(0.1f);
        agent.enabled = true;
    }

    private void Move(Transform t)
    {
        agent.SetDestination(t.position);
        movementDirection = agent.velocity;
        movementDirection.Normalize();
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (agent.enabled) Move(collision.transform);
        }
    }

    public void ReduceHealth(int damage)
    {
        health.RemoveHealth(damage); 
        if (health.GetHealth() < 0)
        {
            Destroy(gameObject);
        }
    }

    void Animate()
    {
        if (movementDirection != Vector2.zero)
        {
            animator.SetFloat("Horizontal", movementDirection.x);
            animator.SetFloat("Vertical", movementDirection.y);
        }
    }
}
