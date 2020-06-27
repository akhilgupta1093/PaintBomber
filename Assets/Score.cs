using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
  int[,] ra = new int[9, 9];
  int p1total = 0;
  int p2total = 0;
  public string winner = "hello";

    public void ChangeScore(int x, int y, bool player1) {
      ra[x, y] = player1 ? 1 : 2;
    }

    public void FinishGame() {
      for (int i = 0; i < 9; i++) {
        for (int j = 0; j < 9; j++) {
          if (ra[i, j] == 1) {
            p1total += 1;
          } else if (ra[i, j] == 2) {
            p2total += 1;
          }
        }
      }
      winner = (p1total > p2total) ? "Purple Wins!" : (p2total > p1total) ? "Blue Wins!" : "It's a Draw!";
      FindObjectOfType<Winner>().Declare(winner);
    }
}
