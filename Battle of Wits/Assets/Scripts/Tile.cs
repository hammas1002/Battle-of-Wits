using UnityEngine;
using System.Collections.Generic;
using System.Linq;
public class Tile : MonoBehaviour
{
    [SerializeField] private Color _baseColor, _offsetColor,_moveAbleColor,_initialColor;
    [SerializeField] private SpriteRenderer _tileRenderer;
    [SerializeField] private GameObject _highlight;
    private static List<Tile> adjacentTiles;
    [SerializeField]
    private static List<Tile> allTilesObj;
    
    private GameManager _gameManager;
    private void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
        
    }

    public void Init(bool isOffset)
    {
         _tileRenderer.color = isOffset ? _offsetColor : _baseColor;
        _initialColor = _tileRenderer.color;
    }

    private void OnMouseEnter()
    {
        _highlight.SetActive(true);
    }
    private void OnMouseExit()
    {
        _highlight.SetActive(false);
    }

    public void changeColor(List<Tile> _adjacentTiles)
    {
        adjacentTiles = _adjacentTiles;
        adjacentTiles.ForEach(element => {
            element._tileRenderer.color = _moveAbleColor;
        });
    }

    private void OnMouseUpAsButton()
    {
        if (_tileRenderer.color == _moveAbleColor)
        {
            Debug.Log("moving player");
            _gameManager.movePlayerToClickedTile(transform.position);
            
            resetColors();
        }
        
    }
    public void resetColors()
    {
        // removing moveable tiles (changing color back to normal. for next turn)

         allTilesObj = FindObjectsOfType<Tile>().ToList();

        allTilesObj.ForEach(element => {
            
            element._tileRenderer.color = element._initialColor;
            
        });

        
    }





}
