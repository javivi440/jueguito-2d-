using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Variables en inspector
    public float speed = 5f;
    public float jumpForce = 3f;
    public float ceilDistance = 1f;

    public Animator cAnimator;
    public Rigidbody2D cRigidbody; // rigidbody
    public SpriteRenderer cRenderer;
    public CapsuleCollider2D cCollider;
    public AudioBehaviour cAudio;

    // Variable no inspector
    private Vector2 move;
    private bool grounded;
    private bool crouched;

    private bool jumpKey;
    private bool crouchKey;
    private bool thegref;
    private bool saltaloquete;
    // Start is called before the first frame update
    void Start()
    {
        //cCollider = GetComponent<CapsuleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        move.x = Input.GetAxisRaw("Horizontal");
        move.y = Input.GetAxisRaw("Vertical");

        jumpKey = Input.GetKeyDown(KeyCode.Space);
        crouchKey = Input.GetKey(KeyCode.S);

        // I´m jumping
        if (jumpKey && grounded)
        {
            cRigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse); // Vector2.up == new Vector2(0,1)

            cAnimator.SetBool("Jump", true);
            if (!grounded && thegref && saltaloquete)
            {
                saltaloquete = false; // no puedes saltar mas loquetes
                thegref= false;
            }
            Debug.Log("Jump");
        }

        cAnimator.SetFloat("Speed", Mathf.Abs(cRigidbody.velocity.x));

        PlayerOrientation();
    }

    void FixedUpdate()
    {
        PlayerGrounded();
        PlayerCrouched();

        // Accedo al componente rigidbody 2d
        cRigidbody.velocity = new Vector2(move.x * speed, cRigidbody.velocity.y);
    }

    void PlayerOrientation()
    {
        // Accedo al componente Sprite Renderer
        if (move.x < 0)
            cRenderer.flipX = true;
        else if (move.x > 0)
            cRenderer.flipX = false;
    }

    // Ground detection
    void PlayerGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.05f, LayerMask.GetMask("Environment"));

        if (hit && !grounded) // Check if we have a hit, if not, hit is null and will not enter
        {
            grounded = true;
            cAnimator.SetBool("Jump", false);
            saltaloquete = true; // Reinicia el doble salto al tocar el suelo
        }
        else if (!hit)
        {
            grounded = false;
        }
    }


    // Ceiling and crouch detection
    void PlayerCrouched()
    {
        bool hit = Physics2D.Raycast(transform.position + Vector3.up * 0.1f, Vector2.up, ceilDistance, LayerMask.GetMask("Environment"));
        bool isCrouched = hit || crouchKey;

        if (isCrouched)
        {
            cCollider.size = new Vector2(cCollider.size.x, 0.17f);
            cCollider.offset = new Vector2(0, 0.09f);
        }
        else
        {
            cCollider.size = new Vector2(cCollider.size.x, 0.26f);
            cCollider.offset = new Vector2(0, 0.13f);
        }

        Debug.Log(hit);
        cAnimator.SetBool("Crouch", isCrouched);
    }
    //si consigo la esmeralda
     void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Gem"))
        {
            thegref = true; // salta loquete
            Destroy(collision.gameObject); //elimina la esmeralda
        }

    }
}
