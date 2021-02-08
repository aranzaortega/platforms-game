/* ARANZA I. ORTEGA S. DAM "O" NARANJA*/

using UnityEngine;

public class Player : MonoBehaviour
{
    // Movement
    private float speed;
    private float jumpSpeed;
    private float jump;
    private float horizontal;

    // Position
    private float initX, initY;
    private float floorDistance;
    private float playerHeight;

    // Animation
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        speed = 2;
        jumpSpeed = 45;

        initX = transform.position.x;
        initY = transform.position.y;
        playerHeight = GetComponent<Collider2D>().bounds.size.y;

        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Player's horizontal movement (run)
        horizontal = Input.GetAxis("Horizontal");
        transform.Translate(horizontal * speed * Time.deltaTime, 0, 0);

        // Running animation
        if (horizontal > 0.1f)
        {
            anim.Play("RunningPlayer");
        }
        else if (horizontal < -0.1f)
        {
            anim.Play("RunningBackwardsPlayer");
        }

        // Player's vertical movement (jump)
        jump = Input.GetAxis("Jump");
        if (jump > 0)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(0, -1));

            if (hit.collider != null)
            {
                floorDistance = hit.distance;
                bool touchingFloor = floorDistance < playerHeight;
                if (touchingFloor)
                {
                    Vector3 jumpForce = new Vector3(0, jumpSpeed, 0);
                    GetComponent<Rigidbody2D>().AddForce(jumpForce);
                }
            }
        }

        // Jumping animation
        if (jump > 0.1f)
        {
            anim.Play("JumpingPlayer");
        }
    }

    // Place the player in its starting position 
    public void Reposition()
    {
        transform.position = new Vector3(initX, initY, 0);
    }
}
