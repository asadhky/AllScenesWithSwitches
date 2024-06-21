using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ChangeMode : MonoBehaviour
{
    public Toggle whiteToggle;
    public Toggle darkToggle;
    public Dropdown textureQualityDropdown;
    public Slider musicVolumeSlider;
    public MeshRenderer renderer;
    public int counter = 0;
    public bool first = true;
    public int rounds;
    public GameObject banner;
    public GameObject cube;
    public GameObject sphere;

    // Start is called before the first frame update
    void Start()
    {
        
        gameObject.SetActive(false);

        musicVolumeSlider.value = 0.5f;
    
            
        
    }

    // Update is called once per frame
    void Update()
    {
        whiteToggle.isOn = true;
        darkToggle.isOn = false;
        if (counter == rounds)
        {
            gameObject.SetActive(false);
            Debug.Log("ferig");
            Application.Quit();

        }
        else
        {
            StartCoroutine(waiterMode());
            gameObject.SetActive(true);
        }
            
    }

    IEnumerator waiterMode()
    {
        yield return new WaitForSeconds(3);


        whiteToggle.isOn = false;
        yield return new WaitForSeconds(1);
        darkToggle.isOn = true;
        sphere.SetActive(true);
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
            
            
            gameObject.SetActive(false);
        }

      

    }
}
