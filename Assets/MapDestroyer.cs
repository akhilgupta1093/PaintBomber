using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapDestroyer : MonoBehaviour
{
  public Tilemap tilemap;
  public Tilemap tilemap_background;

  public Tile wallTile1;
  public Tile wallTile2;
  public Tile wallTile3;
  public Tile wallTile4;
  public Tile barrelTile;
  public Tile destructibleTile;

  public GameObject explosionPrefab;

  public void Explode(Vector2 worldPos, bool magenta) {
    Vector3Int originCell = tilemap.WorldToCell(worldPos);

    ExplodeCell(originCell, magenta);
    if (ExplodeCell(originCell + new Vector3Int(1, 0, 0), magenta)) {
      ExplodeCell(originCell + new Vector3Int(2, 0, 0), magenta);
    }
    if (ExplodeCell(originCell + new Vector3Int(0, 1, 0), magenta)) {
      ExplodeCell(originCell + new Vector3Int(0, 2, 0), magenta);
    }
    if (ExplodeCell(originCell + new Vector3Int(-1, 0, 0), magenta)) {
      ExplodeCell(originCell + new Vector3Int(-2, 0, 0), magenta);
    }
    if (ExplodeCell(originCell + new Vector3Int(0, -1, 0), magenta)) {
      ExplodeCell(originCell + new Vector3Int(0, -2, 0), magenta);
    }
  }

  bool ExplodeCell(Vector3Int cell, bool magenta) {
    Tile tile = tilemap.GetTile<Tile>(cell);

    if (wallTile(tile)){
      return false;
    } else if(tile == destructibleTile) {
      tilemap.SetTile(cell, null);
    } else {
      FindObjectOfType<Score>().ChangeScore(cell.x + 6, cell.y + 3, magenta);
      if (magenta) {
        setTileColor(Color.magenta, cell, tilemap_background);
      } else {
        setTileColor(Color.cyan, cell, tilemap_background);
      }
    }

    Vector3 pos = tilemap.GetCellCenterWorld(cell);
    Instantiate(explosionPrefab, pos, Quaternion.identity);

    return true;
  }

  public bool wallTile(Tile tile) {
    if (tile == wallTile1 || tile == wallTile2 || tile == wallTile3 || tile == wallTile4 || tile == barrelTile){
      return true;
    }
    return false;
  }

  public void setTileColor(Color color, Vector3Int position, Tilemap tilemap) {
    tilemap.SetTileFlags(position, TileFlags.None);

    tilemap.SetColor(position, color);
  }
}
