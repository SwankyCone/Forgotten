using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public Transform FirePoint;
    //public GameObject Fire;
    //public GameObject HitPoint;


    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            if(Input.GetMouseButtonDown(0))
            {
                Shooting();
            }
            
        }
        
    }

    public void Shooting()
    {

        RaycastHit hit;

        if(Physics.Raycast(FirePoint.position , transform.TransformDirection(Vector3.forward), out hit, 100)) 
        {
            Debug.DrawRay(FirePoint.position , transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);

            //Instantiate(Fire , FirePoint.position, Quaternion.identity);
            //Instantiate(HitPoint, hit.point, Quaternion.identity);

            Enemy enemy = hit.transform.GetComponent<Enemy>();

            if (enemy != null)
            {
                enemy.Damage(2);
            }
        }



    }

    
}
