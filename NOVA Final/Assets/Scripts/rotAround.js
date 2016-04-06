#pragma strict

var speed = 10.0f;
var target : Transform;

function FixedUpdate () {

//http://answers.unity3d.com/questions/53352/rigidbody-version-of-rotatearound.html

     var horizontal = Input.GetAxis("Horizontal");
     var vertical = Input.GetAxis("Vertical");
     var direction = (target.position - GetComponent.<Rigidbody>().position).normalized;
     var rotation = Quaternion.AngleAxis(horizontal * 60, Vector3.up) * direction * Mathf.Abs(horizontal);
     var desired = rotation + vertical * direction;
     var change = desired * speed - GetComponent.<Rigidbody>().velocity;
     // Debug lines: Red - current heading
     //              Blue - applied heading
     Debug.DrawLine(GetComponent.<Rigidbody>().position, GetComponent.<Rigidbody>().position + GetComponent.<Rigidbody>().velocity, Color.red);
     Debug.DrawLine(GetComponent.<Rigidbody>().position, GetComponent.<Rigidbody>().position + change, Color.blue);
     GetComponent.<Rigidbody>().AddForce(change * Time.deltaTime, ForceMode.VelocityChange);


}
