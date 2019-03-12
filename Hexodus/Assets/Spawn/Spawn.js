@script ExecuteInEditMode();
//Translate by Google Translate &:)
@script AddComponentMenu("Spawn/Spawn")
enum tipo{Random,Distancia}


var Objeto : GameObject; //Objeto a ser Spawnado or Object for Spawn
var Local : Transform; //Aqui Sera onde seu Spawn irar Aparecer or Here Is Where Your Objeto will appear
var Tempo : float; // Tempo para cada Spawn or Time for each spawn
var Quantidade : int;// numeros de Objetos spawnados or Numbers of objects to generate
var Loop : boolean; //Ativar a Repetiçao or Enable replay
var Tipo : tipo;
var AplicarTag : boolean;
var Tags : String = "Untagged";
var Layerint : int;

var AtivaDirecao : boolean;
var Direcao : Vector3;
var Distancia : float = 1.0;
var RandonMin : Vector2;
var RandonMax : Vector2;

var Randonico : boolean;
var DistanciaB : boolean;
private var UltimoSpawn : float;
private var RDirecao : Vector3;
private var ResetTempo : float; //Reset only
private var SpawnsObject : int; //Quantos Spawn ja foram or How Spawn already



function Start () {

 SpawnsObject = 0;
 ResetTempo = Tempo; //Aplicando uma Propiedade or Apply property
 UltimoSpawn = Distancia;
}
function Awake () {

}

function Update () {
 
 
 if(Local !=null | Objeto != null){
 if(Tipo == tipo.Distancia){
 DistanciaB = true;
 Randonico = false;
 }else{
 DistanciaB = false;
 Randonico = true;
 }
 if(Tempo > 0){
  if(Loop){
  Tempo -= Time.deltaTime; //Subitraindo o Tempo or Converte Tempo in Time
  }else{
   if(Quantidade > 0){
   Tempo -= Time.deltaTime;
   }
  }
 }
 if(!AtivaDirecao){
 Direcao = Vector3.zero;
 }
 if(Tempo <= 0){
  var SpawnObjeto : GameObject; //Object Null;
  var Dir  = Local.TransformDirection(Direcao);
  RDirecao += Local.forward * Distancia;
  if(Loop){ //Mode Loop
  
   SpawnsObject ++; //adding
   
   if(SpawnsObject > 0){
   if(Tipo == tipo.Distancia){
   SpawnObjeto = Instantiate(Objeto,Local.position + RDirecao + Direcao,Local.rotation); //Instantiate Object
   }else{
   SpawnObjeto = Instantiate(Objeto,Local.position + Vector3(Random.Range(RandonMin.x + (Objeto.transform.localScale.x/1.4),RandonMax.x - (Objeto.transform.localScale.x/1.4)),0,Random.Range(RandonMin.y + (Objeto.transform.localScale.y/1.4),RandonMax.y - (Objeto.transform.localScale.y /1.4))),Local.rotation); //Instantiate Object
   }
   }
   
   SpawnObjeto.name = Objeto.name + "SPW " + SpawnsObject; //Apply Name For Spawn,if you want you can delete
   if(AplicarTag){
    SpawnObjeto.tag = Tags;
   }
  }else{
  if(Quantidade > 0){ //Mode Quantidade
    SpawnsObject ++;//adding
    Quantidade --; 
    
   if(SpawnsObject > 0){
      if(Tipo == tipo.Distancia){
      SpawnObjeto = Instantiate(Objeto,Local.position + RDirecao + Direcao,Local.rotation); //Instantiate Object
      }else{
        SpawnObjeto = Instantiate(Objeto,Local.position + Vector3(Random.Range(RandonMin.x + (Objeto.transform.localScale.x/2),RandonMax.x - (Objeto.transform.localScale.x/2)),0,Random.Range(RandonMin.y + (Objeto.transform.localScale.y/2),RandonMax.y - (Objeto.transform.localScale.y /2))),Local.rotation); //Instantiate Object
      }
   }
   
    SpawnObjeto.name = Objeto.name + "spw " + SpawnsObject;//if you want you can delete
    if(AplicarTag){
    SpawnObjeto.tag = Tags;
   }
   }
  }
  
  Tempo = ResetTempo; //Voltando ao Tempo Normal or Back Tempo in ResetTempo
 }
 
}
}
function OnDrawGizmos () {
   if(Local){
   Gizmos.color = Color32(200,120,0,25);
   if(Tipo == tipo.Distancia){
   Gizmos.DrawCube(Local.position,Local.localScale);
   }
   }
  }