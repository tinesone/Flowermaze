using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackTrigger : MonoBehaviour {

    private Enemy parentscript;

    public float attackTimer;
    public float attackCooldown = 6f;

    void Start()
    {
        parentscript = this.GetComponentInParent<Enemy>();
    }

    void Update()
    {
        attackTimer -= .1f;
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            attackTimer = attackCooldown;
            parentscript.attackTimer = attackCooldown;
        }
    }
}
