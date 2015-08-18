using UnityEngine;

using System.Collections;

public class playerController : MonoBehaviour
{
	static public int state = 0; 
	private Animator animator;
	
	// Use this for initialization
	void Start()
	{

		state = 0; 

		animator = this.GetComponent<Animator>();

	}
	
	// Update is called once per frame
	void Update()
	{
		playAnimation(state);
//		print(state); 
	}

	void playAnimation(int state)
	{
		if(state ==0){
			animator.SetInteger("State", 0);
			state = 0; 
		}

		else if(state== 1)
		{ 
			//play animation once (for swipe)
			//animator.SetInteger("State", 1);
			animator.SetInteger("State",1);
			playerController.state = 0; 
		}

		else if(state == 2)
		{
			animator.SetInteger("State", 2);
		}

		else if(state == 3)
		{
			animator.SetInteger("State", 3);
		}
	}


}