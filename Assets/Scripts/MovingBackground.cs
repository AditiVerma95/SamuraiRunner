using System;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.UI;

public class MovingBackground : MonoBehaviour {
    [SerializeField] private CinemachineCamera followCamera;
    
    private Material mat;
    [SerializeField] private float speed;
    private float distance = 0f;
    
    private void Start() {
        mat = GetComponent<MeshRenderer>().material;
    }

    private void Update() {
        if(followCamera != null)
            transform.position = new Vector3(followCamera.transform.position.x, transform.position.y, transform.position.z);
        distance += Time.deltaTime * speed;
        Vector2 offset = new Vector2(distance, 0);
        Vector4 st = mat.GetVector("_BaseMap_ST");
        mat.SetVector("_BaseMap_ST", new Vector4(st.x, st.y, offset.x, offset.y));
    }
}

