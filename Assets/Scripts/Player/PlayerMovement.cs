using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class PlayerMovement : MonoBehaviour {
    public float defaultSpeed = 6.0f;
    private float speed;

    private Rigidbody2D rigidbody;
    private Vector2 moveVelocity;
    private Camera camera;

	// Use this for initialization
	void Start () {
        speed = defaultSpeed;
        rigidbody = GetComponent<Rigidbody2D>();
        camera = Camera.main;
    }
	
	// Update is called once per frame
	void Update () {
        Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        moveVelocity = moveInput.normalized * speed;
	}

    private void FixedUpdate()
    {
        Vector3 newPosition = rigidbody.position + moveVelocity * Time.fixedDeltaTime;
        rigidbody.MovePosition(newPosition);

        camera.transform.position = newPosition;
    }
}
