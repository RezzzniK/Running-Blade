using TMPro;
using UnityEngine;
public class GameStateMG : MonoBehaviour
{
    [SerializeField] TMP_Text timer_txt;    
    [SerializeField] float initial_timer=60f;
    [SerializeField] float max_timer_upd=5f;
    [SerializeField] GameObject game_over_txt; 
    [SerializeField] PlayerMovement movement;

    bool gameOver=false;
    // public bool Game_Over{
    //     get{ return gameOver; }
    //     set{ gameOver = value; }
    // }
    // public bool Game_Over{get; private set;}
    public bool Game_Over=>gameOver;
    void Update()
    {   
        if (initial_timer>=0){
            initial_timer-=Time.deltaTime;
            timer_txt.text = "Timer:"+(initial_timer>=10f?initial_timer.ToString("F1"):"0"+initial_timer.ToString("F1"));
        }else{
             timer_txt.text="Timer:00.0";
             GameOver();
        }  
    }
    public void UpdateTImer(){
        initial_timer+=max_timer_upd;
    }
    void GameOver(){
        game_over_txt.SetActive(true);
        Time.timeScale = .1f;//will slow down everything in a game
        movement.enabled=false;
        // Game_Over=true;
        gameOver=true;
    }

}
