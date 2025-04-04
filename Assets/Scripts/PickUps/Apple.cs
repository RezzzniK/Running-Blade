using UnityEngine;

public class Apple : PickUpCollisionHandler
{
    LevelGenerator levelGenerator;
    // void Start()
    // {
    //     levelGenerator=FindFirstObjectByType<LevelGenerator>();

    // }

    public void Init(LevelGenerator levelGenerator){///much more faster then FindFirstObjectByType
        this.levelGenerator = levelGenerator;
    }
    protected override void PickUp()
    {
        levelGenerator.ChangeLevelSpeed(1f);
    }
}
