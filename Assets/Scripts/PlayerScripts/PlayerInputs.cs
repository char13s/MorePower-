using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputs : MonoBehaviour {
    private Rigidbody2D rbody;
    private float displacement;
    private AnimationClip[] move;
    #region anim parmaters
    private bool isGrounded;
    #endregion

    #region Outside obj refs
    [SerializeField] private GameObject groundChecker;
    [SerializeField] private GameObject hitBox;
    #endregion
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForce;
    // Start is called before the first frame update
    void Start() {
        rbody = GetComponent<Rigidbody2D>();
        GroundCheck.grounded += GroundCheckControl;
    }

    // Update is called once per frame
    void Update() {
        GetInput();
    }
    private void GetInput() {
        if (isGrounded) {
            Movement();
        }
        Attack();
        Jump();
    }
    private void Movement() {
        float x = Input.GetAxis("Horizontal");

        displacement = x;
        Displace();

    }
    private void Displace() {
        rbody.velocity = new Vector2(displacement * moveSpeed, 0);
    }
    private void Jump() {
        if (Input.GetKeyDown(KeyCode.W)) {
            GroundCheckControl(false);
            rbody.velocity = new Vector2(0, jumpForce);
            StartCoroutine(WaitForGroundChecker());
        }
    }
    private void Attack() {
        if (Input.GetButtonDown("Fire1")){
            hitBox.SetActive(true);
            StartCoroutine(WaitToDisableHitBox());
        }

    }
    private IEnumerator WaitForGroundChecker() {
        YieldInstruction wait = new WaitForSeconds(1);
        yield return wait;
        groundChecker.SetActive(true);
    }
    private IEnumerator WaitToDisableHitBox() {
        yield return null;
        yield return null;
        yield return null;
        yield return null;
        hitBox.SetActive(false);
    }
    #region Evnet handlers
    private void GroundCheckControl(bool val) {
        isGrounded = val;
    }
    #endregion
}
