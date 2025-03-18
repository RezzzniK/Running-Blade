using UnityEngine;

public class Apple : PickUpCollisionHandler
{
    LevelGenerator levelGenerator;
    void Start()
    {
        levelGenerator=FindFirstObjectByType<LevelGenerator>();

    }
    protected override void PickUp()
    {
        levelGenerator.ChangeLevelSpeed(1f);
    }
}
