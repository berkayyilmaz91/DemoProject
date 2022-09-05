using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonPainter : MonoBehaviour
{
    public void ArtGameScene()
    {
        SceneManager.LoadScene(2);
        Debug.Log("2. Sahne");
    }
}
