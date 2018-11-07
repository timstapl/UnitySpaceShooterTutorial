using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
	public float xMin, xMax, zMin, zMax;
}

public class ShipController : MonoBehaviour
{
    public float speed;
	public float tilt;
	public Boundary boundary;
	public float fireRate;
	public GameObject shot;
	public Transform shotSpawn;
    private Rigidbody rb;
	private float nextFire;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
		nextFire = Time.time;
    }
	// update is called before frame redrawn, every frame
	void Update()
	{
		if ( Time.time > nextFire && (Input.GetMouseButton(0) || Input.GetButton("Fire1")))
		{
			nextFire = Time.time + fireRate;
			Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
		}
	}
    // called by unity once before each physics step
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

		// movement
        rb.velocity = new Vector3(moveHorizontal * speed, 0.0f, moveVertical * speed);
		// rotation
		rb.rotation = Quaternion.Euler(0.0f, 0.0f, rb.velocity.x * -tilt);

		// constrain player to bounds
		rb.position = new Vector3 (
			Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
			0.0f,
			Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax)
		);
    }
}
