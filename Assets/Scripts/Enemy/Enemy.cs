using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Enemy : MonoBehaviour
{
    public int armor = 30;
    public float maxHealth = 200f;
    public AudioClip death;
    public AudioClip hit;
    private AudioSource audioSource;

    private Vector2 playerpos;

    private float curHealth;

    public float dmg;

    public float speed = .5f;
    public float dashSpeed = 5f;

    public float attackTimer;
    public float dashTimer;
    public float dashCD;


    private GameObject player;

    private Rigidbody2D rb;

    void Start()
    {
        curHealth = maxHealth;
        player = GameObject.FindGameObjectWithTag("Player");
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        attackTimer -= .1f;
        dashTimer -= .1f;
        dashCD -= .1f;

        Vector2 pos = this.transform.position; //http://bit.ly/VECTOR2

        if (attackTimer > 0)
        {
            rb.velocity = new Vector2 (GetRelativePos(playerpos, pos), 0);
        }
        else if (dashTimer <= 0)
        {
            playerpos = player.transform.position;
            rb.velocity = new Vector2(GetRelativePos(playerpos, pos), 0);
        }
        

        else if (dashTimer > 0)
        {
            rb.velocity = new Vector2(GetRelativePos(playerpos, pos), 0);
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


    public static float GetRelativePos(Vector2 player, Vector2 enemy)
    {
        Vector2 RelativePlayerPos = enemy - player;

        float angle = Mathf.Atan2(RelativePlayerPos.x, RelativePlayerPos.y);

        return angle;

    }
} 