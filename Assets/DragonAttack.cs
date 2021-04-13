using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonAttack : MonoBehaviour
{
    public Dragon dragon;

    private void Awake()
    {
        dragon = gameObject.GetComponentInParent<Dragon>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player Main Collider"))
        {
            dragon.Attack();
        }
    }
}
