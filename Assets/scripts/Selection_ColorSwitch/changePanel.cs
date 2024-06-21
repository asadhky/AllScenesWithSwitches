using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class changePanel : MonoBehaviour
{
    public Image panel;
    // Start is called before the first frame update
    void Start()
    {
        panel = gameObject.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        panel.tintColor = Color.blue;
    }
    IEnumerator waiterMode()
    {
        yield return new WaitForSeconds(4);

        Color col = Color.blue;

        

    }
}
