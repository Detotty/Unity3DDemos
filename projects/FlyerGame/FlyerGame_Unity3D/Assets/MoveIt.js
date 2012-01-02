
// ADD THE CLASS DEFINITION INSTEAD OF CREATING A BLANK SCRIPT
class MoveIt extends UnityEngine.MonoBehaviour
{

  function Update()
  {
   	transform.Translate(0, 0, Time.deltaTime);
    
  }
}
