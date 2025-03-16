using UnityEngine;

public class Coin : PickUpCollisionHandler
{
    protected override void PickUp()
    {
       Debug.Log("Add 100 coins");
    }
}
