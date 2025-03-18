using System.Collections;
using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour
{
    [SerializeField] Animator animator;//reference to animator to trigger anim
    [SerializeField] float collisionCoolDown=1f;

    LevelGenerator levelGenerator;//level generator class
    bool inProgress=false;

    void Start()
    {
        levelGenerator=FindFirstObjectByType<LevelGenerator>();
    }
    void OnCollisionEnter(Collision collision)
    {
        if(!inProgress){
           
            inProgress=true;
            animator.SetTrigger("HIT");
            levelGenerator.ChangeLevelSpeed(-1f);
            StartCoroutine(hitTimer());
        }
      
    }

    IEnumerator hitTimer(){
        yield return new WaitForSeconds(collisionCoolDown);
        inProgress=false;
    }
}
