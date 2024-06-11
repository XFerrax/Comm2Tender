namespace Comm2Tender.Logic.Models.Dto
{
    public class Proposal
    {
        public int ProposalId { get; set; } // int
        public Agent Agent { get; set; } // int
        public User User { get; set; } // int
        public Tender Tender { get; set; } // int
        
        /// <summary>
        /// Количество товара(услуг), ед
        /// </summary>
        public int CountPos { get; set; } // int
        
        /// <summary>
        /// Стоимость 1 ед товара(услуги)
        /// </summary>
        public decimal PositionPrice { get; set; } // decimal(8, 3)
        
        /// <summary>
        /// Стоимость доставки, руб.
        /// </summary>
        public decimal DeliveryCost { get; set; } // decimal(8, 3)
        
        /// <summary>
        /// Сроки поставки, дн
        /// </summary>
        public int DeliveryTime { get; set; } // int
        
        /// <summary>
        /// Аванс 1
        /// </summary>
        public decimal PrepaidExpense1 { get; set; } // decimal(8, 3)
        
        /// <summary>
        /// Аванс 2
        /// </summary>
        public decimal PrepaidExpense2 { get; set; } // decimal(8, 3)
        
        /// <summary>
        /// Аванс 3
        /// </summary>
        public decimal PrepaidExpense3 { get; set; } // decimal(8, 3)
        
        /// <summary>
        /// Срок аванса 1, дн
        /// </summary>
        public int PeriodOfExecution1 { get; set; } // int
        
        /// <summary>
        /// Срок аванса 2, дн
        /// </summary>
        public int PeriodOfExecution2 { get; set; } // int
        
        /// <summary>
        /// Срок аванса 3, дн
        /// </summary>
        public int PeriodOfExecution3 { get; set; } // int
        
        /// <summary>
        /// Постоплата 1, %
        /// </summary>
        public decimal PostPaymant1 { get; set; } // decimal(8, 3)
        
        /// <summary>
        /// Постоплата 2, %
        /// </summary>
        public decimal PostPaymant2 { get; set; } // decimal(8, 3)
        
        /// <summary>
        /// Постоплата 3, %
        /// </summary>
        public decimal PostPaymant3 { get; set; } // decimal(8, 3)
        
        /// <summary>
        /// Срок постоплаты 1, дн
        /// </summary>
        public int PostPaymantPeriod1 { get; set; } // int
        
        /// <summary>
        /// Срок постоплаты 2, дн
        /// </summary>
        public int PostPaymantPeriod2 { get; set; } // int
        
        /// <summary>
        /// Срок постоплаты 3, дн
        /// </summary>
        public int PostPaymantPeriod3 { get; set; } // int
        
        /// <summary>
        /// Аккредитив
        /// </summary>
        public bool Accreditive { get; set; } // bit
        
        /// <summary>
        /// Банковская гарантия
        /// </summary>
        public bool BankGuarantee { get; set; } // bit
        
        /// <summary>
        /// Таможенная пошлина
        /// </summary>
        public bool CustomDuty { get; set; } // bit
        
        /// <summary>
        /// Таможенный сбор
        /// </summary>
        public bool CustomFee { get; set; } // bit
        
        /// <summary>
        /// Были нарушения сроков поставки
        /// </summary>
        public bool MissingDeadlines { get; set; } // bit
        
        /// <summary>
        /// Были претензии к качеству товара/услуги
        /// </summary>
        public bool PoorQuality { get; set; } // bit
        
        /// <summary>
        /// Были нарушения внутренних норм
        /// </summary>
        public bool NormsViolated { get; set; } // bit
        
        /// <summary>
        /// Опыт работы с контр агентом
        /// </summary>
        public bool ExperienceCooperation { get; set; } // bit
        
        /// <summary>
        /// Опыт работы на рынке
        /// </summary>
        public bool ExperienceMarket { get; set; } // bit
        
        /// <summary>
        /// Штрафы и судебные издержки
        /// </summary>
        public bool Fines { get; set; } // bit
        
        /// <summary>
        /// Посредник или производитель. True - посредник, False - производитель.
        /// </summary>
        public bool Intermediary { get; set; } // bit
        
        /// <summary>
        /// Производство и складские запасы
        /// </summary>
        public bool ProductionAndInventory { get; set; } // bit
        
        /// <summary>
        /// Наличие современного оборудования
        /// </summary>
        public bool ModernEquipment { get; set; } // bit
        
        /// <summary>
        /// Географическая близость к заказчику
        /// </summary>
        public bool Georgraphy { get; set; } // bit
        
        /// <summary>
        /// Лояльность в рамках тендера
        /// </summary>
        public bool Concessions { get; set; } // bit
        
        /// <summary>
        /// Наличие рекламаций
        /// </summary>
        public bool Complaints { get; set; }

        public static implicit operator Proposal(Data.Proposal a)
        {
            if (a == null) return null;

            return new Proposal()
            {
                ProposalId = a.ProposalId,
                Agent = a.Agent,
                User = a.User,
                Tender = a.Tender,
                CountPos = a.CountPos,
                PositionPrice = a.PositionPrice,
                DeliveryCost = a.DeliveryCost,
                DeliveryTime = a.DeliveryTime,
                PrepaidExpense1 = a.PrepaidExpense1,
                PrepaidExpense2 = a.PrepaidExpense2,
                PrepaidExpense3 = a.PrepaidExpense3,
                PeriodOfExecution1 = a.PeriodOfExecution1,
                PeriodOfExecution2 = a.PeriodOfExecution2,
                PeriodOfExecution3 = a.PeriodOfExecution3,
                PostPaymant1 = a.PostPaymant1,
                PostPaymant2 = a.PostPaymant2,
                PostPaymant3 = a.PostPaymant3,
                PostPaymantPeriod1 = a.PostPaymantPeriod1,
                PostPaymantPeriod2 = a.PostPaymantPeriod2,
                PostPaymantPeriod3 = a.PostPaymantPeriod3,
                Accreditive = a.Accreditive,
                BankGuarantee = a.BankGuarantee,
                CustomDuty = a.CustomDuty,
                CustomFee = a.CustomFee,
                MissingDeadlines = a.MissingDeadlines,
                PoorQuality = a.PoorQuality,
                NormsViolated = a.NormsViolated,
                ExperienceCooperation = a.ExperienceCooperation,
                ExperienceMarket = a.ExperienceMarket,
                Fines = a.Fines,
                Intermediary = a.Intermediary,
                ProductionAndInventory = a.ProductionAndInventory,
                ModernEquipment = a.ModernEquipment,
                Georgraphy = a.Georgraphy,
                Concessions = a.Concessions,
                Complaints = a.Complaints,
            };
        }

        public static implicit operator Data.Proposal(Proposal a)
        {
            if (a == null) return null;

            return new Data.Proposal()
            {
                ProposalId = a.ProposalId,
                AgentId = a.Agent.AgentId,
                UserId = a.User.UserId,
                TenderId = a.Tender.TenderId,
                CountPos = a.CountPos,
                PositionPrice = a.PositionPrice,
                DeliveryCost = a.DeliveryCost,
                DeliveryTime = a.DeliveryTime,
                PrepaidExpense1 = a.PrepaidExpense1,
                PrepaidExpense2 = a.PrepaidExpense2,
                PrepaidExpense3 = a.PrepaidExpense3,
                PeriodOfExecution1 = a.PeriodOfExecution1,
                PeriodOfExecution2 = a.PeriodOfExecution2,
                PeriodOfExecution3 = a.PeriodOfExecution3,
                PostPaymant1 = a.PostPaymant1,
                PostPaymant2 = a.PostPaymant2,
                PostPaymant3 = a.PostPaymant3,
                PostPaymantPeriod1 = a.PostPaymantPeriod1,
                PostPaymantPeriod2 = a.PostPaymantPeriod2,
                PostPaymantPeriod3 = a.PostPaymantPeriod3,
                Accreditive = a.Accreditive,
                BankGuarantee = a.BankGuarantee,
                CustomDuty = a.CustomDuty,
                CustomFee = a.CustomFee,
                MissingDeadlines = a.MissingDeadlines,
                PoorQuality = a.PoorQuality,
                NormsViolated = a.NormsViolated,
                ExperienceCooperation = a.ExperienceCooperation,
                ExperienceMarket = a.ExperienceMarket,
                Fines = a.Fines,
                Intermediary = a.Intermediary,
                ProductionAndInventory = a.ProductionAndInventory,
                ModernEquipment = a.ModernEquipment,
                Georgraphy = a.Georgraphy,
                Concessions = a.Concessions,
                Complaints = a.Complaints,
            };
        }
    }
}
