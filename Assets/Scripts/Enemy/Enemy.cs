using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Enemy : MonoBehaviour
{
    public int armor = 30;
    public float maxHealth = 200f;
    public AudioClip death;
    public AudioClip hit;
    private AudioSource audioSource;

    private float curHealth;

    private float speed = .5f;
    private float dashSpeed = 5f;

    public float attackTimer;
    public float dashTimer;
    public float dashLength;


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

        Vector2 playerpos = player.transform.position;
        Vector2 pos = transform.position;
        else if (dashTimer > 0)
        {

        }
        else if (attackTimer > 0)
        {
            transform.position = Vector2.MoveTowards(pos, playerpos, (dashSpeed * -1) * Time.deltaTime);
        }
        else
        {
            transform.position = Vector2.MoveTowards(pos, playerpos, speed * Time.deltaTime);
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
            audioSource.PlayOneShot(hit, 1f);
        }
        else
        {
            print("died");
            audioSource.PlayOneShot(death, 1f);
            Destroy(gameObject);
        }
    }
}