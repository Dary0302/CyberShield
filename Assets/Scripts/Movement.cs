using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour
{
	public float moveSpeed = 300f;
	private float horizontalInput;
	private float verticalInput;

	public void FixedUpdate()
	{
		horizontalInput = Input.GetAxisRaw("Horizontal");
		verticalInput = Input.GetAxisRaw("Vertical");

		transform.Translate(new Vector3(horizontalInput, verticalInput, 0) * (moveSpeed * Time.deltaTime));
	}

	/*private void OnCollisionEnter2D(Collision2D collision)
	{
		MoveBack();
	}

	private void MoveBack()
	{
		transform.Translate(new Vector3(-horizontalInput, -verticalInput, 0) * 10);
	}*/
}