using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EntranceBehavior : MonoBehaviour
{
    [Header("Variables")]
    private bool triggerOn = true;

    void Start()
    {
        // Disable trigger after 0.1 seconds
        StartCoroutine(triggerLength());

        // Teleport player
        PlayerBehavior player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBehavior>();
        Vector2 playerPosition = new(transform.position.x, (float)(transform.position.y + 0.5));
        player.MoveTo(playerPosition);
    }

    // Clean area around spawn so player will not get hit on start
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && triggerOn)
        {
            Destroy(collision.gameObject);
        }
    }

    public IEnumerator triggerLength()
    {
        yield return new WaitForSeconds(0.1f);
        triggerOn = false;
    }
}
