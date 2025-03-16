using UnityEngine;

public class Apple : PickUpCollisionHandler
{
    protected override void PickUp()
    {
        Debug.Log("Power up");
    }
}
