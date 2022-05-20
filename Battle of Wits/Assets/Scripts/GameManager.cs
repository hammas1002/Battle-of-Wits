using UnityEngine;
using System.Collections;
public class GameManager : MonoBehaviour
{
    
    private GameObject playerSelected;
    public GameObject selectionBarrier;
    private BattleSystem _battleSystem;
    private void Start()
    {
        
        _battleSystem = FindObjectOfType<BattleSystem>();
    }
    [SerializeField] private Projectile _projectile;
    public void selectPlayer(GameObject clickedPlayer)
    {
        playerSelected = clickedPlayer;
        
        Debug.Log("player selected"+playerSelected.name);
    }

    public void movePlayerToClickedTile(Vector2 clickPos)

    {   //Selected Player movement
        playerSelected.transform.position = new Vector3(clickPos.x,clickPos.y,playerSelected.transform.position.z);

        //removing child element controls;
       GameObject controls = playerSelected.transform.GetChild(0).gameObject;
        //generating projectile
       
        
       generateProjectile();
        
        

        controls.SetActive(false);
        playerSelected.GetComponent<Movement>().invertPlayerSelected();
        // player turns
        if (playerSelected.name!="shield")
        {
            playerSelected.GetComponent<BoxCollider2D>().enabled = false;
        }
        
        StartCoroutine(setPlayerTurn());
    }
    public IEnumerator setPlayerTurn() {

        selectionBarrier.SetActive(true);
        yield return new WaitForSeconds(3);
        selectionBarrier.SetActive(false);
        FindObjectOfType<BattleSystem>().setPlayerTurn();
    }
    public void generateProjectile()
    {
        //generating projectile
        var currentPlayer = _battleSystem.getPlayerTurn();
        Instantiate(_projectile,currentPlayer.transform.position, currentPlayer.transform.rotation);
    }
}
