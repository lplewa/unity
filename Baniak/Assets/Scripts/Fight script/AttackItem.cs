using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackItem : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision!");
        Destroy(gameObject);
    }

}
