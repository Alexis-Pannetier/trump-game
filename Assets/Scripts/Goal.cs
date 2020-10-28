using System;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public GameObject effect;

    private Rigidbody2D rigidbody2D;

    private DateTime _nextChangeTime = DateTime.Now;
    private int points = 0;

    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Ball"))
        {
            var instance = Instantiate(effect, this.transform.position, Quaternion.identity);
            Game.instance.RecordGoal(transform.position.x < 0 ? Side.Orange : Side.Blue);
        }
    }
}