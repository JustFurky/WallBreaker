using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace WB.Base.Core.Components.Wall.WallComponent
{
    public class WallComponent : MonoBehaviour, IWall
    {
        #region Properties
        public int Heal { get; private set; }
        public int Level { get; private set; }
        public int Experience { get; private set; }
        #endregion

        #region Serialized Values
        [Header("Data Object")]
        [SerializeField] private WallData wallData;
        [Header("UI Objects")]
        [SerializeField] private TMP_Text _levelText;
        [SerializeField] private TMP_Text _healText;
        [SerializeField] private Image _healBar;
        #endregion

        #region Components
        private MeshRenderer _wallRenderer;
        #endregion

        private void OnEnable()
        {
            GetComponents();
            Initialize();
        }
        public WallData GetWallData()
        {
            return wallData;
        }
        public void Initialize()
        {
            Heal = wallData.Heal;
            Level = wallData.Level;
            Experience = wallData.Experiance;
            _wallRenderer.material.mainTexture = wallData.Texture;
            _healBar.fillAmount = 1;
            SetUI();
        }
        public void SetUI()
        {
            _healText.text = Heal.ToString();
            _levelText.text = "Level " + Level.ToString();
        }
        public bool TakeDamage(int damage)
        {
            Heal -= damage;
            SetUI();
            if (Heal <= 0)
            {
                gameObject.SetActive(false);
                return true;
            }
            else
            {
                _healBar.fillAmount = (float)Heal / wallData.Heal;
                return false;
            }
        }

        private void GetComponents()
        {
            _wallRenderer = GetComponentInChildren<MeshRenderer>();
        }
    }
}
