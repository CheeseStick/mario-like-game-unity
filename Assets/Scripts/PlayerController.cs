using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public const float MOVE_AMOUNT = 5.0f;
    public const float JUMP_AMOUNT = 5.0f;

    void Start() {
    }

    void Update() {
        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) {
            this.MoveX(Vector3.left, MOVE_AMOUNT);
        }
        else if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) {
            this.MoveX(Vector3.right, MOVE_AMOUNT);
        }

        if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) {
            if(this.IsOnGround()) {
                this.MoveY(this.transform.up, JUMP_AMOUNT);
            }   
        }
    }
    
    // void OnDrawGizmos() {
    //     Debug.DrawRay(this.gameObject.transform.position, (Vector2.down * this.gameObject.GetComponent<Collider2D>().bounds.size.y / 2), Color.magenta);
    // }

    // MARK: - Position Update
    private void MoveX(Vector3 position, float amount) {
        this.gameObject.transform.position += position * amount * Time.deltaTime;
    }

    private void MoveY(Vector3 direction, float amount) {
        this.gameObject.GetComponent<Rigidbody2D>().AddForce(direction * amount * 100);
    }

    public bool IsOnGround() {
        return (Physics2D.Raycast(this.gameObject.transform.position, Vector2.down, (this.gameObject.GetComponent<Collider2D>().bounds.size.y / 2) + 0.1f).collider != null);
    }
}
