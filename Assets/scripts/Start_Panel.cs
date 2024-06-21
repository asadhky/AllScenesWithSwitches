using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;
//using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;
using static UnityEngine.ParticleSystem;

public class Start_Panel : MonoBehaviour
{
    public GameObject text_welcome;
    public GameObject text_introduction;
    // Start is called before the first frame update
    void Start()
    {
        text_welcome.SetActive(true);
        text_introduction.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(waiterMode());


    }
    IEnumerator waiterMode()
    {
        yield return new WaitForSeconds(3);
        text_welcome.SetActive(false);
        text_introduction.SetActive(true);




    }

}
