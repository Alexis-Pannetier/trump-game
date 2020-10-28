using UnityEngine;
using System;

[RequireComponent(typeof(Animator))]
public class Ball : MonoBehaviour
{
    public float Speed = 2;
    public GameObject effect;

    private BoxCollider2D bc;

    private DateTime _nextChangeTime = DateTime.Now;
    private Vector3 _orientation = Vector3.right;

    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            var instance = Instantiate(effect, (Vector3)other.contacts[0].point, Quaternion.identity);
        }
    }
}
