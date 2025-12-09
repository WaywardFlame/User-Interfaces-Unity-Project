using UnityEngine;
using UnityEngine.TextCore.Text;

public class PlayerScript : MonoBehaviour
{
    public int FPS = 60;
    public float speed = 10f;
    public float jumpSpeed = 8f;
    public float gravity = 20f;
    
    private Vector3 moveDirection = Vector3.zero;
    private float yRotation;
    private float xRotation;
    private float lookSensitivity = 2; // FIXME: May be changed to public later for user adjustment
    private float currentXRotation;
    private float currentYRotation;
    private float yRotationV;
    private float xRotationV;
    private float lookSmooth = 0.1f;
    private CharacterController controller;

    void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    void Start()
    {
        Application.targetFrameRate = FPS;
        // Cursor.LockState = CursorLockedMode.Locked;
        // Cursor.visible = false;
    } 

    void Update()
    {
        FPLookAndMove();
    } 

    void FPLookAndMove(){
        if(controller.isGrounded){
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection = Vector3.Normalize(moveDirection);
            moveDirection *= speed;
            if(Input.GetButton("Jump")){
                moveDirection.y = jumpSpeed;
            }
        }

        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);

        yRotation += Input.GetAxis("Mouse X") * lookSensitivity;
        xRotation -= Input.GetAxis("Mouse Y") * lookSensitivity;
        xRotation = Mathf.Clamp(xRotation, -80, 100);
        currentXRotation = Mathf.SmoothDamp(currentXRotation, xRotation, ref xRotationV, lookSmooth);
        currentYRotation = Mathf.SmoothDamp(currentYRotation, yRotation, ref yRotationV, lookSmooth);
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Enemy")){
            Debug.Log("Player has collided with enemy! Starting battle...");
            // Handle player collision with enemy here
            // FindFirstObjectByType<BattleManager>().StartBattle();
        }
    }
}
