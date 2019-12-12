using UnityEngine;
using UnityEngine.AI;

public class WaypointMover : MonoBehaviour
{
    [SerializeField] private Transform[] waypoints = new Transform[0];

    private NavMeshAgent navMeshAgent;
    private Animator animator;
    private new Animation animation;
    private int waypoint = 0;
    private bool moving = false;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        animation = GetComponent<Animation>();
        Invoke("startMove", Random.Range(0.05f, 0.1f));
    }

    void Update()
    {
        if (moving)
        {
            navMeshAgent.SetDestination(waypoints[waypoint].position);
            if (Vector3.Distance(transform.position, waypoints[waypoint].position) <= 3)
            {
                if (waypoint < waypoints.Length - 1)
                {
                    ++waypoint;
                } else
                {
                    moving = false;
                }
            }
            if (animator) animator.SetBool("Walking", true);
            if (animation && !animation.isPlaying) animation.Play();
        } else
        {
            if (animator) animator.SetBool("Walking", false);
            if (animation && animation.isPlaying) animation.Stop();
        }
    }

    void startMove()
    {
        moving = true;
    }
}
