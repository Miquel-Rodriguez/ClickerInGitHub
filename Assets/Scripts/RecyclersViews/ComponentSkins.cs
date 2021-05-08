using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class ComponentSkins : UI.RecyclerView<ComponentSkins.Holder>.Adapter {


    public List<Skin> SkinsProcesador;
    public List<Skin> SkinsEspacio;
    public List<Skin> SkinsFuenteAlimentacion;
    public List<Skin> SkinsGrafica;

    public GameObject row;

    public List<Skin> RealSkinsList;

    public void Start()
    {
       
        NotifyDatasetChanged();
    }

    public void SetSkinsList(int num)
    {
        if(num == 0)
        {
            RealSkinsList = SkinsProcesador;
        }else if(num == 1)
        {
            RealSkinsList = SkinsEspacio;
        }else if(num == 2)
        {
            RealSkinsList = SkinsFuenteAlimentacion;
        }
        else 
        {
            RealSkinsList = SkinsGrafica;
        }
        NotifyDatasetChanged();


    }

    public override int GetItemCount()
    {
        return RealSkinsList.Count;
    }

    public override void OnBindViewHolder(Holder holder, int i)
    {
        print(RealSkinsList[i].name);
        holder.text.text = RealSkinsList[i].name;
        holder.button.onClick.RemoveAllListeners();
        holder.button.onClick.AddListener(delegate ()
        {
            
        });
    }

    public override GameObject OnCreateViewHolder()
    {
        return Instantiate(row);
    }

    public class Holder : ViewHolder
    {
        public Text text;
        public Button button;
        public Holder(GameObject itemView) : base(itemView)
        {
            text = itemView.transform.Find("Name").GetComponent<Text>();
            button = itemView.transform.Find("Button").GetComponent<Button>();
        }
    }

    private class Item
    {
        public string name;
        public Sprite image;
        public bool available;
    }
}


