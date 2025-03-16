﻿namespace Entities;

public class TicketReply
{
    public int Id { get; set; }
    public long TicketId { get; set; }
    public required string Content { get; set; }
    public DateTime PublishedAt { get; set; }
}