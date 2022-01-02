using UnityEngine;
using Utilities;


public class Piece
{
    private Color color;
    private PieceType pieceType;
    GameObject parent;
    
    
    public Piece(Color color, PieceType pieceType, GameObject parent)
    {
        this.color = color;
        this.pieceType = pieceType;
        this.parent = parent;
    }

    public string getColorString()
    {
        if (color == Color.white)
        {
            return "white";
        }
        return "black";
    }
    
}
