/// File Name UserInput.cs.
/// Assignment EECS 448 Project 3.
/// Brief Register clicks from user.

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
     \post registers mouse click and calls function.
     \return none.
    */

    void Update()
    {
        GetMouseClick();
    }

    /*!
     \pre mouse is clicked.
     \post check if deck or button is clicked.
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
                    /// clicked deck.
                    clickedDeck();
                }
                if (hit.collider.CompareTag("Button"))
                {
                    /// clicked button.
                    clickedButton();
                }
            }
        }
    }

    /*!
     \pre mouse clicked.
     \post if deck clicked, deak card .
     \return none.
    */

    void clickedDeck()
    {
        ers.dealCards();
    }

    /*!
     \pre mouse clicked.
     \post resets board.
     \return none.
    */

    void clickedButton()
    {
        ers.resetBoard();
    }
}
