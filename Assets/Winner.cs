using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Winner : MonoBehaviour
{

  public string finalWinner = "Welcome";

    void Awake() {
      DontDestroyOnLoad(transform.gameObject);
    }

    public void Declare(string winner)
    {
      finalWinner = winner;
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public string getWinner() {
      return finalWinner;
    }
}
