﻿using Backend.Model.Tender;
using IntegrationAdapters.Dto;

namespace IntegrationAdapters.Mapper
{
    public class TenderMapper
    {
        public static TenderDto TenderToTenderDto(Tender tender)
        {
            TenderDto dto = new TenderDto();
            dto.Id = tender.Id;
            dto.MedicamentName = tender.MedicamentName;
            dto.StartDate = tender.StartDate.ToString("dd.MM.yyyy. HH:mm");
            dto.EndDate = tender.EndDate.ToString("dd.MM.yyyy. HH:mm");
            dto.Active = tender.Active;
            return dto;
        }
    }
}
