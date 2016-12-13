using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShufflePuzzle : MonoBehaviour {

    public bool isOn;
    public bool[] slotBool;
    public bool[] correctPos;
    public Transform[] slotPos;
    public Camera mainCam;
    public Camera puzzleCam;
    public int openSlot;
    public int[] pieceInSlot; //Says in which slot the piece belonging to that number is
    public int clickedPiece;
    public int usePiece;
    public GameObject selectedPiece;
    public GameObject[] pieces;
    public GameObject player;

    void Start()
    {
        FindPlayer();
    }

    public void FindPlayer()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
    }

    public void FreezePlayer()
    {
        if (player == null)
        {
            FindPlayer();
        }
        player.GetComponent<CharacterScript>().freeze = true;
        player.GetComponent<CharacterScript>().hitFreeze = true;
    }

    public void SetOn()
    {
        isOn = true;
        mainCam.enabled = false;
        puzzleCam.enabled = true;
        CustomUpdate();
        FreezePlayer();
    }

    public void SetOff()
    {
        isOn = false;
        mainCam.enabled = true;
        puzzleCam.enabled = false;
        player.GetComponent<CharacterScript>().freeze = false;
        player.GetComponent<CharacterScript>().hitFreeze = false;
    }

    void CustomUpdate() {
        if (!isOn)
        {
            return;
        }
        Click();
        StartCoroutine(CustomUpdateDelay());
    }

    void Click()
    {
        if (Input.GetButtonDown("Cancel")){
            SetOff();
            return;
        }
        if (Input.GetButtonDown("Fire1"))
        {
            Ray ray = puzzleCam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.tag == "Puzzle")
                {
                    switch (hit.transform.name)
                    {
                        case "LavaPuzzle_001":
                            clickedPiece = 1;
                            break;
                        case "LavaPuzzle_002":
                            clickedPiece = 2;
                            break;
                        case "LavaPuzzle_003":
                            clickedPiece = 3;
                            break;
                        case "LavaPuzzle_004":
                            clickedPiece = 4;
                            break;
                        case "LavaPuzzle_005":
                            clickedPiece = 5;
                            break;
                        case "LavaPuzzle_006":
                            clickedPiece = 6;
                            break;
                        case "LavaPuzzle_007":
                            clickedPiece = 7;
                            break;
                        case "LavaPuzzle_008":
                            clickedPiece = 8;
                            break;
                    }
                    selectedPiece = hit.transform.gameObject;
                    CheckPiece();
                }
            }
        }
    }

    public void CheckPiece()
    {
        usePiece = clickedPiece - 1;
        switch (openSlot)
        {    
            case 0:
                if (pieceInSlot[usePiece] == 1 || pieceInSlot[usePiece] == 5)
                {
                    MovePiece();
                }
                break;
            case 1:
                if (pieceInSlot[usePiece] == 0 || pieceInSlot[usePiece] == 2 || pieceInSlot[usePiece] == 4)
                {
                    MovePiece();
                }
                break;
            case 2:
                if (pieceInSlot[usePiece] == 1 || pieceInSlot[usePiece] == 3)
                {
                    MovePiece();
                }
                break;
            case 3:
                if (pieceInSlot[usePiece] == 2 || pieceInSlot[usePiece] == 4 || pieceInSlot[usePiece] == 8)
                {
                    MovePiece();
                }
                break;
            case 4:
                if(pieceInSlot[usePiece] == 1 || pieceInSlot[usePiece] == 3 || pieceInSlot[usePiece] == 5 || pieceInSlot[usePiece] == 7)
                {
                    MovePiece();
                }
                break;
            case 5:
                if(pieceInSlot[usePiece] == 0 || pieceInSlot[usePiece] == 4 || pieceInSlot[usePiece] == 6)
                {
                    MovePiece();
                }
                break;
            case 6:
                if(pieceInSlot[usePiece] == 5 || pieceInSlot[usePiece] == 7)
                {
                    MovePiece();
                }
                break;
            case 7:
                if(pieceInSlot[usePiece] == 4 || pieceInSlot[usePiece] == 6 || pieceInSlot[usePiece] == 8)
                {
                    MovePiece();
                }
                break;
            case 8:
                if(pieceInSlot[usePiece] == 3 || pieceInSlot[usePiece] == 7)
                {
                    MovePiece();
                }
                break;
        }
    }

    public void MovePiece()
    {
        selectedPiece.transform.position = slotPos[openSlot].position;
        int keepSlot = openSlot;
        openSlot = pieceInSlot[usePiece];
        pieceInSlot[usePiece] = keepSlot;
        CheckForRightSpot();
    }

    public void CheckForRightSpot()
    {
        if(pieceInSlot[0] == 1)
        {
            if (!correctPos[0])
            {
                correctPos[0] = true;
                for (int i = 0; i < 8; i++)
                {
                    if (correctPos[i])
                    {
                        SendLightOn(pieces[i]);
                    }
                    else
                    {
                        return;
                    }
                }
            }
        }
        else
        {
            if (correctPos[0])
            {
                correctPos[0] = false;
                for(int i = 0; i < 8; i++)
                {
                    SendLightOff(pieces[i]);
                    if (correctPos[i])
                    {
                        SendLightOff(pieces[i]);
                    }
                }
            }
        }
        if (pieceInSlot[1] == 2)
        {
            if (!correctPos[1])
            {
                correctPos[1] = true;
                if (correctPos[0])
                {
                    for (int i = 1; i < 8; i++)
                    {
                        if (correctPos[i])
                        {
                            SendLightOn(pieces[i]);
                        }
                        else
                        {
                            return;
                        }
                    }
                }       
            }
        }
        else
        {
            if (correctPos[1])
            {
                correctPos[1] = false;
                for (int i = 1; i < 8; i++)
                {
                    SendLightOff(pieces[i]);
                }
            }
        }
        if (pieceInSlot[2] == 3)
        {
            if (!correctPos[2])
            {
                correctPos[2] = true;
                if (correctPos[0] && correctPos[1])
                {
                    for (int i = 2; i < 8; i++)
                {
                    if (correctPos[i])
                    {
                        SendLightOn(pieces[i]);
                    }
                    else
                    {
                        return;
                    }
                }
                }
            }
        }
        else
        {
            if (correctPos[2])
            {
                correctPos[2] = false;
                for (int i = 2; i < 8; i++)
                {
                    SendLightOff(pieces[i]);
                }
            }
        }
        if (pieceInSlot[3] == 4)
        {
            if (!correctPos[3])
            {
                correctPos[3] = true;
                if (correctPos[0] && correctPos[1] && correctPos[2])
                {
                    for (int i = 3; i < 8; i++)
                    {
                        if (correctPos[i])
                        {
                            SendLightOn(pieces[i]);
                        }
                        else
                        {
                            return;
                        }
                    }
                }
            }
        }
        else
        {
            if (correctPos[3])
            {
                correctPos[3] = false;
                for (int i = 3; i < 8; i++)
                {
                    SendLightOff(pieces[i]);
                }
            }
        }
        if (pieceInSlot[4] == 5)
        {
            if (!correctPos[4])
            {
                correctPos[4] = true;
                if (correctPos[0] && correctPos[1] && correctPos[2] && correctPos[3])
                {
                    for (int i = 4; i < 8; i++)
                    {
                        if (correctPos[i])
                        {
                            SendLightOn(pieces[i]);
                        }
                        else
                        {
                            return;
                        }
                    }
                }   
            }
        }
        else
        {
            if (correctPos[4])
            {
                correctPos[4] = false;
                for (int i = 4; i < 8; i++)
                {
                    SendLightOff(pieces[i]);
                }
            }
        }
        if (pieceInSlot[5] == 6)
        {
            if (!correctPos[5])
            {
                correctPos[5] = true;
                if (correctPos[0] && correctPos[1] && correctPos[2] && correctPos[3] && correctPos[4])
                {
                    for (int i = 5; i < 8; i++)
                    {
                        if (correctPos[i])
                        {
                            SendLightOn(pieces[i]);
                        }
                        else
                        {
                            return;
                        }
                    }
                }
            }
        }
        else
        {
            if (correctPos[5])
            {
                correctPos[5] = false;
                for(int i = 5; i < 8; i++)
                {
                    SendLightOff(pieces[i]);
                }
            }
        }
        if (pieceInSlot[6] == 7)
        {
            if (!correctPos[6])
            {
                correctPos[6] = true;
                if (correctPos[0] && correctPos[1] && correctPos[2] && correctPos[3] && correctPos[4] && correctPos[5])
                {
                    for (int i = 6; i < 8; i++)
                    {
                        if (correctPos[i])
                        {
                            SendLightOn(pieces[i]);
                        }
                        else
                        {
                            return;
                        }
                    }
                }
            }
        }
        else
        {
            if (correctPos[6])
            {
                correctPos[6] = false;
                for (int i = 6; i < 8; i++)
                {
                    SendLightOff(pieces[i]);
                }
            }
        }
        if (pieceInSlot[7] == 8)
        {
            if (!correctPos[7])
            {
                correctPos[7] = true;
                if (correctPos[0] && correctPos[1] && correctPos[2] && correctPos[3] && correctPos[4] && correctPos[5] && correctPos[6])
                {
                    for (int i = 7; i < 8; i++)
                    {
                        if (correctPos[i])
                        {
                            SendLightOn(pieces[i]);
                        }
                        else
                        {
                            return;
                        }
                    }
                }
            }
        }
        else
        {
            if (correctPos[7])
            {
                correctPos[7] = false;
                for (int i = 7; i < 8; i++)
                {
                    SendLightOff(pieces[i]);
                }
            }
        }
    }

    public void SendLightOn(GameObject g)
    {
        g.GetComponent<PuzzleEmission>().LightUp();
    }

    public void SendLightOff(GameObject g)
    {
        g.GetComponent<PuzzleEmission>().LightOff();
    }

    IEnumerator CustomUpdateDelay()
    {
        yield return new WaitForSeconds(0.01f);
        CustomUpdate();
    }
}
