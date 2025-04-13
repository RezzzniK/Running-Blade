using UnityEngine;

public class Coin : PickUpCollisionHandler
{
    // LevelGenerator levelGenerator;
    ScoreMG score_manager_txt;
    // void Start()
    // {
    //     levelGenerator=FindFirstObjectByType<LevelGenerator>();
    //     score_manager_txt=FindFirstObjectByType<ScoreMG>();

    // }
    public void InitScoreMG(ScoreMG score_manager_txt){
        this.score_manager_txt = score_manager_txt;
    }
    // public void InitLevelGen(LevelGenerator levelGenerator){
    //     this.levelGenerator = levelGenerator;
    // }
    protected override void PickUp()
    {
       score_manager_txt.UpdateText(100);
    }
}
