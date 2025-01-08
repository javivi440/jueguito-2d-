using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// El enemigo se mueva de un waypoint al siguiente
// El enemigo persiga al jugador y le cause daño si esta dentro de un rango

public class EnemyController : MonoBehaviour
{
    public Rigidbody2D cRigidbody;
    public Transform[] waypoints;

    public float speed = 0.5f;
    public float DamageForce = 5f;
    public float detdistance = 3f;


    private int currentPoint = 0;
    private PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 dir = waypoints[currentPoint].position - transform.position;
        dir.y = 0;


        cRigidbody.velocity = new Vector2(dir.normalized.x * speed, cRigidbody.velocity.y);
       

        // Bucle de la patrol
        if (dir.magnitude < 0.1f)
        {
            currentPoint = (currentPoint + 1) % waypoints.Length;
            Debug.Log("He llegado al waypoint");
        }



    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.name);
        PlayerHealthController hCtr = collision.gameObject.GetComponent<PlayerHealthController>();
        hCtr.Damage();
        Rigidbody2D cRigidbody = collision.gameObject.GetComponent<Rigidbody2D>();
        cRigidbody.AddForce(Vector2.up * DamageForce, ForceMode2D.Impulse);
        Debug.Log(collision);

    }
}
