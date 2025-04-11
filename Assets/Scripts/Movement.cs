using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField]
    public float velocity = 3.0f;
    private Rigidbody2D rb;
    private Vector2 input;
    void Start()
    {
        rb = GetComponent<Rigidbody2D> ();
    }

    // Update is called once per frame
    void Update()
    {
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");

        input.Normalize();  // Makes our diagonal movement move the same as other movements
                            // Without normalize - diagonal movement would be faster
    }

    private void FixedUpdate() 
    {
        rb.linearVelocity = input * velocity;
    }
}
