using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Game : MonoBehaviour
{
    public GameObject ball;
    Animator animator;

    void Start()
    {
        var animator = GetComponent<Animator>();
        var instance = Instantiate(ball);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var instance = Instantiate(ball);
        }
    }
}
