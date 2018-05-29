using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDashTrigger : MonoBehaviour
{

    private Enemy parentscript;

    public float dashLength = 6f;
    public float dashCD = 20f;

    void Start()
    {
        parentscript = this.GetComponentInParent<Enemy>();
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Player") && parentscript.attackTimer <= 0 && parentscript.dashCD < 0)
        {
            parentscript.dashTimer = dashLength;
            parentscript.dashCD = dashCD;
        }
    }
}
