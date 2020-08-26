using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileLogic
{

    public Vector3Int pos;
    public Vector3 worldPos;
    public GameObject content;
    public Floor floor;
    public int contentOrder;
   


    public TileLogic(){}


    //metodo construtor de TileLogic
    public TileLogic(Vector3Int cellPos, Vector3 worldPosition, Floor tempFloor){
        pos = cellPos;//posicao
        worldPos = worldPosition; //posicao no mundo
        floor = tempFloor; //reotrnar a classe floor
        contentOrder = tempFloor.contentOrder; //pega o valor do contet order da classe Floor
    }

    // por questoes de aprendizado, um metodo estatico que pode cer acessado de qualquer lugar
    public static TileLogic Create(Vector3Int cellPos, Vector3 worldPosition, Floor tempFloor){
        TileLogic tileLogic = new TileLogic(cellPos, worldPosition, tempFloor);
        return tileLogic;
    }

}
