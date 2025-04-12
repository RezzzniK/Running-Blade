using TMPro;
using UnityEngine;
public class ScoreMG : MonoBehaviour
{
    [SerializeField] TMP_Text score;
    static int score_val=0;
    GameStateMG gameMg;
    void Start () {
        gameMg = FindFirstObjectByType<GameStateMG>();
    }
    public void UpdateText(int add_points){
        if(!gameMg.Game_Over){
            score_val+=add_points;
            if(score_val<0) score_val=0;
            score.text = "Score: "+score_val.ToString();
        }
    }
}
