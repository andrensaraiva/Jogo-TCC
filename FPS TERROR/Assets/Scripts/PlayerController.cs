using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float velocidade = 5f;
    public float sensibilidadeMouse = 2f;
    public Transform cameraTransform;
    public Transform lanternaTransform;
    public Rigidbody rb;
    public Animator animator;

    private float rotacaoX = 0f;
    private Vector3 movimentoInput;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // Trava o cursor no centro da tela
    }

    void Update()
    {
        // Coletando entrada de movimento
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Calcula direção do movimento
        movimentoInput = transform.right * horizontal + transform.forward * vertical;

        // Atualiza animação com base na velocidade real do Rigidbody
        float velocidadeAtual = new Vector3(rb.linearVelocity.x, 0, rb.linearVelocity.z).magnitude;
        animator.SetFloat("Speed", velocidadeAtual); // Atualiza o Animator

        // Rotação da câmera com o mouse
        float mouseX = Input.GetAxis("Mouse X") * sensibilidadeMouse;
        float mouseY = Input.GetAxis("Mouse Y") * sensibilidadeMouse;

        rotacaoX -= mouseY;
        rotacaoX = Mathf.Clamp(rotacaoX, -90f, 90f); // Limita a rotação vertical

        cameraTransform.localRotation = Quaternion.Euler(rotacaoX, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX); // Rotaciona o corpo do jogador

        // A lanterna segue a câmera
        if (lanternaTransform != null)
        {
            lanternaTransform.rotation = cameraTransform.rotation;
        }
    }

    void FixedUpdate()
    {
        // Aplica força para movimentação
        rb.linearVelocity = new Vector3(movimentoInput.x * velocidade, rb.linearVelocity.y, movimentoInput.z * velocidade);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Game");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ExitZone"))
        {
            Debug.Log("Voce venceu!!!!");
        }
    }
}
