using UnityEngine;
using System.Collections;

/// <summary>
/// Classe gérant le déplacement de la caméra
/// </summary>
public class CameraFollow : MonoBehaviour {

    /// <summary>
    /// Lien vers la cible filmée par la caméra (le player)
    /// </summary>
    Player target;

    /// <summary>
    /// Vecteur pour stocker la taille de la box qui est focus par la caméra
    /// </summary>
    public Vector2 focusAreaSize;

	/// <summary>
	/// The distance z.
	/// </summary>
	public float distanceZ;

    /// <summary>
    /// Distance verticale désirée entre la focusArea et le centre de l'écran
    /// </summary>
    public float verticalOffset;

    /// <summary>
    /// Distance horizontale maximale désirée entre la focusArea et le centre de l'écran (dans la direction vers laquelle est tournée le player)
    /// </summary>
    public float lookAheadDstX;

    /// <summary>
    /// Temps désiré pour la translation horizontale de la caméra 
    /// </summary>
    public float lookSmoothTimeX;

    /// <summary>
    /// temps désiré pour la translation verticale de la caméra
    /// </summary>
    public float verticalSmoothTime;

    /// <summary>
    /// Lien vers le Box Collider de la cible
    /// </summary>
    BoxCollider2D targetCollider;

    /// <summary>
    /// Box qui est focus par la caméra
    /// </summary>
    FocusArea focusArea;

    float currentLookAheadX;
    float targetLookAheadX;
    float lookAheadDirX;
    float smoothLookVelocityX;
    float smoothVelocityY;

    Vector3 initPos;

    bool lookAheadStopped;

    bool isPaused;

    /// <summary>
    /// Structure de box qui se déplace lorsqu'elle est poussée par l'objet target et qui est focus par la caméra
    /// </summary>
    struct FocusArea
    {
        /// <summary>
        /// Centre de la focusArea
        /// </summary>
        public Vector2 center;

        /// <summary>
        /// Vecteur de déplacement de la focusArea
        /// </summary>
        public Vector2 velocity;

        /// <summary>
        /// Distance d'un côté de la box par rapport à son centre
        /// </summary>
        float left, right, top, bottom;

        /// <summary>
        /// Crée une focusArea centrée sur la target
        /// </summary>
        /// <param name="targetBounds">contient la position de la target</param>
        /// <param name="size">dimensions de la focusArea</param>
        public FocusArea(Bounds targetBounds, Vector2 size)
        {
            left = targetBounds.center.x - size.x / 2;
            right = targetBounds.center.x + size.x / 2;
            bottom = targetBounds.min.y;
            top = targetBounds.min.y + size.y;

            velocity = Vector2.zero;
            center = new Vector2((left + right) / 2, (top + bottom) / 2);
        }

        /// <summary>
        /// Déplace la focusArea si elle est "poussée" par la target
        /// </summary>
        /// <param name="targetBounds">contient la position de la target</param>
        public void Update(Bounds targetBounds)
        {
            float shiftX = 0;
            float shiftY = 0;

            if (targetBounds.min.x < left)
            {
                shiftX = targetBounds.min.x - left;
            }
            else if (targetBounds.max.x > right)
            {
                shiftX = targetBounds.max.x - right;
            }
            left += shiftX;
            right += shiftX;

            if (targetBounds.min.y < bottom)
            {
                shiftY = targetBounds.min.y - bottom;
            }
            else if (targetBounds.max.y > top)
            {
                shiftY = targetBounds.max.y - top;
            }
            bottom += shiftY;
            top += shiftY;

            center = new Vector2((left + right) / 2, (top + bottom) / 2);
            velocity = new Vector2(shiftX, shiftY);
        }
    }

    /// <summary>
    /// Initialise <see cref="targetCollider"/> et <see cref="focusArea"/>
    /// </summary>
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        targetCollider = target.GetComponent<BoxCollider2D>();
        focusArea = new FocusArea(targetCollider.bounds, focusAreaSize);
        initPos = transform.position;
        isPaused = false;
    }

    /// <summary>
    /// Déplace la caméra en fonction de la position de la focusArea
    /// </summary>
    void LateUpdate()
    {
                focusArea.Update(targetCollider.bounds);
                Vector2 focusPosition = focusArea.center + Vector2.up * verticalOffset;

                if (focusArea.velocity.x != 0)
                {
                    lookAheadDirX = Mathf.Sign(focusArea.velocity.x);
                    if (Mathf.Sign(Input.GetAxis("Horizontal")) == Mathf.Sign(focusArea.velocity.x) && Input.GetAxis("Horizontal") != 0)
                    {
                        lookAheadStopped = false;
                        targetLookAheadX = lookAheadDirX * lookAheadDstX;
                    }
                    else
                    {
                        if (!lookAheadStopped)
                        {
                            lookAheadStopped = true;
                            targetLookAheadX = currentLookAheadX + (lookAheadDirX * lookAheadDstX - currentLookAheadX) / 4f;
                        }
                    }
                }

                currentLookAheadX = Mathf.SmoothDamp(currentLookAheadX, targetLookAheadX, ref smoothLookVelocityX, lookSmoothTimeX);

                focusPosition.y = Mathf.SmoothDamp(transform.position.y, focusPosition.y, ref smoothVelocityY, verticalSmoothTime);
                focusPosition += Vector2.right * currentLookAheadX;

                transform.position = (Vector3)focusPosition + Vector3.forward * distanceZ;
            }


    /// <summary>
    /// Fait appraître la focusArea en tant que Gizmo
    /// </summary>
    void OnDrawGizmos()
    {
        Gizmos.color = new Color(1, 0, 0, .2f);
        Gizmos.DrawCube(focusArea.center, focusAreaSize);
    }

    /// <summary>
    /// Fonction qui reset la caméra
    /// </summary>
    public void Reset()
    {
        transform.position = initPos;
        smoothLookVelocityX = 0;
        smoothVelocityY = 0;
    }

    /// <summary>
    /// Setteur de isPaused
    /// </summary>
    /// <param name="val">valeur à mettre dans isPaused</param>
    public void SetIsPaused(bool val)
    {
        isPaused = val;
    }
}
