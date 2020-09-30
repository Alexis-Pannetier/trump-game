using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimateTrump : MonoBehaviour
{

    Animator animator;

    SpriteRenderer mySpriteRenderer;
    int SpeedVertical = 1;
    int SpeedHorizontal = 1;

    private void Start()
    {
        animator = GetComponent<Animator>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
    }


    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            animator.SetTrigger("Right");
            animator.SetFloat("Speed", 2f);
            this.transform.position += Vector3.right * SpeedHorizontal * Time.deltaTime;

        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            animator.SetTrigger("Left");
            animator.SetFloat("Speed", 2f);
            this.transform.position += Vector3.left * SpeedHorizontal * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            animator.SetTrigger("Up");
            animator.SetFloat("Speed", 2f);
            this.transform.position += Vector3.up * SpeedVertical * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            animator.SetTrigger("Down");
            animator.SetFloat("Speed", 2f);
            this.transform.position += Vector3.down * SpeedVertical * Time.deltaTime;
        }
        else
        {
            animator.SetFloat("Speed", 0f);
        }
    }
}