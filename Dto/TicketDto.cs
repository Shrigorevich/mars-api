﻿namespace Dto;

public class TicketDto
{
    public long Id { get; set; }
    public string? Title { get; set; }
    public int ApplicationId { get; set; }
    public string? ApplicationName { get; set; }
    public string? Description { get; set; }
    public string? Url { get; set; }
    public string? StackTrace { get; set; }
    public string? Device { get; set; }
    public string? Browser { get; set; }
    public string? Resolution { get; set; }
    public int PriorityId { get; set; }
    public int StatusId { get; set; }
    public int? UserId { get; set; }
    public string? UserOid { get; set; }
    public int InstalledEnvironmentId { get; set; }
    public int TicketTypeId { get; set; }
    public required DateTime CreatedAt { get; set; }
    public required DateTime UpdatedAt { get; set; }
    public string? CreatedByOid { get; set; }
}