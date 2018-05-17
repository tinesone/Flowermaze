using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretControl : MonoBehaviour
{

    /*void Update()
    {
        Control control = this.transform.parent.GetComponent<Control>();
        float y = Input.GetAxisRaw("Vertical") * control.speed;
        float x = Input.GetAxisRaw("Horizontal") * control.speed;
        if (x > 0 && y == 0)
            transform.rotation = Quaternion.Euler(0, 0, -90);
        if (x < 0 && y == 0)
            transform.rotation = Quaternion.Euler(0, 0, 90);
        if (x == 0 && y > 0)
            transform.rotation = Quaternion.Euler(0, 0, 0);
        if (x == 0 && y < 0)
            transform.rotation = Quaternion.Euler(0, 0, 180);
        if (x > 0 && y > 0)
            transform.rotation = Quaternion.Euler(0, 0, -45);
        if (x < 0 && y < 0)
            transform.rotation = Quaternion.Euler(0, 0, 135);
        if (x > 0 && y < 0)
            transform.rotation = Quaternion.Euler(0, 0, -135);
        if (x < 0 && y > 0)
            transform.rotation = Quaternion.Euler(0, 0, 45);
    }*/
    void Update()
    {
        Vector3 dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);

    }
}
