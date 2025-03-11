
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float controlSpeed=8f;
    [SerializeField] float xClamp=4f;
    [SerializeField] float zClampForward=4f;
    [SerializeField] float zClampBackwards=0;
    Vector2 movement;
    Rigidbody rb;

    void Awake()//CHANGED FROM START TO AWAKE TO AVOID RACE CONDITIONS
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

        Vector3 currentPos=rb.position;
        Vector3 moveVector=new Vector3(movement.x,0,movement.y);
        Vector3 targetPos=currentPos+moveVector*controlSpeed*Time.fixedDeltaTime;
    
       // Debug.Log(targetPos);
        rb.MovePosition(new Vector3(Mathf.Clamp(targetPos.x,-xClamp,xClamp),0,Mathf.Clamp(targetPos.z,-zClampBackwards,zClampForward)));
    }
}
