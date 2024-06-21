using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class banner_Menu : MonoBehaviour
{
    public GameObject menu;
    public GameObject cube;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        gameObject.SetActive(true);
        StartCoroutine(waiterMode());
    }
    IEnumerator waiterMode()
    {
        yield return new WaitForSeconds(4);
        menu.SetActive(true);
        cube.SetActive(true);
        gameObject.SetActive(false);
        



    }
}
