using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyinSeconds : MonoBehaviour
{
    [SerializeField] private float seconds;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DestroyinSecond());
    }


    IEnumerator DestroyinSecond()
    {
        yield return new WaitForSeconds(seconds);

        Destroy(gameObject);
    }
}
