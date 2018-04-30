using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Enemy : MonoBehaviour
{
    public int armor = 30;
    public float maxHealth = 200f;
    public AudioClip death;
    public AudioClip hit;
    public GameObject player;

    private float curHealth = 0;
    private bool died = false;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        curHealth = maxHealth;
    }

    public void ApplyDamage(float dmg)
    {
        dmg -= dmg * armor / 100f;
        curHealth -= dmg;
        print(curHealth);
        if (curHealth > 15)
        {
            print(curHealth);
            audioSource.PlayOneShot(hit, 1f);
        }
        else if (curHealth <= 15 && curHealth >= 0 && died == false)
        {
            died = true;
            print("died");
            audioSource.PlayOneShot(death, 1f);
        }
        else if (curHealth <= 0 && died == true)
        {
            Destroy(gameObject);
        }
    }
}
