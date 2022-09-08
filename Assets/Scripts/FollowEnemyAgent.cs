using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowEnemyAgent : MonoBehaviour
{
    //public fields
    [SerializeField] public Transform Target;

    //private fields
    private NavMeshAgent _Agent;
    private Health _Health;

    //called before the first frame update
    void Start()
    {
        //get navemeshagent
        _Agent = GetComponent<NavMeshAgent>();

        //get Health component
        _Health = GetComponent<Health>();
    }

    //called on a fixed interval
    void FixedUpdate()
    {
        //if the target exists
        if (Target != null)
        {
            //update the agent's destination
            _Agent.destination = Target.position;
        }
    }

    //called when collision occurs
    void OnCollisionEnter(Collision collision)
    {
        //if the collided object is a projectile
        if (collision.gameObject.tag == "projectile")
        {
            //if the health component exists
            if (_Health != null)
            {
                //take damage from projectile
                _Health.TakeDamage(collision.gameObject.GetComponent<Projectile>().Damage);
            }
        }
    }

    //called to set the destination target transform
    public void SetTarget(Transform target)
    {
        //if provided target is not null
        if(target != null)
        {
            //update target to new target
            Target = target;
        }
    }
}
