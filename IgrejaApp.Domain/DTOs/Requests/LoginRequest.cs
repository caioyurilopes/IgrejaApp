﻿namespace IgrejaApp.Domain.DTOs.Requests;

public class LoginRequest
{
    public string Celular { get; set; } = string.Empty;
    public string Senha { get; set; } = string.Empty;
}