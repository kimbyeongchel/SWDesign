using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Living : MonoBehaviour
{
    public float startingHealth = 100f;
    public float health { get; protected set; }
    public bool dead { get; protected set; }
    public event Action onDeath;

    public virtual void OnEnable()
    {
        dead = false;
        health = startingHealth;
    }

    public virtual void TakeDamage(float damage)
    {
        health -= damage;

        if (health <= 0 && !dead)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        if(onDeath != null)
        {
            onDeath();
        }

        dead = true;
    }
}