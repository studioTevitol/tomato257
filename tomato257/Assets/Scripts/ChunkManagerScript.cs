using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkManagerScript : MonoBehaviour{
    public GameObject chunkType1;
    public GameObject Ball;
    public float offsetY=-50.0f;
    public float offsetZ=95.0f;
    private int chunkCount=0;
    public float offsetDespawn=50.0f;
    public int initialCount=5;
    private Queue<GameObject> chunkQueue = new Queue<GameObject>();

    void Start(){
        for(int i=0;i<initialCount;i++){
            SpawnObject();
        }
    }
    
    void Update(){
        if(CheckCondition()){
            if (chunkQueue.Count > 0){
                GameObject dequeuedChunk = chunkQueue.Dequeue();
                Destroy(dequeuedChunk);
                SpawnObject();
            }
        }
    }

    bool CheckCondition(){
        float a=offsetDespawn+offsetZ*(chunkCount-initialCount);
        return a<Ball.transform.position.z;
    }

    void SpawnObject(){
        float chunkX=0;
        float chunkY=chunkCount*offsetY;
        float chunkZ=chunkCount*offsetZ;
        Vector3 chunkPos=new Vector3(chunkX,chunkY,chunkZ);
        Quaternion chunkRot = Quaternion.Euler(0,0,0);

        GameObject newChunk = Instantiate(chunkType1, chunkPos, chunkRot);
        chunkQueue.Enqueue(newChunk);
        chunkCount++;
    }
}
