using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Target : MonoBehaviour
{
    //========================================
    //NOTE: Assign to collider
    //=======================================
    public int point = 0;

    public GameObject objectname;
    public GameObject Scoring;
    public GameObject _replacement;

    void Start()
    {
    }

    public void TakeDamage()
    {
        Debug.Log("hit");
        //getting score component and adding point
         Score score = Scoring.GetComponent<Score>();
        score.addpoint(point);
        //score first before replacing prefab
        var replacement = Instantiate(_replacement, transform.position, transform.rotation);

        
        Destroy(objectname);
    }
}
