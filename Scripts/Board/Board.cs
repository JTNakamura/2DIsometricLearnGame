using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Board : MonoBehaviour
{
    public Dictionary<Vector3Int, TileLogic> tiles;
    public List<Floor> floors;
    public static Board instance;
    [HideInInspector]
    public Grid grid;

    void Awake(){
        tiles = new Dictionary<Vector3Int, TileLogic>();
        instance = this;
        grid = GetComponent<Grid>();
    }

    void Start(){
        InitSequence();

        /*Primeiramente um metodo que inicia tudo é chamado*/
       
    }
    public void InitSequence(){
        LoadFloors();
        /*LoadFloor é chamado apra veriricar quantos Floors existem
        e para cada Floor executar um LoadTiles para pegar
        as posições de cada um, e com base nessa posição 
        criar um TileLogics e adicionálos dentro de um Dicionario, onde
        a chave é a posição e o valor é um TileLogic, TileLogic esse que carrega 
        muitos outros valores dentro dele
        
        No fim, esse dicionario sera carregado com as chaves tendo
        o mesmo valor dos vatores criados na primira lista em loadTiles, e os valores
        os TileLogics correspondentes a essas posição.*/
    }
    

    void LoadFloors(){

        for(int i=0; i<floors.Count; i++){
            List<Vector3Int> floorTiles = floors[i].LoadTiles();
            //carrega todos os valores de vetores
            
            for(int j=0; j<floorTiles.Count; j++){
                if(!tiles.ContainsKey(floorTiles[j])){
                    //verifrica se o tile ja existe ou nao, se nao existe ele chama um createTiles para cada um
            
                    CreateTile(floorTiles[j], floors[i]);
                }
            }
        }
    }

    void CreateTile(Vector3Int pos, Floor floor){

        Vector3 worldPos = grid.CellToWorld(pos);//Verifica qual a posicao no mundo do pos
        worldPos.y+= (floor.tilemap.tileAnchor.y/2)-0.5f;//compensa a altura
        TileLogic tileLogic = new TileLogic(pos, worldPos, floor);//cria o tilelogic
        tiles.Add(pos, tileLogic);//adiciona o tile logic no dicionario
    }


}
