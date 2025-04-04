using TMPro;
using UnityEngine;
public class ScoreMG : MonoBehaviour
{
    [SerializeField] TMP_Text score;
    static int score_val=0;
    

    public void UpdateText(int add_points){
        score_val+=add_points;
        if(score_val<0) score_val=0;
        score.text = "Score: "+score_val.ToString();
    }
}
