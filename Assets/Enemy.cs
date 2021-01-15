using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Enemy : MonoBehaviour
{

    public Transform target;

    public float speed = 50f;
    public float nextWaypointDistance = 3f;

    public Transform zombie;
    Path path;
    int currentWaypoint = 0;
    bool reachedEndOfPath = false;

    Seeker seeker;
    Rigidbody2D rb;

    Vector2 movement;
    public Animator animator;
    public GameObject fireballPrefab;
    Vector2 direction;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        InvokeRepeating("UpdatePath", 0f, 0.2f);
        InvokeRepeating("UpdateGraph", 0f, 1.0f);
        InvokeRepeating("Shoot", 0f, 1.0f);
    }
    void Shoot(){
        float distance = Vector2.Distance(rb.position, target.position);
        if (distance <= 6.0f && path != null) {
            speed = 200f;
            //Vector2 direction = ((Vector2) path.vectorPath[currentWaypoint] - rb.position).normalized;
            Vector3 fireballPosition = zombie.position;
            fireballPosition.x = Mathf.Round(fireballPosition.x); 
            fireballPosition.y = Mathf.Round(fireballPosition.y); 
            fireballPosition.z = Mathf.Round(fireballPosition.z);
            Vector3 rotation = new Vector3(0.0f,0.0f,0.0f);
            if (direction.x < 0) {
                if (direction.y < 0){
                    if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
                        rotation.z = 0;
                    else {
                        rotation.z = 90;
                    }
                }
                else {
                    if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
                        rotation.z = 0;
                    else {
                        rotation.z = -90;
                    }
                }
            }
            else{
                if (direction.y < 0){
                    if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
                        rotation.z = 180;
                    else {
                        rotation.z = 90;
                    }
                }
                else {
                    if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
                        rotation.z = 180;
                    else {
                        rotation.z = -90;
                    }
                }
            }
            Instantiate(fireballPrefab,fireballPosition,Quaternion.Euler(rotation.x, rotation.y, rotation.z));
        }
        else {
            speed = 50f;
        }
    }
    void UpdatePath()
    {
        if (seeker.IsDone())
            seeker.StartPath(rb.position, target.position, OnPathComplete);
    }

    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        
        if (path == null)
            return;
        if (currentWaypoint >= path.vectorPath.Count)
        {
            reachedEndOfPath = true;
            return;
        } else 
        {
            reachedEndOfPath = false;
        }
        direction = ((Vector2) path.vectorPath[currentWaypoint] - rb.position);
        Vector2 force = direction * speed * Time.deltaTime;
        rb.AddForce(force);
        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);

        if (distance < nextWaypointDistance)
        {
            currentWaypoint++;
        }

        // Animation of enemy
        movement.x = rb.velocity.x;
        movement.y = rb.velocity.y;

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }
    private void OnTriggerStay2D(Collider2D other) {
        if (other.gameObject.layer == 8){
            Destroy(gameObject);
            FindObjectOfType<TileAutomate>().KillZombie();
        }
    }
    void UpdateGraph(){
        AstarPath.active.Scan();
    }
   

}
