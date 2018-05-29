using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Enemy : MonoBehaviour
{
    public int armor = 30;
    public float maxHealth = 200f;
    public AudioClip death;
    public AudioClip hit;
    private AudioSource audioSource;

    Vector2 playerpos;

    private float curHealth;

    public float dmg;

    public float speed = .5f;
    public float dashSpeed = 5f;

    public float attackTimer;
    public float dashTimer;
    public float dashCD;


    private GameObject player;

    void Start()
    {
        curHealth = maxHealth;
        player = GameObject.FindGameObjectWithTag("Player");
        audioSource = GetComponent<AudioSource>();
    }


    void Update()
    {
        attackTimer -= .1f;
        dashTimer -= .1f;
        dashCD -= .1f;


        Vector2 pos = transform.position;

        if (attackTimer > 0)
        {
            transform.position = Vector2.MoveTowards(pos, playerpos, (dashSpeed * -1) * Time.deltaTime);
        }
        else if (dashTimer <= 0)
        {
            playerpos = player.transform.position;
            transform.position = Vector2.MoveTowards(pos, playerpos, speed * Time.deltaTime);
        }

        else if (dashTimer > 0)
        {
            transform.position = Vector2.MoveTowards(pos, playerpos, dashSpeed * Time.deltaTime);
            if (pos == playerpos)
            {
                dashTimer = -1;
            }
        }
    }


    public void ApplyDamage(float dmg)
    {
        dmg -= dmg * armor / 100f;
        curHealth -= dmg;
        print(curHealth);
        if (curHealth > 0)
        {
            print(curHealth);
            //audioSource.PlayOneShot(hit, 1f);
        }
        else
        {
            print("died");
            audioSource.PlayOneShot(death, 1f);
            Destroy(gameObject);
        }
    }
}