using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bannerBehaviour : MonoBehaviour
{
    public GameObject[] cubes;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        gameObject.SetActive(true);
        StartCoroutine(waiter());
    }

    IEnumerator waiter()
    {
        yield return new WaitForSeconds(4);


        gameObject.SetActive(false);
        foreach (var cube in cubes)
        {
            cube.SetActive(true);
        }
    }
}
