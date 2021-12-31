using UnityEngine;

public class GameManager : MonoBehaviour
{

    public readonly int boardWidth = 8;
    public readonly int boardHeight = 8;
    public readonly float camOffSet = 3.5f;

    public GameObject squareB;
    public GameObject squareW;

    public GameObject bishopB, kingB, knightB, pawnB, queenB, rookB;
    public GameObject bishopW, kingW, knightW, pawnW, queenW, rookW;

    
    // Start is called before the first frame update
    void Start()
    {
        BuildBoard();
    }

    void BuildBoard()
    {
        bool isSquareW = false;
        for (int x = 0; x < boardWidth; x++)
        {
            for (int y = 0; y < boardHeight; y++)
            {
                GameObject newSquare;
                if (isSquareW)
                {
                    newSquare = Instantiate(squareW);
                }
                else
                {
                    newSquare = Instantiate(squareB);
                }
                
                newSquare.transform.position = new Vector3(x-camOffSet, 0, y-camOffSet);
                isSquareW = !isSquareW;
                
            }
            isSquareW = !isSquareW;

        }        
        
    }
}
