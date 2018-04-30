using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
    public int dmg = 20;
    public int maxHealth = 503;
    public float armor = 60;
    public float speed = 10f;
    public float y;
    public float x;

    private int curHealth = 0;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        curHealth = maxHealth;
    }

    void FixedUpdate()
    {
        y = Input.GetAxisRaw("Vertical") * speed;
        x = Input.GetAxisRaw("Horizontal") * speed;
        rb.velocity = new Vector2(x, y);
    }

    private void Update()
    {
        if (curHealth <= 0)
        {
            print("died");
            Invoke("remove", 0.4f);
        }
    }


    public void ApplyDamage(float damage)
    {
        damage -= damage * armor / 100f;
        curHealth -= (int)damage;
        print(curHealth);
    }

    void remove()
    {
        Destroy(gameObject);
    }
}
