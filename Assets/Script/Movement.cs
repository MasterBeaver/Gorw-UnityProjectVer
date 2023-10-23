using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;


public class Movement : MonoBehaviour
{
	private float MoveInputX;
	public Rigidbody2D RB;
	public float jumpPower;
	public float moveSpeed;
	//public Transform playerPos;
	public Camera cam;
	public Evolution evo;

	void Start()
	{
		RB = GetComponent<Rigidbody2D>();
		//transform = GetComponent<Transform>();
	}

	void Update()
	{
        cam.gameObject.GetComponent<GameCamera>().UpdateCam(gameObject.transform.position.x, gameObject.transform.position.y);
        if (TimeController.stopMovement == false)
		{
            MoveInputX = Input.GetAxisRaw("Horizontal");
            RB.velocity = new Vector2(MoveInputX * moveSpeed, RB.velocity.y);
        }
			
		//transform.rotation = 180f;
		if (Input.GetKeyDown("w") && IsGrounded() && TimeController.stopMovement==false)
		{
			RB.velocity = new Vector2(RB.velocity.x, jumpPower);
		}

		//playerPos.position = gameObject.transform.position;
        Debug.DrawRay(transform.position, -Vector2.up * Evolution.groundDist, Color.green, 10.0f);
		
    }

	bool IsGrounded()
	{
		RaycastHit2D checkGround = Physics2D.Raycast(transform.position, -Vector2.up, Evolution.groundDist);
		//print(checkGround.collider.gameObject.name);	
		if(checkGround.collider != null) { return true; }
		return false;
    }
}