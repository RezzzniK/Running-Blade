using UnityEngine;

public class CheckPoint : MonoBehaviour
{
   [SerializeField] ParticleSystem[] particles;
   GameStateMG gm;
    void Start(){
        gm = FindFirstObjectByType<GameStateMG>();
    }
    void OnTriggerEnter(Collider other)
    {
       
        if(other.gameObject.tag == "Player" && !gm.Game_Over){
            gm.UpdateTImer();
            foreach (var particle in particles)
            {
                particle.Play() ;
            }
        }
    }
}
