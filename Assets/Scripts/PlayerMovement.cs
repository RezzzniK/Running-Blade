
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float controlSpeed=8f;
    [SerializeField] float xClamp=4f;
    Vector2 movement;
    Rigidbody rb;

    void Start()
    {
        rb=GetComponent<Rigidbody>();//getting rigid body to manipulate it
    }
     void FixedUpdate()
    { 
        PlayerPos();
    }
    //Public Event for Moving
    public void Move(InputAction.CallbackContext context){
        movement=context.ReadValue<Vector2>();//same as in send messages plus Readvalue
    }
    //USING EVENTS INSTEAD MESSAGES:
    void PlayerPos(){
        float xOffset=transform.position.x+movement.x*controlSpeed*Time.deltaTime;
        rb.MovePosition(new Vector3(Mathf.Clamp(xOffset,-xClamp,xClamp),0,0)); 
    }
}
