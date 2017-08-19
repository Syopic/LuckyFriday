using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroController : MonoBehaviour
{
	private Vector3 pos;
	private Quaternion rot;

	public float speed = 1.0f;
	public float stabilitySpeed = 1.0f;
	public float stability = 2.0F;

	public Rigidbody rb;

    // Use this for initialization
    void Start()
    {
		pos = transform.position;
		rot = transform.rotation; 
    }

    // Update is called once per frame
    void Update()
    {
		var move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        // transform.position += move * speed * Time.deltaTime;

		float moveHorizontal = Input.GetAxis("Horizontal");
 
        Vector3 movement = transform.forward * moveHorizontal * speed;

		float moveVertical = Input.GetAxis("Vertical");
 
        Vector3 movement2 = transform.up * moveVertical * speed;
 
        rb.AddForce (movement);
		rb.AddForce (movement2);

		Vector3  target = new Vector3(0, 90, 0);

		Vector3 predictedUp = Quaternion.AngleAxis(
         rb.angularVelocity.magnitude * Mathf.Rad2Deg * stability / stabilitySpeed,
         rb.angularVelocity
     ) * transform.up;
        Vector3 torqueVector = Vector3.Cross(predictedUp, Vector3.up);
        rb.AddTorque(torqueVector * stabilitySpeed * stabilitySpeed);


		// Vector3  target = new Vector3(0, 90, 0);
		// target = target.normalized * speed;
		// Quaternion deltaRotation = Quaternion.Euler(target);
		// rb.MoveRotation(rb.rotation * deltaRotation);

		//Quaternion target = Quaternion.Euler(0, 90, 0);
		//transform.rotation = Quaternion.Lerp(transform.rotation, target, Time.time * speed);
		//rb.MoveRotation(rb.rotation target +  speed * Time.fixedDeltaTime);
		//rb.AddTorque(0,90,0);
		/*Quaternion rot = transform.rotation;
		rot.z = rot.z - rot.z/100; 
		Quaternion originalRot = transform.rotation;
		transform.rotation = originalRot * Quaternion.Euler(rot.x, 90f, rot.z);

		transform.rotation = originalRot * Quaternion.AngleAxis(degrees, Vector3.Up);
*/
		// Vector3 wantedForward = transform.forward;
		// wantedForward.y = 0;
		// transform.rotation = Quaternion.LookRotation(wantedForward.normalized, Vector3.up);

		//Quaternion target = Quaternion.Euler(0, 90, 0);
     	//transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);

		//  Vector3 predictedUp = Quaternion.AngleAxis(
        //  rb.angularVelocity.magnitude * Mathf.Rad2Deg * stability / speed,
        //  rb.angularVelocity
		// ) * transform.forward;
		// Vector3 torqueVector = Vector3.Cross(predictedUp, transform.forward);
		// //Vector3 torqueVector = new Vector3(0, 90, 0);
		// rb.AddTorque(torqueVector * speed * speed);

		//  float rotx =  transform.eulerAngles.x - transform.eulerAngles.x;
		// float rotz = transform.eulerAngles.z - transform.eulerAngles.z;
		// transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(rotx, 90, rotz), 0.1f);

		
    }

    void FixedUpdate() 
	{ 
		var currentPos = transform.position;
		var currentRot = transform.rotation;
		transform.position = new Vector3(currentPos.x, currentPos.y, pos.z);
		//transform.rotation = Quaternion.Euler(currentRot.x, 90, rot.z);
	}
}
