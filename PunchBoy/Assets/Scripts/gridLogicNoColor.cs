using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class gridLogicNoColor : MonoBehaviour
{
    [SerializeField] private Grid grid;
    [SerializeField] private Vector3Int gridSize;
    [SerializeField] private Object tilePrefab;
    [SerializeField] private int gridHeight;
    MeshRenderer myRenderer; //= GetComponent<MeshRenderer>();
    //[SerializeField] Material whiteMaterial;// = Resources.Load("white", typeof(Material)) as Material;
    //[SerializeField] Material blackMaterial;// = Resources.Load("white", typeof(Material)) as Material;

    // Start is called before the first frame update
    void Start()
    {
        //var worldPosition = grid.GetCellCenterWorld(new Vector3Int(0, 1));
        //Instantiate(tilePrefab, worldPosition, Quaternion.identity)
        GenerateNoColor();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void GenerateNoColor()
    {
        for (int x = 0; x < gridSize.x; x++)
        {
            for (int z = 0; z < gridSize.z; z++)
            {
                var spawnedTile = Instantiate(tilePrefab, new Vector3(x, gridHeight, z), Quaternion.identity);
                spawnedTile.name = $"Tile{x}{z}";
                spawnedTile.GetInstanceID();

                myRenderer =  spawnedTile.GetComponent<MeshRenderer>();
                
            }
        }
    }
    
}

