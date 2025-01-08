using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatController : MonoBehaviour
{
    public float speed = 4f;
    public float AITick = 1f;

    public Rigidbody2D cRigidbody;
    public SpriteRenderer cRenderer;
    public Seeker cSeeker;
    public Transform player;

    private Path path;
    private int currentPoint;
    public Transform[] waypoints;
    public float detDistance = 10f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("UpdatePath", 0f, AITick); //
    }

    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentPoint = 0;
        }
    }

    void UpdatePath()
    {
        cSeeker.StartPath(cRigidbody.position, player.position, OnPathComplete);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //solucion profe
        Vector3 dirPlayer = player.position - transform.position;
      

        if (dirPlayer.magnitude < 5f)
        {
            if (path != null)
            {
                Vector3 dir = path.vectorPath[currentPoint] - transform.position;

                cRigidbody.velocity = dir.normalized * speed;


                if (dir.magnitude < 0.01 && currentPoint < path.vectorPath.Count)
                {
                    currentPoint = currentPoint + 1;
                }
            }
        }
    }
}

