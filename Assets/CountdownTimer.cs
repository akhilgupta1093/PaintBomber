using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CountdownTimer : MonoBehaviour
{
  public float amountOfTime = 30;
  TextMeshProUGUI timer;
  bool finished = false;

    void Start() {
      transform.SetAsLastSibling();
      timer = GetComponent<TextMeshProUGUI>();
    }
    // Update is called once per frame
    void Update()
    {
      if (finished) {
        return;
      }
      amountOfTime -= 1 * Time.deltaTime;
      if (amountOfTime < 0) {
        FindObjectOfType<Score>().FinishGame();
        amountOfTime = 0;
        finished = true;
      }
      timer.SetText(amountOfTime.ToString("0"));

    }
}
