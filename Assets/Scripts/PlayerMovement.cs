using UnityEngine;

[RequireComponent(typeof(Animator), typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour {

    [SerializeField]
    private float moveSpeed = 10.0f;
    [SerializeField]
    private float tilt = 4;
    [SerializeField]
    private Boundary boundary = new Boundary();

    private Animator anim;
    private Rigidbody2D rb;

    private Vector2 playerInput = new Vector2();

    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    private void Start() {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    private void FixedUpdate() {
        MovePlayer();
    }

    private void Update() {
        anim.SetFloat("VelocityX", playerInput.x);
        anim.SetFloat("VelocityY", playerInput.y);
    }

    private void MovePlayer() {
        playerInput.x = Input.GetAxis("Horizontal");
        playerInput.y = Input.GetAxis("Vertical");

        rb.velocity = playerInput * moveSpeed;

        rb.position = new Vector2(
            Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
            Mathf.Clamp(rb.position.y, boundary.yMin, boundary.yMax)
        );
    }

}
