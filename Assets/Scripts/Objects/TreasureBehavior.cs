using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureBehavior : MonoBehaviour
{
    [Header("Attributes")]
    public int dollarWorth = 10;
    protected bool picked = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !(picked))
        {
            picked = true;
            collision.gameObject.GetComponent<PlayerBehavior>().AddDollarToTotal(dollarWorth);
            Destroy(gameObject);
        }
    }
}
