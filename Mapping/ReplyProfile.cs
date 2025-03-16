using AutoMapper;
using Dto;
using Entities;

namespace Mapping;

public class ReplyProfile : Profile
{
    public ReplyProfile()
    {
        CreateMap<TicketReply, TicketReplyDto>();
        CreateMap<CreateTicketReplyDto, TicketReply>()
            .ForMember(dest => dest.PublishedAt, opt => opt.MapFrom(src => DateTime.UtcNow));

        CreateMap<UpdateTicketReplyDto, TicketReply>();
    }
}