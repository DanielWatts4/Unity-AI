using UnityEngine;
using System.Collections;
using Pathfinding; // Unity library to assist in creating a pathfinder
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Seeker))]
public class PathfindingAI : MonoBehaviour
{

    public Transform target;
    public int detectionRange;
    public float detectionSpeed;
    public float updateRate = 5f;
    // Caching
    private Seeker seeker;
    private Rigidbody2D rb2D;
    //The calculated path
    public Path path;
    public float speed = 300f;
    
    public ForceMode2D fMode;

    [HideInInspector]
    public bool pathFished = false;

    // The max distance from the AI to a waypoint for it to continue to the next waypoint
    public float waypointDist = 3;

    // The waypoint we are currently moving towards
    private int currentWaypoint = 0;


    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb2D = GetComponent<Rigidbody2D>();

        // Start a new path to the target position, return the result to the OnPathComplete method
        seeker.StartPath(transform.position, target.position, wayPointReached);

        StartCoroutine(UpdatePath());
    }

    IEnumerator UpdatePath()
    {
        seeker.StartPath(transform.position, target.position, wayPointReached);

        yield return new WaitForSeconds(1f / updateRate);

        StartCoroutine(UpdatePath());
    }

    public void wayPointReached(Path p)
    {
        Debug.Log("Potential error." + p.error);
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }

    void FixedUpdate()
    {
        if ((Vector3.Distance(transform.position, target.transform.position) < detectionRange)) // accesses the distance from the enemy to the player, if they are within a certain distance:
        {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, detectionSpeed * Time.fixedDeltaTime); //chase the player.
        }
        else { 
        if (path == null)
            return;

        if (currentWaypoint >= path.vectorPath.Count)
        {
            if (pathFished)
                return;

            Debug.Log("Path reached.");
            pathFished = true;
            return;
        }
        pathFished = false;

        //Direction to the next waypoint
        Vector3 dir = (path.vectorPath[currentWaypoint] - transform.position).normalized;
        dir *= (speed * Time.fixedDeltaTime);

        //Move the AI
        rb2D.AddForce(dir, fMode);

        float dist = Vector3.Distance(transform.position, path.vectorPath[currentWaypoint]);
        if (dist < waypointDist)
        {
            currentWaypoint++;
            return;
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
