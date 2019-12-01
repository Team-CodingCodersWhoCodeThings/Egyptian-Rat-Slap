/// File Name UserInput.cs.
/// Assignment EECS 448 Project 3.
/// Brief Register clicks from user in game.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInput : MonoBehaviour
{
    private ERS ers;

    /*!
     \pre game is ran.
     \post finds object for ers to interact with.
     \return none.
    */

    void Start()
    {
        ers = FindObjectOfType<ERS>();
    }

    /*!
     \pre game is ran.
     \post register mouse click or space press.
     \return none.
    */

    void Update()
    {
        GetMouseClick();
        /// If space is pressed, call slap deck.
        if (Input.GetKeyDown("space"))
        {
            ers.slap(ers.PlayerDeck);
        }
    }

    /*!
     \pre mouse is clicked.
     \post check what is clicked.
     \return none.
    */

    void GetMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -10));
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit)
            {
                /// Check what was hit.
                if (hit.collider.CompareTag("Deck"))
                {
                    /// Clicked deck.
                    ers.playCard(ers.PlayerDeck);
                }
                if (hit.collider.CompareTag("Button"))
                {
                    /// Clicked slap button.
                    ers.slap(ers.PlayerDeck);
                }
                if (hit.collider.CompareTag("easy"))
                {
                    /// Selected easy difficulty.
                    ers.timings = new int[] {65, 55};
                    ers.difficultySelect = false;
                    GameObject.Find("Easy").GetComponent<SpriteRenderer>().sprite = null;
                    GameObject.Find("Medium").GetComponent<SpriteRenderer>().sprite = null;
                    GameObject.Find("Hard").GetComponent<SpriteRenderer>().sprite = null;
                }
                if (hit.collider.CompareTag("medium"))
                {
                    /// Selected medium difficulty.
                    ers.timings = new int[] {50, 40};
                    ers.difficultySelect = false;
                    GameObject.Find("Easy").GetComponent<SpriteRenderer>().sprite = null;
                    GameObject.Find("Medium").GetComponent<SpriteRenderer>().sprite = null;
                    GameObject.Find("Hard").GetComponent<SpriteRenderer>().sprite = null;
                }
                if (hit.collider.CompareTag("hard"))
                {
                    /// Selected hard difficulty.
                    ers.timings = new int[] {38, 28};
                    ers.difficultySelect = false;
                    GameObject.Find("Easy").GetComponent<SpriteRenderer>().sprite = null;
                    GameObject.Find("Medium").GetComponent<SpriteRenderer>().sprite = null;
                    GameObject.Find("Hard").GetComponent<SpriteRenderer>().sprite = null;
                }
                if (hit.collider.CompareTag("menu"))
                {
                    /// Clicked return to menu.
                    Application.LoadLevel("MenuScene");
                }
                if (hit.collider.CompareTag("play"))
                {
                    /// Clicked play again.
                    ers.winRenderer.sprite = null;
                    ers.difficultySelect = false;
                    GameObject.Find("Menu Button").GetComponent<SpriteRenderer>().sprite = null;
                    GameObject.Find("Play Again Button").GetComponent<SpriteRenderer>().sprite = null;
                }
            }
        }
    }
}
