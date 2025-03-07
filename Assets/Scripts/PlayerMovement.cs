using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] float controlSpeed=8f;
    [SerializeField] float xClamp=10f;
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
        float xOffset=transform.localPosition.x+movement.x*controlSpeed*Time.deltaTime;
        transform.localPosition=new Vector3(Mathf.Clamp(xOffset,-xClamp,xClamp),0,0);      
    }
}
