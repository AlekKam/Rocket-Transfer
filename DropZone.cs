using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DropZone : MonoBehaviour
{
    public int bouldersNeededToComplete = 3;
    private int bouldersInZone = 0;

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Boulder"))
        {
            bouldersInZone++;
            if (bouldersInZone >= bouldersNeededToComplete)
            {
                CompleteStage();
            }
        }
    }

    public void CompleteStage()
    {
        Debug.Log("Stage Complete!");
        RestartScene();
        bouldersInZone = 0;
    }

    void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
