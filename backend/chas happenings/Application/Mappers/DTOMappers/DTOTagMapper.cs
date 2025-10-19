using Application.DTOs.TagDTOs;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappers.DTOMappers
{
    public class DTOTagMapper
    {
        public static Tag CreateTagModelFromDTOs(CreateTagDTO tagDTO)
        {
            return new Tag
            {
                TagName = tagDTO.TagName,
            };
        }

        //public static void UpdateTagModelFromDTOs(Tag existingTag, UpdateTagDTO tagDTO)
        //{
        //    existingTag.TagName = tagDTO.TagName;
        //    return 
        //}

    }
}
