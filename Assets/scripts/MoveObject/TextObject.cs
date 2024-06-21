using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextObject : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(true);
        StartCoroutine(waiter());
    }

    IEnumerator waiter()
    {
        yield return new WaitForSeconds(4);

        gameObject.SetActive(false);

        }
}
