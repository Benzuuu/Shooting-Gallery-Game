
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowards : MonoBehaviour
{

    public Transform waypoint1, waypoint2;
    private Transform waypointTarget;

    public float movespeed;

    // Start is called before the first frame update
    void Start()
    {
        waypointTarget = waypoint1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, waypoint1.position) < 1.5f)
        {
            waypointTarget = waypoint2;
            Vector3 temp = transform.localScale;
            temp.x *= -1;
            transform.localScale = temp;

        }
        if(Vector3.Distance(transform.position,waypoint2.position)<1.5f)
        {
            waypointTarget = waypoint1;
            Vector3 temp = transform.localScale;
            temp.x *= -1;
            transform.localScale = temp;
        }
        transform.position = Vector3.MoveTowards(transform.position, waypointTarget.position, movespeed * Time.deltaTime);
    }
}
