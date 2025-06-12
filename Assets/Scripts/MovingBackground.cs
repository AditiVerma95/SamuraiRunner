using System;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.UI;

public class MovingBackground : MonoBehaviour {
    [SerializeField] private CinemachineCamera followCamera;
    public GameObject particleEffect;
    private Material mat;
    [SerializeField] private float speed;
    private float distance = 0f;
    private Vector3 particleOffset;
    
    private void Start() {
        mat = GetComponent<MeshRenderer>().material;
        particleOffset = particleEffect.transform.position - transform.position;
    }

    private void Update() {
        if(followCamera != null) {
            float yOffset = 1f; // adjust based on how high you want it
            transform.position = new Vector3(followCamera.transform.position.x, followCamera.transform.position.y + yOffset, transform.position.z);
        }

        distance += Time.deltaTime * speed;
        Vector2 offset = new Vector2(distance, 0);
        Vector4 st = mat.GetVector("_BaseMap_ST");
        mat.SetVector("_BaseMap_ST", new Vector4(st.x, st.y, offset.x, offset.y));

        particleEffect.transform.position = transform.position + particleOffset;
    }

}

