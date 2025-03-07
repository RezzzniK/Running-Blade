using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] float controlSpeed=8f;
    Vector2 movement;

    // Update is called once per frame
    void Update()
    {
        
        PlayerPos();
    }

    public void OnMove(InputValue value){
        movement=value.Get<Vector2>();
    }

    void PlayerPos(){
        float xOffset=movement.x*controlSpeed*Time.deltaTime;
         transform.Translate(Vector3.left*(-xOffset));
    }
}
