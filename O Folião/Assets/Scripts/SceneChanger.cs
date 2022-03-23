using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void DeathEnergy()
    {
        SceneManager.LoadScene("FailSceneEnergy");
    }
    public void DeathAlcool()
    {
        SceneManager.LoadScene("FailSceneAlcool");
    }

    public void Win()
    {
        SceneManager.LoadScene("WinScene");
    }


}
