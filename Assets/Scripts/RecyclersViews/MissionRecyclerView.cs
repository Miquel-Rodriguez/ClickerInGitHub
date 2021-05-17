using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MissionRecyclerView : UI.RecyclerView<MissionRecyclerView.Holder>.Adapter
{
    public List<Mission> missions;
    // Start is called before the first frame update
    void Start()
    {
        NotifyDatasetChanged();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    

    public override int GetItemCount()
    {
        return missions.Count;
    }

    public override void OnBindViewHolder(Holder holder, int i)
    {
        holder.nameText.text = missions[i].missionName;
        holder.descText.text = missions[i].missionDescription;
        holder.bitsText.text = BitUtil.StringFormat(missions[i].requiredBits, BitUtil.TextFormat.Long);
    }

    
    public override GameObject OnCreateViewHolder()
    {
        return Instantiate(row);
    }

    public class Holder : ViewHolder
    {
        public TextMeshProUGUI nameText;
        public TextMeshProUGUI descText;
        public TextMeshProUGUI bitsText;
        public TextMeshProUGUI rewardText;
        public Holder(GameObject itemView) : base(itemView)
        {
            nameText = itemView.transform.Find("Name").GetComponent<TextMeshProUGUI>();
            descText = itemView.transform.Find("Description").GetComponent<TextMeshProUGUI>();
            bitsText = itemView.transform.Find("BitsRequired").GetComponent<TextMeshProUGUI>();
        }
    }
}
