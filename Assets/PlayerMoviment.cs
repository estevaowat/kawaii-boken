using UnityEngine;

public class PlayerMoviment : MonoBehaviour {
   private Rigidbody2D body;
   private bool isGrounded;
   public Animator animator;
   [SerializeField] private float speed = 5f;


   void Awake() {
      body = GetComponent<Rigidbody2D>();
   }

   void Update() {
      animator.SetBool("isGrounded", isGrounded);

      move();

      if (isGrounded && Input.GetKey(KeyCode.Space)) {
         body.velocity = new Vector2(body.velocity.x, 7);
         isGrounded = false;
      }
   }

   void OnCollisionEnter2D(Collision2D cl) {
      if (cl.collider.tag == "Ground" && isGrounded == false) {
         isGrounded = true;
      };
   }

   void move() {
      if (Input.GetKey(KeyCode.LeftArrow)) {
         body.transform.localRotation = Quaternion.Euler(0, 180, 0);
      } else if (Input.GetKey(KeyCode.RightArrow)) {
         body.transform.localRotation = Quaternion.Euler(0, 0, 0);
      }

      body.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, body.velocity.y);
   }

}