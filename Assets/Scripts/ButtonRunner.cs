using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonRunner : MonoBehaviour
{     
    public void RunnerGameScene()
    {
        SceneManager.LoadScene(1);
        Debug.Log("1. Sahne");

    }
   
}
