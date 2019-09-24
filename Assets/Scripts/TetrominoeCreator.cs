using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SHAPE_TYPES
{
    L,
    J,
    I,
    O,
    S,
    T,
    Z
}

public enum BLOCK_STATES
{
    Spawned,
    Settled
}

[ExecuteInEditMode]
public class TetrominoeCreator : MonoBehaviour
{
    public SHAPE_TYPES shapeType;
    public Mesh blockMesh;
    public Material blockMaterial;
    [Range(1.0f, 10.0f)]
    public float blockSpacing = 1.0f;

    private BLOCK_STATES blockState = BLOCK_STATES.Spawned;

    // Editor causes this Awake
    void Awake()
    {
    }

    // Editor causes this Update
    void Update()
    {
        ShapeClear();
        ShapeSetup();
        if(gameObject.GetComponent<Rigidbody>() == null)
        {
            Rigidbody rigidBody = gameObject.AddComponent<Rigidbody>();
            rigidBody.constraints = RigidbodyConstraints.FreezePositionZ;
            rigidBody.constraints |= RigidbodyConstraints.FreezeRotationX;
            rigidBody.constraints |= RigidbodyConstraints.FreezeRotationY;
        }
    }

    void ShapeClear()
    {
        while (transform.childCount != 0)
        {
            DestroyImmediate(transform.GetChild(0).gameObject);
        }
    }

    void ShapeSetup()
    {
        switch (shapeType)
        {
            case SHAPE_TYPES.L:
                for (int i = 0; i < 4; i++)
                {
                    GameObject block = BasicBlockSetup("block_" + i);
                    float x = (i < 3) ? (i * 1) - 1 : 1;
                    float y = (i < 3) ? 0 : 1;
                    block.transform.localPosition = new Vector3(x * blockSpacing, y * blockSpacing);
                }
                break;
            case SHAPE_TYPES.J:
                for (int i = 0; i < 4; i++)
                {
                    GameObject block = BasicBlockSetup("block_" + i);
                    float x = (i > 0) ? ((i - 1) * 1) - 1 : -1;
                    float y = (i > 0) ? 0 : 1;
                    block.transform.localPosition = new Vector3(x * blockSpacing, y * blockSpacing);
                }
                break;
            case SHAPE_TYPES.I:
                for (int i = 0; i < 4; i++)
                {
                    GameObject block = BasicBlockSetup("block_" + i);
                    var x = i - 1.5f;
                    var y = 0.5f;
                    block.transform.localPosition = new Vector3(x * blockSpacing, y * blockSpacing);
                }
                break;
            case SHAPE_TYPES.O:
                for (int i = 0; i < 4; i++)
                {
                    GameObject block = BasicBlockSetup("block_" + i);
                    var x = (i < 2) ? -0.5f: 0.5f;
                    var y = (i % 2 == 0) ? 0.5f : -0.5f;
                    block.transform.localPosition = new Vector3(x * blockSpacing, y * blockSpacing);
                }
                break;
            case SHAPE_TYPES.S:
                for (int i = 0; i < 4; i++)
                {
                    GameObject block = BasicBlockSetup("block_" + i);
                    var x = (i > 0) ? i/3 : -1;
                    var y = i/2;
                    block.transform.localPosition = new Vector3(x * blockSpacing, y * blockSpacing);
                }
                break;
            case SHAPE_TYPES.T:
                for (int i = 0; i < 4; i++)
                {
                    GameObject block = BasicBlockSetup("block_" + i);
                    var x = (i < 3) ? (i*1)-1 : 0;
                    var y = (i < 3) ? 0 : 1;
                    block.transform.localPosition = new Vector3(x * blockSpacing, y * blockSpacing);
                }
                break;
            case SHAPE_TYPES.Z:
                for (int i = 0; i < 4; i++)
                {
                    GameObject block = BasicBlockSetup("block_" + i);
                    var x = (i > 0) ? i / 3 : -1;
                    var y = (i > 1) ? 0 : 1;
                    block.transform.localPosition = new Vector3(x * blockSpacing, y * blockSpacing);
                }
                break;
            default:
                break;
        }
    }

    GameObject BasicBlockSetup(string blockName)
    {
        GameObject block = new GameObject(blockName);
        block.AddComponent<MeshFilter>().mesh = blockMesh;
        block.AddComponent<MeshRenderer>().material = blockMaterial;
        block.AddComponent<MeshCollider>().sharedMesh = blockMesh;
        block.GetComponent<MeshCollider>().convex = true;
        block.transform.SetParent(transform);
        block.transform.rotation = transform.rotation;
        return block;
    }
    
}
