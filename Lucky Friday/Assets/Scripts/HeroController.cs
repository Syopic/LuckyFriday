using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroController : MonoBehaviour
{
	

	public float speed = 1.0f;
	public float rotationSpeed = 1.0f;
	public float animationSpeed = 90.0f;
	public float stability = 2.0F;

	public GameObject animationGO;

	public Rigidbody2D rb;

	private Vector3 pos;
	private Quaternion rot;
	private float animationAngle = 0;

    // Use this for initialization
    void Start()
    {
		pos = transform.position;
		rot = transform.rotation; 
    }

    // Update is called once per frame
    void Update()
    {
		var move = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        // transform.position += move * speed * Time.deltaTime;

		float moveHorizontal = Input.GetAxis("Horizontal");
 
        Vector2 movement = transform.right * moveHorizontal * speed;

		float moveVertical = Input.GetAxis("Vertical");
 
        Vector2 movement2 = transform.up * moveVertical * speed;
 
        rb.AddForce (movement);
		rb.AddForce (movement2);

		float rotate = Input.GetAxis("Rotate");
		rb.AddTorque(rotationSpeed * rotate, ForceMode2D.Force);


		//animationGO.transform.Rotate(0, 0, animationAngle);
    }

    void FixedUpdate() 
	{ 
		
	}
}
