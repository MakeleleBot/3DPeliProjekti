using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //private const float NORMAL_FOV = 60f;
    //private const float HS_FOV = 100f;

    private CharacterController cc;
    private float characterVelocityY;
    //public float HsCooldownTime = 10f;
    //public float HsNextFireTime = 0f;
    public float speed = 24f;
    public float sprintMultiplier = 2f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    public float playerHealth = 100f;
    public float reachedHSPosDistance = 1f;
    [SerializeField] private float mouseSen = 1f;
    public float upClamp = -89f;
    public float downClamp = 89f;
    private float cameraVerticalAngle = 0f;
    private Vector3 characterMomentum;
    public bool onWater = false;
    public Vector3 enterPos;
    public Vector3 exitPos;

    public Transform groundcheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public Camera playerCamera;

    Vector3 velocity;
    public bool grounded;

    public void Awake()
    {
        cc = GetComponent<CharacterController>();
        //playerCamera = transform.Find("Camera").GetComponent<Camera>();
        //cameraFov = playerCamera.GetComponent<FovChange>();
        //state = State.Normal;
        //Cursor.lockState = CursorLockMode.Locked;
        //hookshotTransform.gameObject.SetActive(false);

    }

    void Update()
    {

        float lookX = Input.GetAxisRaw("Mouse X");
        float lookY = Input.GetAxisRaw("Mouse Y");

        transform.Rotate(new Vector3(0f, lookX * mouseSen, 0f), Space.Self);

        cameraVerticalAngle -= lookY * mouseSen;
        cameraVerticalAngle = Mathf.Clamp(cameraVerticalAngle, -89f, 89f);
        playerCamera.transform.localEulerAngles = new Vector3(cameraVerticalAngle, 0, 0);

        grounded = Physics.CheckSphere(groundcheck.position, groundDistance, groundMask);

        if (grounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        cc.Move(move * speed * Time.deltaTime);

        if (TestInputJump() && grounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        velocity += characterMomentum;

        cc.Move(velocity * Time.deltaTime);

        if (characterMomentum.magnitude >= 0f)
        {
            float momentumDrag = 3f;
            characterMomentum -= characterMomentum * momentumDrag * Time.deltaTime;
            if (characterMomentum.magnitude < .0f)
            {
                characterMomentum = Vector3.zero;
            }
        }

        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        Vector3 characterVelocity = transform.right * moveX * speed + transform.forward * moveY * speed;

        if (cc.isGrounded)
        {
            characterVelocityY = 0f;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                characterVelocityY = jumpHeight;
            }
        }

        characterVelocityY += gravity * Time.deltaTime;

        characterVelocity.y = characterVelocityY;

        characterVelocity += characterMomentum;

        if (characterMomentum.magnitude >= 0f)
        {
            float momDrag = 3f;
            characterMomentum -= characterMomentum * momDrag * Time.deltaTime;
            if (characterMomentum.magnitude < .0f)
            {
                characterMomentum = Vector3.zero;
            }
        }

    }

    //private void Movement()
    //{
    //    grounded = Physics.CheckSphere(groundcheck.position, groundDistance, groundMask);

    //    if (grounded && velocity.y < 0)
    //    {
    //        velocity.y = -2f;
    //    }

    //    float x = Input.GetAxis("Horizontal");
    //    float z = Input.GetAxis("Vertical");

    //    Vector3 move = transform.right * x + transform.forward * z;

    //    cc.Move(move * speed * Time.deltaTime);

    //    if (TestInputJump() && grounded)
    //    {
    //        velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
    //    }

    //    velocity.y += gravity * Time.deltaTime;

    //    velocity += characterMomentum;

    //    cc.Move(velocity * Time.deltaTime);

    //    if (characterMomentum.magnitude >= 0f)
    //    {
    //        float momentumDrag = 3f;
    //        characterMomentum -= characterMomentum * momentumDrag * Time.deltaTime;
    //        if (characterMomentum.magnitude < .0f)
    //        {
    //            characterMomentum = Vector3.zero;
    //        }
    //    }

    //    float moveX = Input.GetAxisRaw("Horizontal");
    //    float moveY = Input.GetAxisRaw("Vertical");

    //    if (Input.GetKey(KeyCode.LeftShift))
    //    {
    //        speed = speed * sprintMultiplier;
    //    }

    //    Vector3 characterVelocity = transform.right * moveX * speed + transform.forward * moveY * speed;

    //    if (cc.isGrounded)
    //    {
    //        characterVelocityY = 0f;
    //        if (Input.GetKeyDown(KeyCode.Space))
    //        {
    //            characterVelocityY = jumpHeight;
    //        }
    //    }

    //    characterVelocityY += gravity * Time.deltaTime;

    //    characterVelocity.y = characterVelocityY;

    //    characterVelocity += characterMomentum;

    //    if(characterMomentum.magnitude >= 0f)
    //    {
    //        float momDrag = 3f;
    //        characterMomentum -= characterMomentum * momDrag * Time.deltaTime;
    //        if(characterMomentum.magnitude < .0f)
    //        {
    //            characterMomentum = Vector3.zero;
    //        }
    //    }

    //    cc.Move(characterVelocity * Time.deltaTime);
    //}

    //private void MouseLook()
    //{
    //    float lookX = Input.GetAxisRaw("Mouse X");
    //    float lookY = Input.GetAxisRaw("Mouse Y");

    //    transform.Rotate(new Vector3(0f, lookX * mouseSen, 0f), Space.Self);

    //    cameraVerticalAngle -= lookY * mouseSen;
    //    cameraVerticalAngle = Mathf.Clamp(cameraVerticalAngle, -89f, 89f);
    //    playerCamera.transform.localEulerAngles = new Vector3(cameraVerticalAngle, 0, 0);
    //}

    //private void ResetGravity()
    //{
    //    characterVelocityY = 0f;
    //}

    private bool TestInputHS()
    {
        return Input.GetKeyDown(KeyCode.E);
    }

    private bool TestInputJump()
    {
        return Input.GetKeyDown(KeyCode.Space);
    }
}
