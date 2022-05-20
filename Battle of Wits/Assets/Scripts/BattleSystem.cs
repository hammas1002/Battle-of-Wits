using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleSystem : MonoBehaviour
{
    public GameObject player1,player2;
    private GameObject currentPlayerTurn;
    public GameObject canvas;
    public Text winnerName;
    public GameObject selectionBarrier;

    bool playerTurn;

    private void Start()
    {
        playerTurn = true;
        currentPlayerTurn = player1;
        player1Turn();
    }
    void player1Turn()
    {
        Debug.Log("hello player1");
        player1.GetComponent<BoxCollider2D>().enabled = true;
        player2.GetComponent<BoxCollider2D>().enabled=false;
        //player1 action.

    }
    void player2Turn()
    {
        Debug.Log("hello player2");
        player2.GetComponent<BoxCollider2D>().enabled = true;
        player1.GetComponent<BoxCollider2D>().enabled = false;
        //player2 action.

    }

    public void setPlayerTurn()
    {
        playerTurn = !playerTurn;
        if (playerTurn)
        {
            currentPlayerTurn = player1;
            player1Turn();
        }
        else
        {
            currentPlayerTurn = player2;
            player2Turn();
        }
    }
    public GameObject getPlayerTurn()
    {
        return currentPlayerTurn;
    }

    public void setWinner(string _winnerName)
    {
        selectionBarrier.SetActive(true);
        var winner = _winnerName;
        canvas.SetActive(true);
        this.winnerName.text = winner.ToString();
        Time.timeScale = 0;
    }
}
