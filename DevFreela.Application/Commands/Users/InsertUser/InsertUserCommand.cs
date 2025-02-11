﻿using System;
using MediatR;
using DevFreela.Application.Models;
using DevFreela.Core.Entities;

namespace DevFreela.Application.Commands.Users.InsertUser
{
    public class InsertUserCommand : IRequest<ResultViewModel<int>>
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }

        public User ToEntity()
            => new(FullName, Email, BirthDate);
    }
}
