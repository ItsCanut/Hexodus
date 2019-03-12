@CustomEditor(Spawn)
@CanEditMultipleObjects

class SpawnEditor extends Editor {
  var Nome : String = "";
  var Strings : String[] = new String[12];

 function OnInspectorGUI() {
  Linguagem();
  target.Tipo = EditorGUILayout.EnumPopup(Strings[10],target.Tipo);
  EditorGUILayout.BeginVertical();
  if(target.Objeto == null | target.Local == null){
   GUI.backgroundColor = Color.red;
  }else{
   GUI.backgroundColor = Color.white;
  }
  EditorGUILayout.EndVertical();
  target.Objeto = EditorGUILayout.ObjectField(Strings[0],target.Objeto,GameObject);
  target.Local = EditorGUILayout.ObjectField(Strings[1],target.Local,Transform);
    GUI.backgroundColor = Color.white;
  target.AplicarTag = EditorGUILayout.Toggle(Strings[2],target.AplicarTag);
    if(target.AplicarTag){
   target.Tags = EditorGUILayout.TagField(Strings[3],target.Tags);
  }
  
  EditorGUILayout.Separator();
  target.Loop = EditorGUILayout.Toggle(Nome,target.Loop);
  if(!target.Loop){
  EditorGUILayout.Separator();
  target.Quantidade = EditorGUILayout.IntField(Strings[5],target.Quantidade);
 }
  GUI.backgroundColor = Color.cyan;
  target.Tempo = EditorGUILayout.Slider(Strings[6],target.Tempo,0,100);

  
  
  if(target.Tipo == target.Tipo.Distancia){
  EditorGUILayout.Space();
  target.Distancia = EditorGUILayout.Slider(Strings[9],target.Distancia,0,100);
  GUI.backgroundColor = Color.white;
  target.AtivaDirecao = EditorGUILayout.Toggle(Strings[7],target.AtivaDirecao);
  if(target.AtivaDirecao){
  target.Direcao = EditorGUILayout.Vector3Field(Strings[8],target.Direcao);
  }
  }else{
  target.RandonMax = EditorGUILayout.Vector2Field("Max",target.RandonMax);
  target.RandonMin = EditorGUILayout.Vector2Field("Min",target.RandonMin);
  }
}
  function Linguagem(){
   		if(Application.systemLanguage == SystemLanguage.Portuguese){
    Strings[0] = "Objeto";
    Strings[1] = "Local";
    Strings[2] = "AplicarTag";
    Strings[3] = "Tag";
    Strings[4] = "Loop";
    Strings[5] = "Quantidade de Spawns";
    Strings[6] = "Tempo";
    Strings[7] = "Ativa Direçoes";
    Strings[8] = "Direçao";
    Strings[9] = "Distancia";
    Strings[10] = "Tipo";
    if(target.Loop){
    Nome = "Loop Ativo";
    }else{
    Nome = "Loop Desativo";
    }
    }
    	if(Application.systemLanguage == SystemLanguage.English){
    Strings[0] = "Object";
    Strings[1] = "Local";
    Strings[2] = "Apply tag";
    Strings[3] = "Tag";
    Strings[4] = "Loop";
    Strings[5] = "Number of Instances";
    Strings[6] = "Time";
    Strings[7] = "Enabled Direction";
    Strings[8] = "Direction";
    Strings[9] = "Distance";
    Strings[10] = "Type";
    if(target.Loop){
    Nome = "Enabled Loop";
    }else{
    Nome = "Disabled Loop";
    }
   }
    	if(Application.systemLanguage == SystemLanguage.Russian){
    Strings[0] = "объект";
    Strings[1] = "местный";
    Strings[2] = "Применить тег";
    Strings[3] = "тег";
    Strings[4] = "петля";
    Strings[5] = "Количество экземпляров";
    Strings[6] = "время";
    Strings[7] = "Активная Направление";
    Strings[8] = "направление";
    Strings[9] = "расстояние";
    Strings[10] = "тип";
    if(target.Loop){
    Nome = "на петле";
    }else{
    Nome = "с петлей";
    }
   }
   		if(Application.systemLanguage == SystemLanguage.Chinese){
    Strings[0] = "物體";
    Strings[1] = "當地";
    Strings[2] = "應用標籤";
    Strings[3] = "標籤";
    Strings[4] = "循環";
    Strings[5] = "實例數";
    Strings[6] = "時間";
    Strings[7] = "活動方向";
    Strings[8] = "方向";
    Strings[9] = "距離";
    Strings[10] = "類型";
    if(target.Loop){
    Nome = "在循環";
    }else{
    Nome = "關閉循環";
    }
   }
    if(Application.systemLanguage != SystemLanguage.Portuguese && Application.systemLanguage != SystemLanguage.Chinese && Application.systemLanguage != SystemLanguage.English && Application.systemLanguage != SystemLanguage.Russian){
      Strings[0] = "Object";
    Strings[1] = "Local";
    Strings[2] = "Apply tag";
    Strings[3] = "Tag";
    Strings[4] = "Loop";
    Strings[5] = "Number of Instances";
    Strings[6] = "Time";
    Strings[7] = "Active Direction";
    Strings[8] = "Direction";
    Strings[9] = "Distance";
    Strings[10] = "Type";
    if(target.Loop){
    Nome = "Enabled Loop";
    }else{
    Nome = "Disable Loop";
    }
    }
  }			
  
  function OnSceneGUI(){
  	if(target.Local){
     Handles.BeginGUI();
   GUILayout.BeginArea(Rect(Screen.width - 90,Screen.height -80,80,50));
 
 	 if(GUILayout.Button("Reset")){
    target.Local.rotation = Quaternion.Euler(0,0,0);
   }
     GUILayout.EndArea();
   Handles.EndGUI();
  	if(target.Tipo == target.Tipo.Distancia){
   Handles.color = Color.cyan;
   Handles.DrawLine(target.Local.position,target.Local.position + target.RDirecao + target.Direcao);
   Handles.color = Color.magenta;
   Handles.ArrowCap(0,target.Local.position + target.RDirecao + target.Direcao,target.Local.rotation,0.5);
   Handles.Label(target.Local.position,"Local Nome : " + target.Local.name);

}else{
  var Vertices : Vector3[] = [
  Vector3(target.Local.position.x + target.RandonMin.x,target.Local.position.y,target.Local.position.z - target.RandonMax.y),
  Vector3(target.Local.position.x + target.RandonMin.x,target.Local.position.y,target.Local.position.z + target.RandonMax.y),
  Vector3(target.Local.position.x + target.RandonMax.x,target.Local.position.y,target.Local.position.z - target.RandonMin.y),
  Vector3(target.Local.position.x + target.RandonMax.x,target.Local.position.y,target.Local.position.z + target.RandonMin.y)];
  Handles.DrawSolidRectangleWithOutline(Vertices,Color32(120,80,50,100),Color.black);


}

}
}
}