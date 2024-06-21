using System.Collections;
using UnityEngine;

public class CubeRotator : MonoBehaviour
{
    public float rotationAngle = 90f;
    public float rotationDuration = 0.1f; 
    public float delayBetweenRotations = 0.1f;
    public int counter = 0;
    public GameObject gameObject;

    private void Start()
    {
        StartCoroutine(RotateCube());
    }

    private IEnumerator RotateCube()
    {
        yield return new WaitForSeconds(6);

        while (true)
        {
            
            yield return Rotate(Vector3.right * rotationAngle);
            yield return new WaitForSeconds(delayBetweenRotations);

            yield return Rotate(Vector3.left * rotationAngle);
            yield return new WaitForSeconds(delayBetweenRotations);

            yield return Rotate(Vector3.up * rotationAngle);
            yield return new WaitForSeconds(delayBetweenRotations);

            yield return Rotate(Vector3.down * rotationAngle);
            yield return new WaitForSeconds(delayBetweenRotations);
            counter = counter + 1;

            if (counter == 4){
                gameObject.SetActive(true);
                counter = 0;
                yield return new WaitForSeconds(4);
            }
        }
    }

    private IEnumerator Rotate(Vector3 byAngles)
    {
        Quaternion from = transform.rotation;
        Quaternion to = transform.rotation * Quaternion.Euler(byAngles);
        float elapsed = 0f;

        while (elapsed < rotationDuration)
        {
            transform.rotation = Quaternion.Slerp(from, to, elapsed / rotationDuration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.rotation = to;
        Debug.Log("Rotation complete: " + byAngles);
    }
}
