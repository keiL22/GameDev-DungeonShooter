using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    //private fields
    [SerializeField] private float MaxHealth = 100f;
    [SerializeField] private float CurrentHealth;
    [SerializeField] private UnityEvent OnDeath;

    // Start is called before the first frame update
    void Start()
    {
        //set initial health
        CurrentHealth = MaxHealth;
    }

    //take damage function
    public void TakeDamage(float damage)
    {
        //if entity is already dead
        if (CurrentHealth <= 0f) return;

        //update health to reflect damage
        CurrentHealth -= damage;

        //if the entity just died
        if (CurrentHealth <= 0f)
        {
            //limit health to be zero
            CurrentHealth = 0f;

            //trigger any on death event handlers
            if (OnDeath != null) OnDeath.Invoke();

            //destroy the entity
            Destroy(gameObject);
        }
    }

    //get current health function
    public float GetCurrent()
    {
        return CurrentHealth;
    }

    //get max health function
    public float GetMax()
    {
        return MaxHealth;
    }

    public UnityEvent GetOnDeath()
    {
        return OnDeath;
    }
}
