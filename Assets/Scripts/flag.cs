using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flag : MonoBehaviour
{
    public GameObject newFlag;
    public float posx;
    public float posy;


    void Start(){
        StartCoroutine(SpawnNewFlagAfterTime());
    }
   

    IEnumerator SpawnNewFlagAfterTime(){
        yield return new WaitForSeconds(1f);

        Vector3 position= new Vector3();
        position.x = posx;
        position.y = posy;
        position.z = 0;

        Quaternion rotation = Quaternion.Euler(0f, 0f, 0f);

        GameObject nf= Instantiate(newFlag, position, rotation) as GameObject;
        nf.transform.localPosition = new Vector3(posx,posy,0);
        Destroy(nf,1f); 
    }
   
}
