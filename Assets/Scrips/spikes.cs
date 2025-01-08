using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class spikes : MonoBehaviour
{
    public float DamageForce = 5f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

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