using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
  public Text timer;
  public int amountOfTime;
  int count = 0;

    // Update is called once per frame
    void Update()
    {
      timer.text = amountOfTime.ToString();
      count += 1;
      if (count >= 32) {
        amountOfTime -= 1;
        count = 0;
      }
    }
}
