using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelManager : MonoBehaviour
{

  public TextMeshProUGUI text;

    void Start() {
      string winner = FindObjectOfType<Winner>().getWinner();
      text.SetText(winner);
    }

    public void Restart()
    {
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
