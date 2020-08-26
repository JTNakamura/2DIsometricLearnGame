using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Floor : MonoBehaviour
{
    [HideInInspector]
    public TilemapRenderer tilemapRenderer;
    public int order{get{return tilemapRenderer.sortingOrder;}}
    public int contentOrder;
    public Vector3Int minXY;
    public Vector3Int maxXY;
    [HideInInspector]
    public Tilemap tilemap;

    void Awake(){
        tilemapRenderer = this.transform.GetComponent<TilemapRenderer>();
        tilemap = GetComponent<Tilemap>();
    }

/*cria uma lista de vetores com base nos tiles que existem nesse flor. Esse flor é um
game object que possui o componente TileMap e Tlerendered. Ele ira veriricar quais tiles desse
tilemap estão preenchidos. Assim que veriricar quais estão preenchidos ele colocará essas informações
em uma lista de vetores tipo a seguinte:
Lista de Vetores chamada tiles:

    (1,1)   (2,1)   (3,1)
    (1,2)   (2,2)   (3,2)
    (1,3)   (2,3)   (3,3)

Isso deixará salvo as posições que possuem tiles para que possam ser uasadas no Boar Logic, que é 
um tabuleiro onde iremos criar a movimentação do personagem.

*/
    public List<Vector3Int> LoadTiles(){
        List<Vector3Int> tiles = new List<Vector3Int>();

        for(int i=minXY.x; i<=maxXY.x; i++){
            
            for(int j=minXY.y; j<=maxXY.y; j++){

                Vector3Int currentPos = new Vector3Int(i, j, 0);

                if(tilemap.HasTile(currentPos)){

                    tiles.Add(currentPos);
                }
            }
        }


        return tiles;
    }
    
}
