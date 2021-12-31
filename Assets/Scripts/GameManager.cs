using UnityEngine;

public class GameManager : MonoBehaviour
{

    public readonly int boardWidth = 8;
    public readonly int boardHeight = 8;
    public readonly float camOffSet = 3.5f;

    public GameObject blackSquare;
    public GameObject whiteSquare;
    
    // Start is called before the first frame update
    void Start()
    {
        BuildBoard();
    }

    void BuildBoard()
    {
        bool isWhiteBlock = false;
        for (int x = 0; x < boardWidth; x++)
        {
            for (int y = 0; y < boardHeight; y++)
            {
                GameObject newSquare;
                if (isWhiteBlock)
                {
                    newSquare = Instantiate(whiteSquare);
                }
                else
                {
                    newSquare = Instantiate(blackSquare);
                }
                
                newSquare.transform.position = new Vector3(x-camOffSet, 0, y-camOffSet);
                isWhiteBlock = !isWhiteBlock;
                
            }
            isWhiteBlock = !isWhiteBlock;

        }        
        
    }
}
