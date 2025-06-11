using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    public float speed = 0.2f;
    public float aimRange = 3;
    public float dashRange = 1f;

    public GameObject crosshair;
    public Camera PlayerCamera;
    private Rigidbody2D playerRb;
    public InputActionAsset InputActions;

    //player controls variables
    private InputAction playerJumpAction;
    private InputAction playerMoveAction;
    private InputAction playerAimAction;
    private InputAction playerDashAction;
    private InputAction playerCastAction;
    private InputAction lightAttackAction;
    private InputAction mediumAttackAction;
    private InputAction heavyAttackAction;

    
    public Vector2 playerAimVector;
    public Vector2 playerMoveVector;
    public GridScript currentGrid;
    public Animator animatorVar;

    public void OnEnable()
    {
        InputActions.FindActionMap("Normal Mode").Enable();
    }

    private void OnDisable()
    {
        InputActions.FindActionMap("Normal Mode").Disable();
    }

    private void Awake()
    {
        playerMoveAction = InputSystem.actions.FindAction("Move");
        playerAimAction = InputSystem.actions.FindAction("Aim");
        playerDashAction = InputSystem.actions.FindAction("Dash");
        playerJumpAction = InputSystem.actions.FindAction("Jump");
        playerCastAction = InputSystem.actions.FindAction("Cast");
        lightAttackAction = InputSystem.actions.FindAction("Light Attack");
        mediumAttackAction = InputSystem.actions.FindAction("Medium Attack");
        heavyAttackAction = InputSystem.actions.FindAction("Heavy Attack");

        crosshair.GetComponent<SpriteRenderer>().enabled = false;
        playerRb = GetComponent<Rigidbody2D>();
    }

    public void EnableTheFuckingControls() {
        Awake();
    }

    // public void OnAim(InputAction.CallbackContext context)
    // {
    //     Vector2 controllerAim = context.ReadValue<Vector2>();
    //     crosshair.transform.position = new Vector3 (
    //         Mathf.Clamp(gameObject.transform.position.x + controllerAim.x, gameObject.transform.position.x - 3, gameObject.transform.position.x + 3),
    //         Mathf.Clamp(gameObject.transform.position.y + controllerAim.y, gameObject.transform.position.y - 3, gameObject.transform.position.y + 3));
    // }

    // public void OnMove(InputAction.CallbackContext context)
    // {
    //     playerRb = GetComponent<Rigidbody2D>();
    //     Debug.Log(context.ReadValue<Vector2>());
    //     // gameObject.transform.position = new Vector2(gameObject.transform.position.x + context.ReadValue<Vector2>().x * 0.25f, gameObject.transform.position.y + context.ReadValue<Vector2>().y * 0.25f );
    //     playerRb.MovePosition(new Vector2(gameObject.transform.position.x + context.ReadValue<Vector2>().x , gameObject.transform.position.y + context.ReadValue<Vector2>().y));
        
    // }

    // public void OnJump(InputAction.CallbackContext context)
    // {
    //     gameObject.transform.position = new Vector2(gameObject.transform.position.x + context.ReadValue<Vector2>().x, gameObject.transform.position.y + context.ReadValue<Vector2>().y);
    // }

    // void Start()
    // {
    //     // Initialize the Rigidbody2D component
    //     playerRb = GetComponent<Rigidbody2D>();
    //     // Prevent the player from rotating
    //     playerRb.constraints = RigidbodyConstraints2D.FreezeRotation;
    // }

    void mouseAim() {
                // Debug.Log(playerDevice.currentControlScheme);
        // // Debug.Log(Camera.main.ScreenToWorldPoint(Input.mousePosition));

        // //gets the raw data for where the mouse cursor is
        // Vector3 mouseCoordinates = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // //calculates the difference in position between the player position and the cursor position
        // Vector3 playerAim = new Vector3(gameObject.transform.position.x - mouseCoordinates.x, gameObject.transform.position.y - mouseCoordinates.y, 0);
        // // Debug.Log(playerAim);

        // //cross hair calculations, keeps the crosshair within a certain boundary by comparing player position and cursor position and clamping based on variable
        // crosshair.transform.position = new Vector3(
        //     Mathf.Clamp(gameObject.transform.position.x + -playerAim.x, gameObject.transform.position.x - 3, gameObject.transform.position.x + 3),
        //     Mathf.Clamp(gameObject.transform.position.y + -playerAim.y, gameObject.transform.position.y - 3, gameObject.transform.position.y + 3),
        //     1);
    }

    public SpriteRenderer playerSprite;
    public GameObject conduit;
    public ManaController manaController;
    void Update()
    {
        RotatePlayer(playerMoveVector.x, playerMoveVector.y);

        gameObject.GetComponent<SpriteRenderer>().sortingOrder = (int)(gameObject.transform.position.z + 1);
        playerSprite.sortingOrder = (int)(gameObject.transform.position.z + 1);
        crosshair.GetComponent<SpriteRenderer>().sortingOrder = (int)(gameObject.transform.position.z + 1);
        conduit.GetComponent<SpriteRenderer>().sortingOrder = (int)(gameObject.transform.position.z + 1);

        InputActions.FindActionMap("Normal Mode").Enable();
        playerMoveVector = playerMoveAction.ReadValue<Vector2>();
        playerAimVector = playerAimAction.ReadValue<Vector2>();

        if (playerDashAction.WasPressedThisFrame())
        { PlayerDashFunc(); }

        if (playerJumpAction.WasPressedThisFrame())
        { PlayerJumpFunc(); }

        if (playerCastAction.WasPressedThisFrame())
        { CastSpell(); }

        if (lightAttackAction.WasPressedThisFrame())
        { PlayerAttackFunc("Light Attack"); }
        else if (mediumAttackAction.WasPressedThisFrame())
        { PlayerAttackFunc("Medium Attack"); }
        else if (heavyAttackAction.WasPressedThisFrame())
        { PlayerAttackFunc("Heavy Attack"); }

        currentGrid.TrackElevation(gameObject);
        currentGrid.TrackTileMap(gameObject);
    }

    // private void CheckCollision() {
    //     Vector2 playerPosition = new Vector2(playerRb.transform.position.x, playerRb.transform.position.y);
    //     List<Collider2D> collisionOverlaps = new List<Collider2D>();

    //     Debug.Log(gameObject.GetComponent<BoxCollider2D>().Overlap(playerPosition, 0, collisionOverlaps));
    //     foreach (var item in collisionOverlaps)
    //     {Debug.Log(item.name + " " + item.GetComponent<TilemapCollisionMonoscript>().elevation);

    //     if (item.isTrigger) {return;}
    //     else if (item.GetComponent<TilemapCollisionMonoscript>().elevation != playerElevation)
    //     {Physics2D.IgnoreCollision(gameObject.GetComponent<CapsuleCollider2D>(), item.gameObject.GetComponent<TilemapCollider2D>(), true);}
    //     else if (item.GetComponent<TilemapCollisionMonoscript>().elevation == playerElevation || item.GetComponent<TilemapCollisionMonoscript>().elevation == playerElevation + 1)//platform is too high or low
    //     {Debug.Log("asdf");
    //         Physics2D.IgnoreCollision(gameObject.GetComponent<CapsuleCollider2D>(), item.gameObject.GetComponent<TilemapCollider2D>(), false);}
    //     }
    // }

    // private void CheckElevation() {
        
    //     Vector2 playerPosition = new Vector2(playerRb.transform.position.x, playerRb.transform.position.y);

    //     List<Collider2D> triggerOverlaps = new List<Collider2D>();
        

        // gameObject.GetComponent<BoxCollider2D>().Overlap(playerPosition, 0, triggerOverlaps); //gets all of the colliders the player overlaps with

        
        // foreach (var item in triggerOverlaps)
        // {Debug.Log(item.name + " " + item.GetComponent<TilemapMonoScript>().elevation);}
            
        // if (triggerOverlaps.Count >= 1)
        // {foreach (var item in triggerOverlaps)
        //     {
        //         if (!item.isTrigger) {return;}
        //         else if (item.GetComponent<TilemapMonoScript>().elevation < playerElevation - 1)
        //             {
        //             //fall damage
        //             playerElevation = item.GetComponent<TilemapMonoScript>().elevation;
        //             gameObject.GetComponent<SpriteRenderer>().sortingOrder = playerElevation + 1;
        //             Debug.Log("Fall DAMAGED");
        //             }
        //         else if (item.GetComponent<TilemapMonoScript>().elevation > playerElevation + 1) //if the highest platform is 1 level higher, hide the player
        //             {
        //             gameObject.GetComponent<SpriteRenderer>().sortingOrder = playerElevation - 1;
        //             }
        //         else if (item.GetComponent<TilemapMonoScript>().elevation == playerElevation + 1)
        //             {
        //             playerElevation = item.GetComponent<TilemapMonoScript>().elevation;
        //             gameObject.GetComponent<SpriteRenderer>().sortingOrder = playerElevation + 1;
        //             Debug.Log("raised");
        //             return;
        //             }
        //         else if (item.GetComponent<TilemapMonoScript>().elevation == playerElevation - 1)
        //             {
        //             // Physics2D.IgnoreCollision(item.GetComponentInChildren<TilemapCollisionMonoscript>().elevation);
        //             playerElevation = item.GetComponent<TilemapMonoScript>().elevation;
        //             gameObject.GetComponent<SpriteRenderer>().sortingOrder = playerElevation + 1;
        //             Debug.Log("lowered");
        //             return;
        //             }
        //         else {return;}
        //     }
        // } else {playerElevation = 0;}

        // if (triggerOverlaps.Count >= 1)
        // {foreach (var item in triggerOverlaps)
        //     {
        //         if (!item.isTrigger) {return;}
        //         else if (item.transform.position.z < gameObject.transform.position.z - 1)
        //             {
        //             //fall damage
        //             gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, item.transform.position.z);
        //             gameObject.GetComponent<SpriteRenderer>().sortingOrder = (int)(gameObject.transform.position.z + 1);
        //             Debug.Log("Fall DAMAGED");
        //             }
        //         else if (item.transform.position.z > gameObject.transform.position.z + 1) //if the highest platform is 1 level higher, hide the player
        //             {
        //             gameObject.GetComponent<SpriteRenderer>().sortingOrder = (int)gameObject.transform.position.z - 1;
        //             }
        //         else if (item.transform.position.z == playerElevation + 1)
        //             {
        //             gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, item.transform.position.z);
        //             gameObject.GetComponent<SpriteRenderer>().sortingOrder = (int)(gameObject.transform.position.z + 1);
        //             Debug.Log("raised");
        //             return;
        //             }
        //         else if (item.transform.position.z > gameObject.transform.position.z - 1)
        //             {
        //             // Physics2D.IgnoreCollision(item.GetComponentInChildren<TilemapCollisionMonoscript>().elevation);
        //             gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, item.transform.position.z);
        //             gameObject.GetComponent<SpriteRenderer>().sortingOrder = (int)(gameObject.transform.position.z + 1);
        //             Debug.Log("lowered");
        //             return;
        //             }
        //         else {return;}
        //     }
        // } else {gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0);}
    // }

    void FixedUpdate()
    {
        PlayerMoveFunc();
        PlayerAimFunc();
    }

    private void PlayerAttackFunc(string attackType) {
        Debug.Log(attackType);
        animatorVar.SetTrigger(attackType);
    }

    private void PlayerMoveFunc() {
        // Debug.Log(playerMoveVector);
        // playerRb.MovePosition(new Vector2(gameObject.transform.position.x + playerMoveVector.x * speed, gameObject.transform.position.y + playerMoveVector.y * speed));
        playerRb.AddForce(new Vector2(playerMoveVector.x * speed, playerMoveVector.y * speed));
    }

    private void PlayerAimFunc() {
        // Debug.Log(playerAimVector);
        crosshair.GetComponent<SpriteRenderer>().enabled = true;

        //code responsible for moving the camera based on player aim
        PlayerCamera.transform.position = new Vector3(
            Mathf.Clamp(PlayerCamera.transform.position.x + playerAimVector.x, PlayerCamera.transform.position.x - 0.05f, PlayerCamera.transform.position.x + 0.05f),
            Mathf.Clamp(PlayerCamera.transform.position.y + playerAimVector.y, PlayerCamera.transform.position.y - 0.05f, PlayerCamera.transform.position.y + 0.05f),
            -2);

        crosshair.transform.position = new Vector2 (
            Mathf.Clamp(gameObject.transform.position.x + playerAimVector.x * aimRange, gameObject.transform.position.x - aimRange, gameObject.transform.position.x + aimRange),
            Mathf.Clamp(gameObject.transform.position.y + playerAimVector.y * aimRange, gameObject.transform.position.y - aimRange, gameObject.transform.position.y + aimRange));
    }

    private void PlayerDashFunc() {
        Debug.Log("DASHED");
        playerRb.MovePosition(new Vector2(gameObject.transform.position.x + playerMoveVector.x * dashRange, gameObject.transform.position.y + playerMoveVector.y * dashRange));
        // playerRb.AddForce(new Vector3(10, 10, 0), ForceMode2D.Impulse);
    }

    IEnumerator ApplyGravity(float waitTime) {
        yield return new WaitForSeconds(waitTime);
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y,gameObject.transform.position.z - 1);
    }
    private void PlayerJumpFunc() {
        Debug.Log("Jumped");
        // playerRb.MovePosition(new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 10));
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z + 1);
        // StartCoroutine(ApplyGravity(1));
    }

    //create an array for different spells and correspond that to the different spells
    public Spells spellList;
    private void CastSpell()
    {
        spellList.Fireball(gameObject, playerAimVector);
        Debug.Log("CAST");
    }

    void RotatePlayer(float x, float y)
    {
        // If there is no input, do not rotate the player
        if (x == 0 && y == 0) return;
        // Calculate the rotation angle based on input direction
        float angle = Mathf.Atan2(-y, -x) * Mathf.Rad2Deg;
        // Apply the rotation to the player
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}