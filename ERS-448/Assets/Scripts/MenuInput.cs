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
                if (hit.collider.CompareTag("menu"))
                {
                    Application.LoadLevel("MenuScene");
                }
                if (hit.collider.CompareTag("game"))
                {
                    Application.LoadLevel("GameScene");
                }
                if (hit.collider.CompareTag("instructions"))
                {
                    Application.LoadLevel("InstructionScene");
                }
            }
        }
    }
}
