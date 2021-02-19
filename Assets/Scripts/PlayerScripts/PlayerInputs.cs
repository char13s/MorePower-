using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;
public class PlayerInputs : MonoBehaviour
{
    
    private Vector2 displacement;
    private Vector3 direction;
    private static PlayerInputs instance;
    
    private AnimationClip[] move;
    #region anim parmaters
    private bool isGrounded;
    private bool moving;
    private bool lockon;
    #endregion
    #region Component refs
    private Rigidbody rbody;
    [SerializeField]private Animator anim;
    private PlayerStats stats;
    private PlayerItems items;
    #endregion
    #region Outside obj refs
    [SerializeField] private GameObject groundChecker;
    [SerializeField] private GameObject hitBox;
    [SerializeField] private GameObject body;
    #endregion
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForce;
    #region Events
    //public static event UnityAction lockon;
    public static event UnityAction transformation;
    #endregion
    #region Getters and Setters
    
    public bool IsGrounded { get => isGrounded; set { isGrounded = value; Anim.SetBool("Grounded",isGrounded); } }
    public bool Moving { get => moving; set { moving = value; Anim.SetBool("Moving",moving); } }

    public Rigidbody Rbody { get => rbody; set => rbody = value; }
    public Vector3 Direction { get => direction; set => direction = value; }
    public float MoveSpeed { get => moveSpeed; set => moveSpeed = value; }
    public bool Lockon { get => lockon; set => lockon = value; }
    public PlayerStats Stats { get => stats; set => stats = value; }
    public PlayerItems Items { get => items; set => items = value; }
    public Animator Anim { get => anim; set => anim = value; }
    #endregion
    public static PlayerInputs GetPlayer() => instance;
    // Start is called before the first frame update
    private void Awake() {
        if (instance != null && instance != this) {
            Destroy(gameObject);
        }
        else {
            instance = this;
        }
        
        Rbody = GetComponent<Rigidbody>();
        //anim = GetComponentInChildren<Animator>();
        Stats = GetComponent<PlayerStats>();
    }
    void Start() {
        Stats.BaseAttack = 2;
        Stats.Attack = 2;
        Move.run += Run;
    }
    private void Update() {
        MoveAnim();
        Rotate(displacement.x);
        //transform.position += new Vector3(0, 0, direction.z * moveSpeed * Time.deltaTime);
        //print(new Vector3(0, 0, direction.z * moveSpeed * Time.deltaTime));
    }
    #region action mapping
    private void OnJump() {
        if (isGrounded) {
            Anim.SetTrigger("Jump");
            groundChecker.SetActive(false);
            GroundCheckControl(false);
            Rbody.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
            StartCoroutine(WaitForGroundChecker());
        }
    }
    private void OnAttack() {
        Anim.SetTrigger("Attack");
    }
    private void OnMovement(InputValue value) {
        displacement = value.Get<Vector2>();

        if (displacement.magnitude > 0.1f) { 
        Direction = new Vector3(0, 0,displacement.x );
        }
    }
    private void OnTransform() {
        Anim.SetTrigger("Transform");
    }
    private void OnDash(InputValue value) {
        anim.SetTrigger("Dash");
    }
    #endregion

    private IEnumerator WaitForGroundChecker() {
        YieldInstruction wait = new WaitForSeconds(1);
        yield return wait;
        groundChecker.SetActive(true);
    }
    #region Event handlers
    private void GroundCheckControl(bool val) {
        IsGrounded = val;
    }
    private void MoveAnim() {
        if (displacement.magnitude > 0.01f) {
            Moving = true;
        }
        else {
            Moving = false;
        }
        displacement.y = 0;
        
        //transform.position += new Vector3(0, 0, direction.z * moveSpeed) * Time.deltaTime;
    }
    private void Run() {
        Debug.Log("fuck");
        transform.position += new Vector3(0, 0, direction.z * moveSpeed * Time.deltaTime);
    }
    private void Rotate(float x) {
        //Vector3 correntTurn=new Vector3(0,-90,0);
        Vector3 rot = Vector3.Normalize(Direction);
        //rot.y = 0;
        transform.rotation = Quaternion.LookRotation(rot);
    }
     
    #endregion
}
