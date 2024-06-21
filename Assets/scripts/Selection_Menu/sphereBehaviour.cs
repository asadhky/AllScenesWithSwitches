using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sphereBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.SetActive(true);
        StartCoroutine(waiterMode());

    }
    IEnumerator waiterMode()
    {
        yield return new WaitForSeconds(5);
        gameObject.SetActive(false);




    }
}
