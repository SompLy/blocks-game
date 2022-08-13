using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGeneration : MonoBehaviour
{
    [SerializeField] Renderer redr;

    [SerializeField] GameObject Block;
    [SerializeField] int chunksTotalDiameter;
    [SerializeField] float chunk_h;
    [SerializeField] float chunk_w;

    GameObject[] chunks = new GameObject[] { };
    void Start()
    {
        ChunkGenerator();
    }

    private void OnBecameInvisible()
    {
        redr.enabled = false;
    }
    private void OnBecameVisible()
    {
        redr.enabled = true;
    }

    void ChunkGenerator()
    {
            for (int p = 0; p < chunk_h; p++)           //höjd
            {
                for (int i = 0; i < chunk_w; i++)       //bredd
                {
                    for (int o = 0; o < chunk_w; o++)   //längd
                    {
                        Instantiate(Block, new Vector3(i - Mathf.Round(chunk_w / 2), -p, o - Mathf.Round(chunk_w / 2)), Quaternion.identity);
                    }
                }
            }
        Debug.Log("chunk generated");
    }
}
