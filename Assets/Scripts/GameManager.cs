using UnityEngine;




public class GameManager : MonoBehaviour
{

    public GameObject blackSquare;
    public GameObject whiteSquare;

    
    // Start is called before the first frame update
    void Start()
    {
        BuildBoard();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void BuildBoard()
    {
        bool isWhiteBlock = false;
        for (int x = 0; x < 8; x++)
        {
            for (int y = 0; y < 8; y++)
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
                
                newSquare.transform.position = new Vector3(x-3.5f, 0, y-3.5f);

                isWhiteBlock = !isWhiteBlock;

            }
            isWhiteBlock = !isWhiteBlock;

        }        
        
        

    }
}
