using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Pathfinding : MonoBehaviour {

    Grid GridReference; 
    public Transform StartPosition;
    public Transform TargetPosition; 

    private void Awake()
    {
        GridReference = GameObject.FindObjectOfType<Grid>();
    }

    private void Update()
    {
        FindPath(StartPosition.position, TargetPosition.position); 
    }

    void FindPath(Vector3 a_StartPos, Vector3 a_TargetPos)
    {
        Node StartNode = GridReference.NodeFromWorldPoint(a_StartPos); 
        Node TargetNode = GridReference.NodeFromWorldPoint(a_TargetPos); 

        List<Node> OpenList = new List<Node>();
        HashSet<Node> ClosedList = new HashSet<Node>();

        OpenList.Add(StartNode);

        while(OpenList.Count > 0) // Whilst there is something in the open list
        {
            Node CurrentNode = OpenList[0];
            for(int i = 1; i < OpenList.Count; i++)
            {
                if (OpenList[i].FCost < CurrentNode.FCost || OpenList[i].FCost == CurrentNode.FCost && OpenList[i].ihCost < CurrentNode.ihCost) // If the f cost of that object is less than or equal to the f cost of the current node
                {
                    CurrentNode = OpenList[i];
                }
            }
            
            OpenList.Remove(CurrentNode);
            ClosedList.Add(CurrentNode);

            if (CurrentNode == TargetNode)
            {
                GetFinalPath(StartNode, TargetNode);
                break;
            }

            foreach (Node NeighborNode in GridReference.GetNeighboringNodes(CurrentNode)) 
            {
                if (!NeighborNode.bIsGround || ClosedList.Contains(NeighborNode)) // If the neighbor is a wall or has already been checked
                {
                    continue; // Skip it
                }
               
                int MoveCost = CurrentNode.FCost + GetManhattenDistance(CurrentNode, NeighborNode); // Get the F cost of that neighbor

                if (MoveCost < NeighborNode.igCost || !OpenList.Contains(NeighborNode)) // If the f cost is greater than the g cost or it is not in the open list
                {
                    NeighborNode.igCost = MoveCost; // Set the g cost to the f cost
                    NeighborNode.ihCost = GetManhattenDistance(NeighborNode, TargetNode); // Set the h cost
                    NeighborNode.ParentNode = CurrentNode; // Set the parent of the node for retracing steps

                    if (!OpenList.Contains(NeighborNode)) // If the neighbor is not in the openlist
                    {
                        OpenList.Add(NeighborNode); // Add it to the list
                    }
                }
            }
        }
    }

    // Backtracking and storing the result in a list and then send it to the Grid script.
    void GetFinalPath(Node a_StartingNode, Node a_EndNode)
    {
        List<Node> FinalPath = new List<Node>();
        Node CurrentNode = a_EndNode;

        while (CurrentNode != a_StartingNode)
        {
            FinalPath.Add(CurrentNode);
            CurrentNode = CurrentNode.ParentNode;
        }

        FinalPath.Reverse();

        GridReference.FinalPath = FinalPath;
    }

    // H cost calculation.
    int GetManhattenDistance(Node a_nodeA, Node a_nodeB)
    {
        int ix = Mathf.Abs(a_nodeA.iGridX - a_nodeB.iGridX);
        int iy = Mathf.Abs(a_nodeA.iGridY - a_nodeB.iGridY);

        return ix + iy;
    }
}
