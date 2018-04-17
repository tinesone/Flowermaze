using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackControl : MonoBehaviour
{

    void FixedUpdate()
    {
        Control control = this.transform.parent.GetComponent<Control>();
        if (control.x > 0 && control.y == 0)
            transform.rotation = Quaternion.Euler(0, 0, -90);
        if (control.x < 0 && control.y == 0)
            transform.rotation = Quaternion.Euler(0, 0, 90);
        if (control.x == 0 && control.y > 0)
            transform.rotation = Quaternion.Euler(0, 0, 0);
        if (control.x == 0 && control.y < 0)
            transform.rotation = Quaternion.Euler(0, 0, 180);
        if (control.x > 0 && control.y > 0)
            transform.rotation = Quaternion.Euler(0, 0, -45);
        if (control.x < 0 && control.y < 0)
            transform.rotation = Quaternion.Euler(0, 0, 135);
        if (control.x > 0 && control.y < 0)
            transform.rotation = Quaternion.Euler(0, 0, -135);
        if (control.x < 0 && control.y > 0)
            transform.rotation = Quaternion.Euler(0, 0, 45);

    }
}
