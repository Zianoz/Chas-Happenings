using Application.DTOs.TagDTOs;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappers.DTOMappers
{
    internal class DTOTagMapper
    {
        public static Tag CreateTagModelFromDTOs(CreateTagDTO tagDTO)
        {
            return new Tag
            {
                TagName = tagDTO.TagName,
            };
        }

        //public static Tag UpdateTagModelFromDTOs(UpdateTagDTO tagDTO, int tagId)
        //{
        //    return new Tag
        //    {
        //        Id = tagId,
        //        TagName = tagDTO.TagName,
        //    };
        //}

    }
}
