using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public string [] sceneName;
	public bool pressed = false;
	public void Update(){
		if(Input.GetKey(KeyCode.Escape)){
			Exit();
        }
	}
	IEnumerator BeginChange(string name)
	{
			yield return new WaitForSeconds(2f);
			ChangeScene(name);
	}
	public void ChangeScene(string sn)
	{
		SceneManager.LoadScene(sn);
		pressed = false;
	}
	public void Exit()
	{
		Application.Quit();
	}
}