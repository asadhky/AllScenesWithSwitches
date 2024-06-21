using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class ChangeColor : MonoBehaviour
{
    private MeshRenderer renderer;
    public bool normal;
    public GameObject banner;
    public int counter = 0;
    public bool first = true;
    public int rounds;
    // Start is called before the first frame update
    void Start()
    {
        Color col;
        if (!normal)
        {
            col = Color.blue;

            renderer = gameObject.GetComponent<MeshRenderer>();
            renderer.material.color = col;
        }
  
    }
    private void Awake()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (counter == rounds)
        {
            gameObject.SetActive(false);
            Debug.Log("ferig");
            Application.Quit();

        }
        else
        {
            if (first)
            {
                Color col = Color.white;
                if (!normal)
                {
                    col = Color.blue;
                }

                renderer = gameObject.GetComponent<MeshRenderer>();

                renderer.material.color = col;

                first = false;

            }

            if (!banner.activeSelf)
            {
                gameObject.SetActive(true);
            }
        }
        

        
        StartCoroutine(waiterColor2());
        
    }

    IEnumerator waiterColor2()
    {
        
        yield return new WaitForSeconds(3);

        if (!normal)
        {
            Color colnew = Color.white;
            renderer.material.color = colnew;

        }
        Debug.Log("bin hier");
        yield return new WaitForSeconds(5);

        counter = counter + 1;

        if (counter == rounds)
        {
            Application.Quit();
            gameObject.SetActive(false);
          
        
        }
        else
        {
            banner.SetActive(true);
            first = true;
            Debug.Log(counter);
            gameObject.SetActive(false);
        }





    }
}
