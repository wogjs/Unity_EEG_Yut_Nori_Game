using UnityEngine;

public class FollowThePath : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform[] waypoints;

    [SerializeField]
    public static float moveSpeed = 5f;

    [HideInInspector]
    public int waypointIndex = 0;

    public bool moveAllowed = false;

    // user this for initialization
    private void Start()
    {
        transform.position = waypoints[waypointIndex].transform.position;
    }

    // Update is called once per frame
    private void Update()
    {
        if(moveAllowed)
            Move();
    }

    private void Move()
    {
        if(waypointIndex == 21 || waypointIndex == 34 || waypointIndex == 42){
            waypointIndex = 42;
        }
        if(waypointIndex == 43){
            waypointIndex = 43;
        }
        if(waypointIndex <= waypoints.Length -1) {
            transform.position = Vector2.MoveTowards(transform.position, waypoints[waypointIndex].transform.position, moveSpeed * Time.deltaTime);

            if(transform.position == waypoints[waypointIndex].transform.position)
            {
                waypointIndex += 1;
                //Debug.Log(waypoints[waypointIndex].transform.position);
            }
        }
    }
}
