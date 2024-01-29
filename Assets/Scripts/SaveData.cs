using System.Collections.Generic;
using SupanthaPaul;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    public float speed;
    public float jumpForce;
    public float fallMultiplier;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    public int extraJumpCount = 1;
    public GameObject jumpEffect;
    public float dashSpeed = 30f;
    public float startDashTime = 0.1f;
    public float dashCooldown = 0.2f;
    public GameObject dashEffect;
    public Vector3 position;
    public bool positionIsValid = false;

    public string currentLevelName = "Dialogue01";
    public List<string> openedLevels = new List<string>();
    public List<string> collectedItems = new List<string>();
    // public void WritePlayerController(PlayerController controller)
    // {
    //     this.speed = controller.speed;
    // 		this.jumpForce = controller.jumpForce;
    // 		this.fallMultiplier = controller.fallMultiplier;
    // 		this.groundCheck = controller.groundCheck; // Assuming groundCheck is a Transform
    // 		this.groundCheckRadius = controller.groundCheckRadius;
    // 		this.whatIsGround = controller.whatIsGround; // Assuming whatIsGround is a LayerMask
    // 		this.extraJumpCount = controller.extraJumpCount;
    // 		this.jumpEffect = controller.jumpEffect; // Assuming jumpEffect is a GameObject
    // 		this.dashSpeed = controller.dashSpeed;
    // 		this.startDashTime = controller.startDashTime;
    // 		this.dashCooldown = controller.dashCooldown;
    // 		this.dashEffect = controller.dashEffect; // Assuming dashEffect is a GameObject
    // 		this.position = controller.position;
    // 		transform.position = position;
    // }
}