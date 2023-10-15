using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStarts : MonoBehaviour
{
    private GameManager GM;

    [Header("Player Information")]
    [SerializeField] private float maxHealth;
    [SerializeField] private GameObject deathChunkParticle;
    [SerializeField] private GameObject deathBloodParticle;

    private float currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public void DecreaseHealth(float amount)
    {
        currentHealth -= amount;
        if(currentHealth <= 0.0f) 
        {
            Die();
        }
    }

    private void Die()
    {
        Instantiate(deathChunkParticle,transform.position,deathChunkParticle.transform.rotation);
        Instantiate(deathBloodParticle, transform.position, deathBloodParticle.transform.rotation);
        GM.Respawn();
        Destroy(gameObject);
    }
}
