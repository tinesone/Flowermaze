using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDashTrigger : MonoBehaviour
{

    private Enemy parentscript;

    public float dashCooldown = 6f;
    public float dashLengthCD = 3.5f;

    void Start()
    {
        parentscript = this.GetComponentInParent<Enemy>();
    }


    void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Player") && parentscript.attackTimer <= 0 && parentscript.dashTimer < 0)
        {
            parentscript.dashLength = dashLengthCD;
            parentscript.dashTimer = dashCooldown;
        }
        else if(parentscript.attackTimer > 0)
        {
            parentscript.dashTimer = 3f;
        }
    }
}
