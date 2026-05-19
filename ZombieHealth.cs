using UnityEngine;

public class ZombieHealth : MonoBehaviour
{
    public int maxHealth = 3;
    int currentHealth;

    public ZombieSpawner spawner; // ✅ FIX DI SINI

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        Debug.Log("Zombie kena hit! Sisa HP: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Zombie Mati!");

        if (spawner != null)
        {
            spawner.ZombieDied(); // ✅ sekarang nyambung ke ZombieSpawner
        }

        Destroy(gameObject);
    }
}