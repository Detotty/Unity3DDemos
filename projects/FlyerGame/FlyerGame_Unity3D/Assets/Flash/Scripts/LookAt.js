// example
// LookAt.js

// ADD THE CLASS DEFINITION INSTEAD OF CREATING A BLANK SCRIPT
class LookAt extends UnityEngine.MonoBehaviour
{

  var target:Transform;

  function Update()
  {
    transform.LookAt(target);
    
  }
}
