using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeUniform : MonoBehaviour {

    public Renderer mat;
    public Texture2D texture;

	void Start () {
		
	}
	
    public void onClick()
    {
        mat.material.SetTexture("hat", texture);
    }
}
