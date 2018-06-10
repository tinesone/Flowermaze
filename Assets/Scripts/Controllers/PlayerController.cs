using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;
    public GameObject attackHitbox;

    private float y;
    private float x;
    private Rigidbody2D rb;
    private CharacterCombat playerCombat;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerCombat = GetComponent<CharacterCombat>();
    }

    void FixedUpdate()
    {
        y = Input.GetAxisRaw("Vertical") * speed * Time.deltaTime;
        x = Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime;
        rb.velocity = new Vector2(x, y);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }
    }

    void Attack()
    {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(attackHitbox.transform.position, 1.5f);
        int i = 0;
        while (i < hitColliders.Length)
        {
            Debug.Log(hitColliders[i]);
            CharacterStats characterStats = hitColliders[i].GetComponent<CharacterStats>();
            if (characterStats != null)
            {
                playerCombat.Attack(characterStats);
            }
            i++;
        }
    }
}
