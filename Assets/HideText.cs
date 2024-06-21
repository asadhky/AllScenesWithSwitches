using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideText : MonoBehaviour
{
    public static bool isHide = true;
    public GameObject[] cubes;
  
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("hello2");
    }

    private void Awake()
    {
        Debug.Log("hello3");

    }

    // Update is called once per frame
    void Update()
    {
        gameObject.SetActive(true);
        StartCoroutine("waiter",1f);
    }
    IEnumerator waiter()
    {
        yield return new WaitForSeconds(5);

     
        gameObject.SetActive(false);
        foreach (var cube in cubes)
        {
            cube.SetActive(true);
        }
    }
       
    
}
