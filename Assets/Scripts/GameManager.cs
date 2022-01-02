using System;
using System.Diagnostics;
using System.IO;
using UnityEngine;
using Utilities;
using Debug = UnityEngine.Debug;

public class GameManager : MonoBehaviour
{
    private bool freshSave = true;

    public readonly int boardWidth = 8;
    public readonly int boardHeight = 8;
    public readonly float camOffSet = 3.5f;
    
    string gameSaveData;
    const string FILE_SAVE = "/current.txt";
    const string FILE_DEFAULT_SAVE = "default";
    private string DATA_PATH;
    private string FILE_SAVE_PATH;
    
    public GameObject squareB;
    public GameObject squareW;

    public GameObject bishopB, kingB, knightB, pawnB, queenB, rookB;
    public GameObject bishopW, kingW, knightW, pawnW, queenW, rookW;

    
    // Start is called before the first frame update
    void Start()
    {
        CheckAndLoadGame();
        BuildBoard();
        AddPieces();
    }

    private void CheckAndLoadGame()
    {
        FILE_SAVE_PATH = Application.persistentDataPath + FILE_SAVE;
        //Debug.Log("Checking File Save Path: " + FILE_SAVE_PATH);
        
        Debug.Log("freshSave = " + freshSave);
        if (freshSave)
        {
            File.Delete(FILE_SAVE_PATH);
            Debug.Log("Save file deleted.");
        }
        
        if (File.Exists(FILE_SAVE_PATH))
        {
            gameSaveData = File.ReadAllText(FILE_SAVE_PATH);
            Debug.Log("File found: Loading..");
            //Debug.Log("File contents: " + gameSaveData);
        }
        else
        {
            Debug.Log("No file found: Creating new save file..");
            var sw = File.Create(FILE_SAVE_PATH);
            sw.Close();

            gameSaveData = Resources.Load(FILE_DEFAULT_SAVE).ToString();
            //Debug.Log("Default save accessed.");
            //Debug.Log("gameSaveData = " + gameSaveData);
            
            File.WriteAllText(FILE_SAVE_PATH, gameSaveData);
            //Debug.Log("gameSaveData written.");
            
            Debug.Log("Save file created.");
            //Debug.Log("File Contents: " + gameSaveData);
        }

    }

    void BuildBoard()
    {
        bool squareIsWhite = false;
        for (int x = 0; x < boardWidth; x++)
        {
            for (int y = 0; y < boardHeight; y++)
            {
                GameObject newSquare;
                if (squareIsWhite)
                {
                    newSquare = Instantiate(squareW);
                }
                else
                {
                    newSquare = Instantiate(squareB);
                }
                
                newSquare.transform.position = new Vector3(x-camOffSet, 0, y-camOffSet);
                squareIsWhite = !squareIsWhite;
                
            }
            squareIsWhite = !squareIsWhite;

        }        
        
    }
    
    private void AddPieces()
    {
        for (int x = 0; x < boardWidth; x++)
        {
            for (int y = 0; y < boardHeight; y++)
            {
                var piece = Instantiate(pawnW);
                piece.transform.localScale = new Vector3(.5f, .5f, .5f);
                piece.transform.position = new Vector3(x - camOffSet, .5f, y - camOffSet);
            }
        }
    }
}
