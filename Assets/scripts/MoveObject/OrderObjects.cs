using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderObjects : MonoBehaviour
{
    [System.Serializable]
    public class ColorObject
    {
        public GameObject gameObject;
        public Color color;
        public Vector3 originalPosition;
        public Color originalColor;
    }

    public List<ColorObject> objectsToSort = new List<ColorObject>();
    public float animationDuration = 1f; // Duration of the animation
    public float iterationDelay = 2f; // Delay between iterations
    public float initialDelay = 2f; // Initial delay before starting
    public float verticalOffset = 1.25f; // Vertical offset for intermediate positions
    public int totalIterations = 4; // Total number of iterations
    private int currentIteration = 0; // Current iteration count

    private List<ColorObject> initialObjectsState; // To store initial state

    // Start is called before the first frame update
    void Start()
    {
        initialObjectsState = new List<ColorObject>();

        foreach (var obj in objectsToSort)
        {
            obj.originalPosition = obj.gameObject.transform.position;
            obj.originalColor = obj.color;

            // Store the initial state
            initialObjectsState.Add(new ColorObject
            {
                gameObject = obj.gameObject,
                color = obj.color,
                originalPosition = obj.originalPosition,
                originalColor = obj.originalColor
            });
        }

        gameObject.SetActive(true);
        // Start the sorting process with initial delay and animation
        StartCoroutine(DelayedStart());
    }

    private IEnumerator DelayedStart()
    {
        yield return new WaitForSeconds(initialDelay);
        StartCoroutine(SortObjectsWithAnimation());
    }

    private int CompareColors(Color a, Color b)
    {
        // Calculate perceived brightness of the colors
        float brightnessA = a.r * 0.299f + a.g * 0.587f + a.b * 0.114f;
        float brightnessB = b.r * 0.299f + b.g * 0.587f + b.b * 0.114f;
        return brightnessA.CompareTo(brightnessB);
    }

    private IEnumerator SortObjectsWithAnimation()
    {
        int n = objectsToSort.Count;

        while (currentIteration < totalIterations)
        {
            currentIteration++;

            // Bubble Sort with animation
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (CompareColors(objectsToSort[j].color, objectsToSort[j + 1].color) < 0)
                    {
                        Debug.Log("object: " + objectsToSort[j].gameObject + " , object color:" + objectsToSort[j].color);
                        // Swap the objects in the list
                        var temp = objectsToSort[j];
                        objectsToSort[j] = objectsToSort[j + 1];
                        objectsToSort[j + 1] = temp;

                        // Animate the movement to waypoints and then to final positions
                        Vector3 posA = objectsToSort[j].gameObject.transform.position;
                        Vector3 posB = objectsToSort[j + 1].gameObject.transform.position;

                        // Define intermediate waypoints
                        Vector3 waypointA = new Vector3(posA.x, posA.y + verticalOffset, posA.z);
                        Vector3 waypointB = new Vector3(posB.x, posB.y + verticalOffset, posB.z);

                        // Move to waypoints first
                        yield return StartCoroutine(MoveToPosition(objectsToSort[j].gameObject, posA, waypointA));
                        yield return StartCoroutine(MoveToPosition(objectsToSort[j + 1].gameObject, posB, waypointB));

                        // Move to final positions
                        yield return StartCoroutine(MoveToPosition(objectsToSort[j].gameObject, waypointA, posB));
                        yield return StartCoroutine(MoveToPosition(objectsToSort[j + 1].gameObject, waypointB, posA));

                        // Wait for the animation to complete before continuing
                        yield return new WaitForSeconds(animationDuration);
                    }
                }
            }

            // Wait for a couple of seconds after each iteration
            yield return new WaitForSeconds(iterationDelay);

            if (currentIteration < totalIterations)
            {
                foreach (var obj in objectsToSort)
                {
                    obj.gameObject.transform.position = obj.originalPosition;
                }

                // Ensure the sorting list is reset to the initial state
                objectsToSort.Clear();
                foreach (var initialObj in initialObjectsState)
                {
                    objectsToSort.Add(new ColorObject
                    {
                        gameObject = initialObj.gameObject,
                        color = initialObj.originalColor,
                        originalPosition = initialObj.originalPosition,
                        originalColor = initialObj.originalColor
                    });

                }

                // Wait for a couple of seconds before the next iteration
                yield return new WaitForSeconds(iterationDelay);
            }
        }

        // All iterations completed, optionally handle end of sorting here
        Debug.Log("Sorting completed after " + totalIterations + " iterations.");
    }

    private IEnumerator MoveToPosition(GameObject obj, Vector3 start, Vector3 end)
    {
        float elapsedTime = 0f;

        while (elapsedTime < animationDuration)
        {
            obj.transform.position = Vector3.Lerp(start, end, (elapsedTime / animationDuration));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        obj.transform.position = end;
    }
}
