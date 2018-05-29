using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackTrigger : MonoBehaviour {

    private Enemy parentscript;

    public float attackCooldown = 6f;

    void Start()
    {
        parentscript = this.GetComponentInParent<Enemy>();
    }



    void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            parentscript.attackTimer = attackCooldown;
            col.SendMessageUpwards("ApplyDamage", parentscript.dmg);
        }
    }
}
