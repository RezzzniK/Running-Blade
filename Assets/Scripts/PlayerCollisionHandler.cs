using System.Collections;
using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour
{
    [SerializeField] Animator animator;//reference to animator to trigger anim
    [SerializeField] float collisionCoolDown=1f;
    bool inProgress=false;
    void OnCollisionEnter(Collision collision)
    {
        if(!inProgress){
           
            inProgress=true;
            animator.SetTrigger("HIT");
            StartCoroutine(hitTimer());
        }
      
    }

    IEnumerator hitTimer(){
        yield return new WaitForSeconds(collisionCoolDown);
        inProgress=false;
    }
}
