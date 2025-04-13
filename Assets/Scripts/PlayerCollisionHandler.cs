using System.Collections;
using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour
{
    [SerializeField] Animator animator;//reference to animator to trigger anim
    [SerializeField] float collisionCoolDown=1f;
    [SerializeField] int collisinoPoints=-50;
    [SerializeField] ParticleSystem player_ps;
    LevelGenerator levelGenerator;//level generator class
    ScoreMG score;
    bool inProgress=false;

    void Start()
    {
        levelGenerator=FindFirstObjectByType<LevelGenerator>();
        score=FindFirstObjectByType<ScoreMG>();
        
    }
    void OnCollisionEnter(Collision collision)
    {
       
        if(!inProgress){
           
            inProgress=true;
            animator.SetTrigger("HIT");
            levelGenerator.ChangeLevelSpeed(-1f);
            StartCoroutine(hitTimer());
            score.UpdateText(collisinoPoints);
        }
      
    }
      void OnTriggerEnter(Collider other)
    {
         if (other.gameObject.tag=="Apple"){
                player_ps.Play();
            }
    }

    IEnumerator hitTimer(){
        yield return new WaitForSeconds(collisionCoolDown);
        inProgress=false;
    
    }
}
