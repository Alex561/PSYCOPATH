using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RendererSortingLayer : MonoBehaviour {

    [SerializeField]
    protected string sortingLayer;
	// Use this for initialization
	void Start () {
        Renderer rend = GetComponent<Renderer>();
        rend.sortingLayerName = sortingLayer;
    }
}
