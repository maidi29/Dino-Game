#pragma strict
var goDown = true;
var goUp = false;
var speed = 0.02;
public var minPosition = 0.6;
public var maxPosition = 1.2;


function Update () 
{
	if (goDown==true)
	{
		transform.position.y -=0.1 * Time.deltaTime + speed;
		if(transform.position.y < minPosition)
			{
				goDown = false;
				goUp = true;
			}
	}
	if (goUp==true)
	{
		transform.position.y +=0.1 * Time.deltaTime + speed;
		if(transform.position.y > maxPosition)
			{
				goDown = true;
				goUp = false;
			}
	}
}