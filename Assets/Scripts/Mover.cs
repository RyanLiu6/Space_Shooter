using System.Collections;
using UnityEngine;

public class Mover : MonoBehaviour
{
    private Rigidbody Bolt;
    public float speed;

    private void Start()
    {
        Bolt = GetComponent<Rigidbody>();
        Bolt.velocity = transform.forward * speed;
    }
}
