using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPatrol : MonoBehaviour
{
    public GameObject target;
    public Transform[] patrolPoints;
    public float speed;
    Transform currentPatrolPoint;
    int currentPatrolIndex;
    public int detectionRange;

    // Use this for initialisation
    void Start()
    {
        currentPatrolIndex = 0;
        currentPatrolPoint = patrolPoints[currentPatrolIndex];
        target = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if ((Vector3.Distance(transform.position, target.transform.position) < detectionRange)) // accesses the distance from the enemy to the player, if they are within a certain distance:
        {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime); //chase the player.
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, currentPatrolPoint.position, speed * Time.deltaTime);//follow the pathway of patrol points
            if (Vector3.Distance(transform.position, currentPatrolPoint.position) < 0.2f) // if within a certain distance from the current goal move onto the next:
            {
                if (currentPatrolIndex + 1 < patrolPoints.Length) // ensures the next point does not exceed the amount of patrol points there actually are
                {
                    currentPatrolIndex++; 
                }
                else
                {
                    currentPatrolIndex = 0;
                }
                currentPatrolPoint = patrolPoints[currentPatrolIndex];
            }
        }

    }


    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag.Equals("lightningSpell"))
        {
            Destroy(col.gameObject);
            Destroy(gameObject);
        }
        else if (col.gameObject.tag.Equals("waterSpell"))
        {
            Destroy(gameObject);
        }
    }
}
