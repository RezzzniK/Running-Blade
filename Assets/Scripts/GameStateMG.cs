using TMPro;
using UnityEngine;
public class GameStateMG : MonoBehaviour
{
    [SerializeField] TMP_Text timer_txt;    
    [SerializeField] float initial_timer=60f;
    [SerializeField] GameObject game_over_txt; 
    [SerializeField] PlayerMovement movement;
    void Update()
    {   
        if (initial_timer>=0){
            initial_timer-=Time.deltaTime;
            timer_txt.text = "Timer:"+(initial_timer>=10f?initial_timer.ToString("F1"):"0"+initial_timer.ToString("F1"));
           /** var timer_string=(initial_timer.ToString()).Split(".");
            timer_txt.text="Timer:"+
                                (float.Parse(timer_string[0])>=10f ? timer_string[0]:"0"+timer_string[0])
                                +"."
                                +timer_string[1][0];*/
        }else{
             timer_txt.text="Timer:00.0";
             GameOver();
        }  
    }
    void GameOver(){
        game_over_txt.SetActive(true);
        Time.timeScale = .1f;//will slow down everything in a game
        movement.enabled=false;
    }
}
