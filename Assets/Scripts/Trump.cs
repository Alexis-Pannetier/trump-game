using UnityEngine;

[RequireComponent(typeof(SpriteRenderer), typeof(Animator), typeof(Rigidbody2D))]
public class Trump : MonoBehaviour
{
    public int MaxSpeed = 3;

    // Autres scripts
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private Rigidbody2D rigidbody2D;

    // variables de mon instance
    private Vector3 speed;

    // statics
    private static readonly int Speed = Animator.StringToHash("Speed");
    private static readonly int Roll = Animator.StringToHash("Roll");
    private static readonly int GoingUp = Animator.StringToHash("GoingUp");

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        var maxDistancePerFrame = MaxSpeed;
        Vector3 move = Vector3.zero;

        if (Input.GetKey(KeyCode.RightArrow))
        {
            animator.SetTrigger("Right");
            animator.SetFloat("Speed", 1);
            move += Vector3.right * maxDistancePerFrame;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            animator.SetTrigger("Left");
            animator.SetFloat("Speed", 1);
            move += Vector3.left * maxDistancePerFrame;
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            animator.SetTrigger("Up");
            animator.SetFloat("Speed", 1);
            move += Vector3.up * maxDistancePerFrame;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            animator.SetTrigger("Down");
            animator.SetFloat("Speed", 1);
            move += Vector3.down * maxDistancePerFrame;
        }

        animator.SetFloat(Speed, move.magnitude * 10f);
        rigidbody2D.velocity = move;
    }
}