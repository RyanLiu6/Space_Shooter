using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody Player;
    public Boundary stBounds;
    public float speed;
    public float tilt;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		// Get the current position of the player
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

        // Getting the Rigidbody Physics Component
        Player = GetComponent<Rigidbody>();

        // Move the player
        Vector3 Movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        Player.AddForce(speed * Movement);

        // Restricting the player's movement within a boundary
        Player.position = new Vector3
        (
            Mathf.Clamp(Player.position.x, stBounds.xMin, stBounds.xMax),
            0.0f,
            Mathf.Clamp(Player.position.z, stBounds.zMin, stBounds.zMax)
        );

        // Tilting of the player object for more realistic looks
        Player.rotation = Quaternion.Euler(0.0f, 0.0f, Player.velocity.x * -tilt);
    }
}

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}
