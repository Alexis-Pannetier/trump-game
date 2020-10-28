using UnityEngine;

[RequireComponent(typeof(SpriteRenderer), typeof(Animator), typeof(Rigidbody2D))]
public class Trump : MonoBehaviour
{
    public int MaxSpeed = 3;
    public bool zqsd = false;

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

        if (!zqsd && Input.GetKey(KeyCode.RightArrow) || zqsd && Input.GetKey(KeyCode.D))
        {
            animator.SetTrigger("Right");
            animator.SetFloat("Speed", 1);
            move += Vector3.right * maxDistancePerFrame;
        }
        else if (!zqsd && Input.GetKey(KeyCode.LeftArrow) || zqsd && Input.GetKey(KeyCode.Q))
        {
            animator.SetTrigger("Left");
            animator.SetFloat("Speed", 1);
            move += Vector3.left * maxDistancePerFrame;
        }

        if (!zqsd && Input.GetKey(KeyCode.UpArrow) || zqsd && Input.GetKey(KeyCode.Z))
        {
            animator.SetTrigger("Up");
            animator.SetFloat("Speed", 1);
            move += Vector3.up * maxDistancePerFrame;
        }
        else if (!zqsd && Input.GetKey(KeyCode.DownArrow) || zqsd && Input.GetKey(KeyCode.S))
        {
            animator.SetTrigger("Down");
            animator.SetFloat("Speed", 1);
            move += Vector3.down * maxDistancePerFrame;
        }

        animator.SetFloat(Speed, move.magnitude * 10f);
        rigidbody2D.velocity = move;
    }
}