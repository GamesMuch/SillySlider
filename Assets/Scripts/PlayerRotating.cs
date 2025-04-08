//using UnityEngine;

//public class PlayerRotating : MonoBehaviour
//{

//    public int RotationSpeed;
//    public int PowerMultiplier = 10;
//    public PowerBar PowerBar;
//    Rigidbody rb;
//    // Start is called once before the first execution of Update after the MonoBehaviour is created
//    void Start()
//    {
//        rb = gameObject.GetComponent<Rigidbody>();
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        if (IsStandingStill())
//        {
//            if (Input.GetKeyDown(KeyCode.Space))
//            {
//                rb.AddForce(transform.localRotation * transform.right * PowerBar.currentPower * PowerMultiplier);
//            }
//            float horizontalInput = Input.GetAxis("Horizontal"); // Get the horizontal input

//            if (Mathf.Abs(horizontalInput) > 0.01f) // Only rotate if there is significant input
//            {
//                transform.Rotate(Vector3.up, horizontalInput * RotationSpeed * Time.deltaTime);
//            }
//        }

//    }
//    private void FixedUpdate()
//    {
//        Debug.DrawRay(transform.position, transform.forward, Color.red, 2); 
//    }
//    bool IsStandingStill()
//    {
//        if (rb.angularVelocity + rb.linearVelocity == Vector3.zero)
//        {
//            return true;
//        }
//        else
//        {
//            return false;
//        }
//    }
//}

using UnityEngine;

public class PlayerRotating: MonoBehaviour
{
    public int RotationSpeed = 100;
    public int PowerMultiplier = 10;
    public PowerBar PowerBar;

    private Rigidbody rb;
    private bool isMoving = false;

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (IsStandingStill())
        {
            isMoving = false; // Mark puck as not moving

            if (Input.GetKeyDown(KeyCode.Space))
            {
                // Apply force in the direction the puck is facing
                rb.AddForce(transform.right * PowerBar.currentPower * PowerMultiplier, ForceMode.Impulse);
                ScoreManager.instance.AddShot();
                isMoving = true; // Mark puck as moving
            }

            float horizontalInput = Input.GetAxis("Horizontal"); // Get input for rotation

            if (Mathf.Abs(horizontalInput) > 0.01f) // Only rotate if there's actual input
            {
                transform.Rotate(Vector3.up, horizontalInput * RotationSpeed * Time.deltaTime);
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall")) // Make sure walls have the "Wall" tag
        {
            Vector3 normal = collision.contacts[0].normal; // Get the collision normal
            float speed = rb.linearVelocity.magnitude; // Save the speed before the bounce

            // Reflect the velocity while keeping the original speed
            rb.linearVelocity = Vector3.Reflect(rb.linearVelocity, normal).normalized * speed; // Slightly reduce to avoid infinite bounces
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Respawn")
        {
            Respawn();
        }
        if (other.tag == "WindBox")
        {
            Vector3 temp = new Vector3(3, 1, 1);
            rb.linearVelocity = new Vector3 (rb.linearVelocity.x * temp.x, rb.linearVelocity.y * temp.y, rb.linearVelocity.z * temp.z);
        }

    }
    void Respawn()
    {
        transform.position = (startPos);
        rb.linearVelocity = Vector3.zero;
    }

    bool IsStandingStill()
    {
        // Check if both linear and angular velocities are nearly zero
        return rb.linearVelocity.magnitude < 0.05f && rb.angularVelocity.magnitude < 0.05f;
    }
}
