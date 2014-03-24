#pragma strict
var mesh : Mesh;
 var newMesh : Mesh;
var orgColors : Color[];
var vertices : Vector3[];
var newColors : Color[];
var overlayColor : Color;
var changeBack : boolean;
function Start () {
 var oldMesh : Mesh = GetComponent(SkinnedMeshRenderer).sharedMesh;
newMesh = Mesh.Instantiate(oldMesh);
// (Mesh)Object.Instantiate(oldMesh);
  GetComponent(SkinnedMeshRenderer).sharedMesh = newMesh;
// mesh = GetComponent(SkinnedMeshRenderer).sharedMesh;
 vertices = newMesh.vertices;
 orgColors = new Color[vertices.Length];
 newColors = new Color[vertices.Length];
 for (var i = 0; i < vertices.Length;i++){
 	orgColors[i] = oldMesh.colors[i];
 	newColors[i] = orgColors[i] + overlayColor/2;
 }
 newMesh.colors = newColors;
 
 
}

function Update () {
if(changeBack){
newMesh.colors = orgColors;
}
}