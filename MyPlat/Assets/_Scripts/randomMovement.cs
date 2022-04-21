using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomMovement : MonoBehaviour
{ 
    private Animator animazione;
    public float movementSpeed;
    public float TimeBetweenMove;
    public float TimeToMove;
    private Rigidbody2D slimeRigidBody;
    private bool isMoving;
    private Vector3 direction;
    private float counter1, counter2;
    private GameObject MainCharacter;


    void Start()
    {
        slimeRigidBody = GetComponent<Rigidbody2D>();
        counter1 = TimeBetweenMove;
        counter2 = TimeToMove;
    }

    void Update()
    {
        if (isMoving)

        {

            counter2 -= Time.deltaTime;
            slimeRigidBody.velocity = direction;
            if (counter2 < 0f)
            {
                isMoving = false;
                counter1 = TimeBetweenMove;
            }
        }

        else
        {
            TimeBetweenMove -= Time.deltaTime;
            slimeRigidBody.velocity = Vector2.zero;
            if (TimeBetweenMove < 0f)
            {
                isMoving = true;
                counter2 = TimeToMove;
                direction = new Vector3(Random.Range(-0.5f, 0.5f) * movementSpeed, Random.Range(-0.5f, 0.5f) * movementSpeed, 0f);
                TimeBetweenMove = counter1;
            }
        }
    }
}
