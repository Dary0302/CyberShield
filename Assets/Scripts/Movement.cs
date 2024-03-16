using UnityEngine;

public class Movement : MonoBehaviour
{
	public float speed = 300f;
	private Vector2 direction;
	private Rigidbody2D rb;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
{
		direction.x = Input.GetAxisRaw("Horizontal");
        direction.y = Input.GetAxisRaw("Vertical");

    }

    private void FixedUpdate()
    {
        direction.Normalize();
        rb.MovePosition(rb.position + direction * speed * Time.deltaTime);
    }

}