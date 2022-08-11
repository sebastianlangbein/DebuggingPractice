using UnityEngine;
// 10 errors
[RequireComponent(typeof(CharacterController))]
public class CharCon : MonoBehaviour
{
    public float speed;
    public Vector3 movement;
    public float mouseSpeed;
    public float gravity = 9.8f;
    public float jumpHeight = 6f;
    public CharacterController charCon;
    void Start()
    {
        charCon = GetComponent<CharacterController>();
    }

    void Update()
    {
        //movement.x = 0;
        //movement.y = 0;
        transform.Rotate(Vector3.up * Input.GetAxisRaw("Mouse X") * mouseSpeed);

        //movement = transform.forward * Input.GetAxisRaw("Vertical") * speed;
        //movement = transform.right * Input.GetAxisRaw("Horizontal") * speed;

        if (charCon.isGrounded)
        {
            movement = transform.TransformDirection(new Vector3(Input.GetAxisRaw("Vertical"), 0, -Input.GetAxisRaw("Horizontal")) * speed);
            //movement.y = -1;
            if (Input.GetButtonDown("Jump"))
            {
                movement.y = jumpHeight;
            }
        }
        movement.y -= gravity * Time.deltaTime;
        charCon.Move(movement * Time.deltaTime);
    }
}
