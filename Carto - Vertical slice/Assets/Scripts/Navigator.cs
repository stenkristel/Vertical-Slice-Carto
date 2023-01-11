using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Navigator : MonoBehaviour
{
    private Animator animator;
    public GameObject[] Waypoints;
    public int speed;
    public int speedafterfreeze;
    public int currentWaypoint;
    public float WPradius = .5f;


    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(Waypoints[currentWaypoint].transform.position, transform.position) < WPradius)
        {
            currentWaypoint = (int)Mathf.Floor(Random.Range(0,3));
            animator.SetBool("isWalking", true);
            animator.SetBool("isIdle", false);

        }
        transform.position = Vector3.MoveTowards(transform.position, Waypoints[currentWaypoint].transform.position, speed * Time.deltaTime);
        if (currentWaypoint == 2)
        {
            StartCoroutine(Freeze());
            animator.SetBool("isIdle", true);
            animator.SetBool("isWalking", false);
        }
    }


    IEnumerator Freeze()
    {
        speed = 0;
        yield return new WaitForSeconds(1);
        speed = speedafterfreeze;
        

    }
}

