using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FollowEnemyAgentSpawner : MonoBehaviour
{
    //serialized fields
    [SerializeField] private GameObject FollowEnemyAgentPrefab;
    [SerializeField] private float TimeBetweenSpawns = 2f;
    [SerializeField] private UnityEvent OnDeathOfSpawns;

    //unserialized fields
    private float _LastSpawn = 0f;

    //called before the first frame update
    void Start()
    {
        //force initial spawn of enemy
        _LastSpawn = Time.time - TimeBetweenSpawns;
    }

    //called at the end of each frame
    void LateUpdate()
    {
        //if prefab exists and time has passed enough to spawn
        if(FollowEnemyAgentPrefab != null && (Time.time - _LastSpawn >= TimeBetweenSpawns))
        {
            //update last spawn time
            _LastSpawn = Time.time;

            //spawn follow enemy agent
            GameObject agent = Instantiate(FollowEnemyAgentPrefab, transform.position, Quaternion.identity);

            //set target to player
            agent.GetComponent<FollowEnemyAgent>().SetTarget(GameObject.FindWithTag("Player").transform);

            //add the on death event listener
            agent.GetComponent<Health>()?.GetOnDeath()?.AddListener(() => OnDeathOfSpawns?.Invoke());
        }
    }
}
