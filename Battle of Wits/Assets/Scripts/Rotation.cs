using UnityEngine;
public class Rotation : MonoBehaviour
{
     [SerializeField] private Tile _tile;
    private GameManager _gameManager;

    private void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
    }

    private void OnMouseUpAsButton()
    {
       var player = transform.parent.transform.parent;
        
       

        if (gameObject.name== "rotateRightArrow")
        {
            player.transform.RotateAround(player.transform.position,Vector3.forward,-90);

        }
        else if (gameObject.name == "rotateLeftArrow")
        {
            player.transform.RotateAround(player.transform.position, Vector3.forward, 90);
        }
        _gameManager.generateProjectile();
        removeControls();

        if (player.name=="shield")
        {
            player.GetComponent<Shield>().setAngleShift();
        }
        
    }

    public void removeControls()
    {
       
        
        var _tile = FindObjectOfType<Tile>();
        _tile.resetColors();
        var controls = transform.parent.gameObject;
        transform.parent.transform.parent.gameObject.GetComponent<Movement>().invertPlayerSelected();
        transform.parent.transform.parent.gameObject.GetComponent<Movement>().setPlayerTurn();
        controls.SetActive(false);

    }


}
