using UnityEngine;

public class PlayerThirdPersonScript : MonoBehaviour
{
    public PlayerUIScript quest;
    public int FPS = 60;
    public CharacterController controller;
    public Transform Cam;
    public float speed = 10f;
    public float gravity = 20f;
    public float turnSmoothTime = 0.1f;
    public bool inBattle = false;
    public float jumpHeight = 4f;
    public float airDashStrength = 2f;
    public float dashDuration = 0.3f;


    // private
    float turnSmoothVelocity;
    private Vector3 velocity;
    private bool isDashing = false;
    private float dashTimer = 0f;
    private Vector3 dashDirection;
    private bool hasDashed = false;


    void Start()
    {
        Application.targetFrameRate = FPS;
    }

    void Update()
    {
        if(!inBattle){ PlayerMovement(); }
    }

    void OnTriggerEnter(Collider other)
    {   
        if(other.gameObject.CompareTag("Enemy")){
            Debug.Log("Player has collided with enemy! Starting battle...");
            // Handle player collision with enemy here
            inBattle = true;
            FindFirstObjectByType<BattleManager>().StartBattle(other.GetComponentInParent<EnemyData>());
        }
    }

    void PlayerMovement(){

        // Ground reset
        if (controller.isGrounded)
        {
            if (velocity.y < 0)
                velocity.y = -2f;

            hasDashed = false;
            isDashing = false;
        }

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if(direction.magnitude >= 0.1f){
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + Cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            moveDirection.y -= gravity * Time.deltaTime;
            controller.Move(moveDirection.normalized * speed * Time.deltaTime);
        }

        // Jump 
        if (controller.isGrounded && Input.GetButtonDown("Jump"))
        {
            velocity.y = Mathf.Sqrt(jumpHeight * 2f * gravity);
        }

        // Start air dash
        if (!controller.isGrounded && Input.GetButtonDown("Jump") && !hasDashed && !isDashing)
        {
            isDashing = true;
            hasDashed = true;
            dashTimer = dashDuration;
            dashDirection = transform.forward;
        }

        // Process dash direction
        if (isDashing)
        {
            controller.Move(dashDirection * (airDashStrength / dashDuration) * Time.deltaTime);
            dashTimer -= Time.deltaTime;
            if (dashTimer <= 0f)
            {
                isDashing = false;
            }
        }

        // Apply gravity if not dashing
        if (!isDashing)
        {
            velocity.y -= gravity * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);
        }
        }
}
