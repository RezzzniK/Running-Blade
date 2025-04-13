using System.Collections;
using Unity.Cinemachine;
using UnityEngine;

public class CameraControler : MonoBehaviour
{
    //to be able to manipulate with fov we need refernce to 
    //cinemachine camera
    CinemachineCamera cmr;
    [SerializeField] float minOffset=20f;
    [SerializeField] float maxOffset=120f;
    [SerializeField] float zoomDuration=1f;//how long we will be lerping from a to b
    // [SerializeField] float drusticModifyer=5f;
    [SerializeField] ParticleSystem speedEffect;
    void Awake()
    {
        //getting ref to camers
        cmr=GetComponent<CinemachineCamera>();
    }
    public void updateCameraFOV(float dist){/**update camera field of view*/
        StopAllCoroutines();
        StartCoroutine(setFOVdist(dist));
        if(dist>0){
            speedEffect.Play();
        }else{
            speedEffect.Stop();
        }
    }

    //we going to use corutine to make it instantly with certain amount of time
    IEnumerator setFOVdist(float dist){
        //we going to use lerp(travaling from a to b by certain amount of time)
        //we need start position
        float startFOV=cmr.Lens.FieldOfView;
        //we need end position
        float endFOV=Mathf.Clamp(startFOV+dist,minOffset,maxOffset);
        //we need time 
        float elapsedTime=0;
        while(elapsedTime<zoomDuration){//so this code gives linearly interpolating between 2 points
           
            float t=elapsedTime/zoomDuration;//incresasing time for lerping, each loop
            elapsedTime+=Time.deltaTime;
            cmr.Lens.FieldOfView=Mathf.Lerp(startFOV,endFOV,t);
            yield return null;//force return from the loop
        }
        cmr.Lens.FieldOfView=endFOV;//in case to makce sure that we arrived to the target dest
    }
}
