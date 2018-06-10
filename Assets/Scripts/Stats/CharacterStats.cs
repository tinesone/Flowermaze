using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public int maxHealt = 100;
    public int currentHealth { get; private set; }

    public Stat damage;
    public Stat armor;

    void Awake()
    {
        currentHealth = maxHealt;
    }

    public void TakeDamage(int damage)
    {
        damage -= armor.GetValue();
        damage = Mathf.Abs(damage);

        currentHealth -= damage;
        Debug.Log(transform.name + " takes " + damage + " damage");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        Debug.Log(transform.name + " died");
    }
}
