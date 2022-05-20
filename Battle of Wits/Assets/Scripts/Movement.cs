using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private GameObject _controls;
    public bool playerSelected;
    private GridManager _gridManager;
    private GameManager _gameManager;
    private void Start()
    {
       
        _gridManager = FindObjectOfType<GridManager>();
        _gameManager = FindObjectOfType<GameManager>();

    }
    private void Awake()
    {
        playerSelected = false;
    }
    private void OnMouseUpAsButton()
    {
        var _tile = FindObjectOfType<Tile>();
        Debug.Log("player selected: "+playerSelected);
        if (playerSelected==false)
        {
            var controls = GameObject.Find("Controls");
            if (controls!=null)
            {
                controls.SetActive(false);
            }
            _tile.resetColors();
            Debug.Log("player clicked");
            _gameManager.selectPlayer(gameObject);
            _controls.SetActive(true);
            _gridManager.getadjacentTiles(new Vector2(transform.position.x, transform.position.y));
            playerSelected = true;
        }
        else
        {
            Debug.Log("player removed: ");

            _tile.resetColors();
            
            _controls.SetActive(false);

            playerSelected = false;

        }

    }
    public void setPlayerTurn()
    {
        StartCoroutine(_gameManager.setPlayerTurn());
    }

    public void invertPlayerSelected()
    {
        playerSelected= !playerSelected;
    }
}
