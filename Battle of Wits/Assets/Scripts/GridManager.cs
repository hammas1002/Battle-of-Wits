using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class GridManager : MonoBehaviour
{
    [SerializeField] private int _width, _height;
    [SerializeField] private Tile _tilePrefab;
    public Transform[] _shields;

    private Dictionary<Vector2, Tile> _tiles;

    private void Start()
    {
        generateGrid();
    }
    private void generateGrid()
    {
        _tiles = new Dictionary<Vector2, Tile>();
        for (int x = 0; x < _width; x++) {
            for (int y = 0; y <_height; y++)
            {
                var spawnedTile = Instantiate(_tilePrefab,new Vector2(x,y),Quaternion.identity);
                spawnedTile.name = $"Tile {x} {y}";
                spawnedTile.gameObject.layer = 9;
                
                bool isOffset = (x % 2 !=  y % 2);
                spawnedTile.Init(isOffset);

                _tiles[new Vector2(x, y)] = spawnedTile;
            }
         }
        //move camera towards the center of generated grid.
        Camera.main.transform.position = new Vector3(_width/2-0.5f,_height/2-0.5f,-10);
    }

    public void getadjacentTiles(Vector2 selectedTile)
    {
        

        Vector2[] adjacentTilesPos = {new Vector2(selectedTile.x-1,selectedTile.y),
        new Vector2(selectedTile.x+1,selectedTile.y),
        new Vector2(selectedTile.x,selectedTile.y+1),
        new Vector2(selectedTile.x,selectedTile.y-1)};

        List<Tile> adjacentTiles = new List<Tile>();

        //getting all possible adjacent tiles
        for (int i=0; i< adjacentTilesPos.Length; i++)
        { 
            if (_tiles.TryGetValue(adjacentTilesPos[i], out var tile))
            {
                
                adjacentTiles.Add(tile);
                
            }
        }
        //removing already occupid tiles.
        for (int i = 0; i < _shields.Length; i++)
        {
            if (_tiles.TryGetValue(_shields[i].position, out var tile))
            {

                adjacentTiles.Remove(tile);

            }
        }

        _tilePrefab.changeColor(adjacentTiles);
    }
    
}
