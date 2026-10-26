using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [Header("Attributes")]
    public int totalHealth = 1;

    public int GetHealth () { return totalHealth; }

    public void SetHealth (int health) { totalHealth = health; }

    public void AddHealth(int add) { totalHealth += add; }

    public void RemoveHealth(int remove) {  totalHealth -= remove; }
}
