﻿namespace VideoService.Infrastructure.Settings;

public class RabbitMQSetting
{
    public string Endpoint { get; set; } = string.Empty;
    public string VirtualHost { get; set; } = "/";
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}
