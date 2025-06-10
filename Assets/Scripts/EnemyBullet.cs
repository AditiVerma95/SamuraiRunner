using System;
using UnityEngine;

public class EnemyBullet : MonoBehaviour {
    
    private GameObject player;
    private Rigidbody2D rb;
    public float force = 2f;
    private float timer;
    void Start() {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player");
        Vector3 direction = player.transform.position - transform.position;
        rb.linearVelocity = new Vector2(direction.x, direction.y).normalized * force;
        float rot = Mathf.Atan2(-direction.x, -direction.y) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot);
    }

    // Update is called once per frame
    void Update() {
        timer += Time.deltaTime;
        if (timer > 10) {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player")) {
            Debug.Log("player collided");
            GameMechanics.Instance.gameOverUI.SetActive(true);
            Destroy(other.gameObject);
            Destroy(gameObject);
            
            
        }
    }
}
