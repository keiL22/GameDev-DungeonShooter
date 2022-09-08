using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    //public fileds
    [SerializeField] public float TimeToLive = 5f;
    [SerializeField] public float Damage = 25f;

    //called before the first frame update
    void Start()
    {
        //destroy projectile after TTL expires
        Destroy(gameObject, TimeToLive);
    }

    //called when collision occurs
    void OnCollisionEnter(Collision collision)
    {
        //disable the projectile first
        gameObject.SetActive(false);

        //destroy projectile on collision after small time (to allow for property reading)
        Destroy(gameObject, 1f);
    }
}
