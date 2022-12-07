using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Navigator : MonoBehaviour
{
    public GameObject[] Waypoints;
    public int speed;
    public int speedafterfreeze;
    public int currentWaypoint;
    public float WPradius = .5f;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(Waypoints[currentWaypoint].transform.position, transform.position) < WPradius)
        {
            currentWaypoint = (int)Mathf.Floor(Random.Range(0,3));

        }
        transform.position = Vector3.MoveTowards(transform.position, Waypoints[currentWaypoint].transform.position, speed * Time.deltaTime);
        if (currentWaypoint == 2)
        {
            StartCoroutine(Freeze());
        }
    }


    IEnumerator Freeze()
    {
        speed = 0;
        yield return new WaitForSeconds(1);
        speed = speedafterfreeze;
        

    }
}

