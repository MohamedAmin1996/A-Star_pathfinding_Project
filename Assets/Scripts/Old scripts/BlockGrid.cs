using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockGrid : MonoBehaviour
{
    Grid blockGrid;
    [SerializeField] [Range(0, 29)] int xPos;
    [SerializeField] [Range(0, 29)] int yPos;
    
    [SerializeField] [Range(16, 29)] int xSize;
    [SerializeField] [Range(16, 29)] int ySize;

    private void Start()
    {
        blockGrid = GameObject.FindObjectOfType<Grid>();
    }

    private void Update()
    {
        if (blockGrid.NodeArray != null)
        {
            transform.position = blockGrid.NodeArray[xPos, yPos].vPosition;

            int x = (int)blockGrid.NodeArray[xSize, ySize].vPosition.x;
            int y = 2;
            int z = (int)blockGrid.NodeArray[xSize, ySize].vPosition.z;
            
            transform.localScale = new Vector3(x, y, z);
        }
    }
}
