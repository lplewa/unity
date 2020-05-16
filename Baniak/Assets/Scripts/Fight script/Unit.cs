using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public string unitName;
    public int damage;
    public int maxHealthPoints;
    public int currentHealthPoints;

    public bool TakeDamage(int damage)
    {
        currentHealthPoints -= damage;
        if (currentHealthPoints <= 0) return true;
        else return false;
    }
}
