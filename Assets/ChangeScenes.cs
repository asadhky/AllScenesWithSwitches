using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    public void GoToSceneTwo() {
        SceneManager.LoadScene("NewScene2");
    }

    public void GoToSceneThree() {
        SceneManager.LoadScene("RotationScene");
    }

    public void GoToSceneOne() {
        SceneManager.LoadScene("SampleScene");
    }

    public void GoToSceneFour()
    {
        SceneManager.LoadScene("MoveObjectScene");
    }
}
