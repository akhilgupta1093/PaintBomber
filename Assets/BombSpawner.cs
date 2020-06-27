using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BombSpawner : MonoBehaviour
{
  public Tilemap tilemap;
  public GameObject bombPrefab;
  public GameObject bombPrefab2;

  public GameObject player;
  public GameObject player2;

    // Update is called once per frame
    void Update()
    {
      if (Input.GetKeyDown(KeyCode.Slash)) { // Player 1
         // Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
         Vector3 worldPos = player.GetComponent<Rigidbody2D>().position;

         Vector3Int cell = tilemap.WorldToCell(worldPos);

         Tile tile = tilemap.GetTile<Tile>(cell);
         if (FindObjectOfType<MapDestroyer>().wallTile(tile)) {
           return;
         }

         Vector3 cellCenterPos = tilemap.GetCellCenterWorld(cell);

         Instantiate(bombPrefab, cellCenterPos, Quaternion.identity);
      }

      if (Input.GetButtonDown("Jump")) { // Player 2
         // Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
         Vector3 worldPos = player2.GetComponent<Rigidbody2D>().position;

         Vector3Int cell = tilemap.WorldToCell(worldPos);

         Tile tile = tilemap.GetTile<Tile>(cell);
         if (FindObjectOfType<MapDestroyer>().wallTile(tile)) {
           return;
         }

         Vector3 cellCenterPos = tilemap.GetCellCenterWorld(cell);

         Instantiate(bombPrefab2, cellCenterPos, Quaternion.identity);
      }
    }
}
