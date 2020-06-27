using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class player2 : MonoBehaviour
{
    Rigidbody2D rb;
    public Tilemap tilemap;

    public float interval = 0.1f;
    float nextTime = 0;

    void Start() {
      rb = GetComponent <Rigidbody2D> ();
    }

    void Update () {
      if (Time.time >= nextTime) {
        int x = Mathf.RoundToInt(Input.GetAxisRaw("P2_Horizontal"));
        int y = Mathf.RoundToInt(Input.GetAxisRaw("P2_Vertical"));

        Vector3Int currCell = tilemap.WorldToCell(transform.position);
        Vector3 currPos = tilemap.GetCellCenterWorld(currCell);

        Tile tile = tilemap.GetTile<Tile>(currCell + new Vector3Int(x, y, 0));
        if (!FindObjectOfType<MapDestroyer>().wallTile(tile)) {
          transform.position = currPos + new Vector3(x, y, 0);
        }

        nextTime += interval;
      }
    }
}
