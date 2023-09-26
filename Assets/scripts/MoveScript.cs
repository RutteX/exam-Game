using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MoveScript : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _JumpForce;
    [SerializeField] private Text counter;
    [SerializeField] private Rigidbody player;
    
    private Vector3 _moveDirection;
    private int count = 0;
    private bool isGrounded;

    void Start()
    {
        //player = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Move(_moveDirection); 
    }

    void OnTriggerEnter(Collider coll)
    {
        if(coll.tag == "Money")
        {
            count += 1;
            counter.text = count.ToString();
            Destroy(coll.gameObject);
            if (count == 10 )
            {
                SceneManager.LoadScene("WinnerScene");
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Surface")
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Surface")
        {
            isGrounded = false;
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        _moveDirection = context.ReadValue<Vector3>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (isGrounded)
        {
            player.AddForce(Vector3.up * 5f, ForceMode.Impulse);
        }
    }

    private void Move(Vector3 direction)
    {
        float scaledMoveSpeed = _moveSpeed * Time.deltaTime;

        Vector3 moveDirection = new Vector3(direction.x, direction.y, direction.z);
        player.velocity += moveDirection * scaledMoveSpeed;  
    }
}
