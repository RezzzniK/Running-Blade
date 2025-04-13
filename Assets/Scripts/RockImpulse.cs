using System.Collections;
using Unity.Cinemachine;
using UnityEngine;

public class RockImpulse : MonoBehaviour
{   
    [SerializeField] ParticleSystem collisionRock;
    [SerializeField] float collisionCoolDown=2f;
     CinemachineImpulseSource source;
     float shakeModifier=10f;
    AudioSource audioSource;
    bool inProgress=false;
    void Awake(){
        source = GetComponent<CinemachineImpulseSource>();  
        audioSource=GetComponent<AudioSource>();
    }
    void OnCollisionEnter(Collision collision){
        if(!inProgress){
            FireImpulse();
            CollisionFX(collision);
        }
    }
    private void FireImpulse(){
        float distance = Vector3.Distance(transform.position, Camera.main.transform.position);
        source.GenerateImpulse(shakeModifier / distance);
        audioSource.volume = shakeModifier / distance;
       
    }
    void CollisionFX(Collision type){     
            inProgress=true;
            /**type responsable of returning contact side of the collision*/
            ContactPoint contactPoint=type.contacts[0];//will return first contact point
            //now lets move our PS to that point
            collisionRock.transform.position = contactPoint.point;//will move the PS to the collision point
            collisionRock.Play(); 
            audioSource.Play();
            StartCoroutine(hitTimer()); 
    }

        IEnumerator hitTimer(){
        yield return new WaitForSeconds(collisionCoolDown);
        inProgress=false;
    
    }
}
