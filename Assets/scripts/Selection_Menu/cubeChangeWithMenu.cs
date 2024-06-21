using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class cubeChangeWithMenu : MonoBehaviour
{
    public Toggle toggleBlack;
    public Toggle toggleWhite;
    private MeshRenderer renderer;
    public bool first = true;
    public GameObject sphere;
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
        yield return new WaitForSeconds(4);
        
        sphere.SetActive(true);
        gameObject.SetActive(false);




    }
}
