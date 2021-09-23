using UnityEngine;
using UnityEngine.UI;

public class PlanetUpgradePanel : MonoBehaviour
{
    [SerializeField]
    public Image planetImage = null;
    [SerializeField]
    public Text planetNameText = null;
    [SerializeField]
    public Text priceText = null;
    [SerializeField]
    public Text amountText = null;
    [SerializeField]
    public Sprite[] planetSprite = null;
    [SerializeField]
    private Button purchaseButton = null;
    public static int planetUpgradeLevel = 0;
    public static int planetTouchStar = 0;
    private ImgaeChanger imgaeChanger;
    private Planet planet = null;
    private User user;
    private void Start()
    {
        imgaeChanger = GameObject.Find("Earth").GetComponent<ImgaeChanger>();
    }
    private void Update()
    {
        if (planet.imageNumber == 1)
        {
            imgaeChanger.UpgradeImage();
        }
    }
    public void SetValue(Planet planet)
    {
        this.planet = planet;
        PlanetUpdateUI();
    }
    public void PlanetUpdateUI()
    {
        planetUpgradeLevel = planet.amount;
        switch (planetUpgradeLevel)
        {
            case 5:
                if(planet.imageNumber == 0)
                {
                    planet.imageNumber++;
                    planetImage.sprite = planetSprite[planet.imageNumber];
                    imgaeChanger.UpgradeImage();
                }
                break;
        }
        planetImage.sprite = planetSprite[planet.imageNumber];
        planetNameText.text = planet.name;
        priceText.text = string.Format("{0} STAR", planet.price);
        amountText.text = string.Format("{0}", planet.amount);
    }
    public void OnClickPurchase()
    {
        planetTouchStar = User.touchStar;
        if (GameManager.Instance.CurrentUser.star < planet.price)
        {
            return;
        }
        GameManager.Instance.CurrentUser.star -= planet.price;
        Planet planetInList = GameManager.Instance.CurrentUser.planetList.Find((x) => x.name == planet.name);
        planetInList.amount++;
        planetInList.price = (long)(planetInList.price * 1.25f);
        planetTouchStar += 10;
        PlanetUpdateUI();
        GameManager.Instance.uiManager.UpdateRocketPanel();
    }
}
