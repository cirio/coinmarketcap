using System.Runtime.Serialization;

[DataContract]
   public class TickerSpecificCurrency
    {
        
        #region Property
        public System.DateTime DateRead { get; set; }

        [DataMember(Name = "id")]
        public string id { get; set; }

        [DataMember(Name = "name")]
        public string name { get; set; }

        [DataMember(Name = "symbol")]
        public string symbol { get; set; }
        
        [DataMember(Name = "rank")]
        public string rank { get; set; }
        
        [DataMember(Name = "price_usd")]
        public string price_usd { get; set; }
        
        [DataMember(Name = "price_btc")]
        public string price_btc { get; set; }

        [DataMember(Name = "24h_volume_usd")]
        public string volume_usd_24h { get; set; }
        
        [DataMember(Name = "market_cap_usd")]
        public string market_cap_usd { get; set; }
        
        [DataMember(Name = "available_supply")]
        public string available_supply { get; set; }
        
        [DataMember(Name = "total_supply")]
        public string total_supply { get; set; }
        
        [DataMember(Name = "max_supply")]
        public string max_supply { get; set; }
        
        [DataMember(Name = "percent_change_1h")]
        public string percent_change_1h { get; set; }
        
        [DataMember(Name = "percent_change_24h")]
        public string percent_change_24h { get; set; }
        
        [DataMember(Name = "percent_change_7d")]
        public string percent_change_7d { get; set; }
        
        [DataMember(Name = "last_updated")]
        public string last_updated { get; set; }
        
        [DataMember(Name = "price_eur")]
        public string price_eur { get; set; }
        
        [DataMember(Name = "24h_volume_eur")]
        public string volume_eur_24h { get; set; }
        
        [DataMember(Name = "market_cap_eur")]
        public string market_cap_eur { get; set; }
        #endregion

        
    }