using UnityEngine;
using UnityEngine.UI;

namespace ChuongCustom
{
    public abstract class ButtonPurchase : MonoBehaviour
    {
        [SerializeField, IAPKey] private string productID;
        [SerializeField] private Button buttonClick;
        
        private void Awake()
        {
            Init();
        }

        private void OnEnable()
        {
            Setup();
        }

        protected virtual void Init()
        {
            SetupPurchaseData(IAPDataManager.GetData(productID));
            buttonClick.onClick.AddListener(OnClick);
        }

        protected virtual void OnClick()
        {
            IAPManager.OnPurchaseSuccess = OnPurchaseSuccess;
            IAPManager.Instance.BuyProductID(productID);
        }
        
        protected abstract void Setup();

        protected abstract void SetupPurchaseData(IAPData iapData);

        protected abstract void OnPurchaseSuccess();
    }

    public abstract class ButtonPurchase<T> : ButtonPurchase where T : IAPData
    {
        protected override void SetupPurchaseData(IAPData iapData)
        {
            if (iapData is not T trueData)
            {
                Debug.LogError($"iapkey {iapData.productID} is {iapData.GetType().Name} " +
                               $"not match with {typeof(T).Name} in {name}");
                return;
            }
            SetupPurchaseData(trueData);
        }

        protected abstract void SetupPurchaseData(T iapData);
    }
}