using UnityEngine;

public class PlayerMoviment : MonoBehaviour {
   private Rigidbody2D body;
   private bool isGrounded;

   [SerializeField]
   private float speed = 5f;

   public Animator animator;



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

   void FixedUpdate() {

   }

   void OnCollisionEnter2D(Collision2D cl) {
      if (cl.collider.tag == "Ground" && isGrounded == false) {
         isGrounded = true;
      };
   }

   void move() {
      rotate();
             body.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, body.velocity.y);
   }
  
   void rotate() {
      if (Input.GetKey(KeyCode.LeftArrow)) {
         body.transform.localRotation = Quaternion.Euler(0, 180, 0);
      } else if (Input.GetKey(KeyCode.RightArrow)) {
         body.transform.localRotation = Quaternion.Euler(0, 0, 0);
      }
   }

}          
