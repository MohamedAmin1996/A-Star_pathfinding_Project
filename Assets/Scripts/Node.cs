using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node {

    public int iGridX; //X Position in the Node Array
    public int iGridY; //Y Position in the Node Array

    public bool bIsGround; // Tells the program if this node is a wall.
    public Vector3 vPosition; // The world position of the node.

    public Node ParentNode; // For the AStar algoritm, will store what node it previously came from so it cn trace the shortest path.

    public int igCost; // The cost of moving to the next square.
    public int ihCost; // The distance to the goal from this node.
    public int FCost { get { return igCost + ihCost; } } // Quick get function to add G cost and H Cost, and since we'll never need to edit FCost, we dont need a set function.

    public Node(bool a_bIsGround, Vector3 a_vPos, int a_igridX, int a_igridY)
    {
        bIsGround = a_bIsGround;
        vPosition = a_vPos;
        iGridX = a_igridX;
        iGridY = a_igridY;
    }
}
