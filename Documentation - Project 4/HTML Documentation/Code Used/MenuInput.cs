/// File Name MenuInput.cs.
/// Assignment EECS 448 Project 3.
/// Brief Register clicks from user in Menus.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuInput : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame

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
     \post check which menu button is clicked.
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
                if (hit.collider.CompareTag("menu"))
                {
                    /// Clicked return to menu.
                    Application.LoadLevel("MenuScene");
                }
                if (hit.collider.CompareTag("game"))
                {
                    /// Clicked play game.
                    Application.LoadLevel("GameScene");
                }
                if (hit.collider.CompareTag("instructions"))
                {
                    /// Clicked instructions.
                    Application.LoadLevel("InstructionScene");
                }
            }
        }
    }
}
