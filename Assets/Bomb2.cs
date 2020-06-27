using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb2 : MonoBehaviour
{
  public float countdown = 2f;

    // Update is called once per frame
    void Update()
    {
      countdown -= Time.deltaTime;

      if (countdown <= 0f) {
        FindObjectOfType<MapDestroyer>().Explode(transform.position, false);
        Destroy(gameObject);
      }
    }
}
