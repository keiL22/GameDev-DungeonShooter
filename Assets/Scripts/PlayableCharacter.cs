using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayableCharacter : MonoBehaviour
{
    //serialized fields
    [SerializeField] private float MovementSpeed = 10f;
    [SerializeField] private bool RotateWithMouse = true;
    [SerializeField] private GameObject ProjectilePrefab;
    [SerializeField] private float ProjectileSpeed = 50f;
    [SerializeField] private float ProjectileOffest = 5f;
    [SerializeField] private float DamageOnCollision = 25f;
    [SerializeField] private float TimeBetweenCollisions = 2f;

    //private fields
    private Vector3 _MoveVector;
    private Rigidbody _Rigidbody;
    private Health _Health;
    private float _LastCollision = 0f;

    //called before the first frame update
    void Start()
    {
        //get the player's rigidbody
        _Rigidbody = GetComponent<Rigidbody>();

        //get the player's health
        _Health = GetComponent<Health>();
    }

    //called once per frame
    void Update()
    {
        //move player based on input vector
        MovePlayer();

        //rotate player
        RotatePlayer();

        //if the "Fire1" button is pressed
        if (Input.GetButtonDown("Fire1"))
        {
            //calculate bullet spawn position
            Vector3 position = transform.position + (transform.forward * ProjectileOffest);

            //calculate bullet rotation
            Quaternion rotation = transform.rotation * ProjectilePrefab.transform.rotation;

            //instantiate bullet game object
            GameObject bullet = Instantiate(ProjectilePrefab, position, rotation);

            //set bullet's velocity in the "forward" direction
            bullet.GetComponent<Rigidbody>().velocity = transform.forward * ProjectileSpeed;
        }
    }

    //player movement function
    private void MovePlayer()
    {
        //calculate movement direction from input
        Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), _Rigidbody.velocity.y, Input.GetAxis("Vertical"));

        //calculate scaled movement speed
        var speed = MovementSpeed * Time.deltaTime;

        //update movement vector
        _MoveVector = direction.normalized * speed;

        //move player
        _Rigidbody.MovePosition(transform.position + _MoveVector);
    }

    //player rotation function
    private void RotatePlayer()
    {
        //OPTION 1: rotate based on mouse position
        if(RotateWithMouse)
        {
            //convert mouse position to in world Vector3
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hitInfo, maxDistance: 300f))
            {
                //update target vector with player's current y position
                Vector3 target = hitInfo.point;
                target.y = transform.position.y;

                //rotate player towards target vector
                transform.LookAt(target);
            }
        }

        //OPTION 2: rotate based on movement vector
        else
        {
            //if movement is occuring
            if(_MoveVector.magnitude > 0)
            {
                //look towards movement
                transform.rotation = Quaternion.LookRotation(_MoveVector);                
            }

        }
    }

    //called when collision is maintained
    void OnCollisionStay(Collision collision)
    {
        //if the collided object is an enemy
        if (collision.gameObject.tag == "enemy")
        {
            //if the health component exists
            if (_Health != null && (Time.time - _LastCollision >= TimeBetweenCollisions))
            {
                //mark collision occurence
                _LastCollision = Time.time;

                //take damage from colliding with an enemy
                _Health.TakeDamage(DamageOnCollision);
            }
        }
    }
}
