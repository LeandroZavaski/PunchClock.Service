﻿using DelMazo.PointRecord.Service.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DelMazo.PointRecord.Service.Persistence.Entities
{
    public class UserResponse
    {
        public string Id { get; set; }

        public string Registration { get; set; }

        public string Name { get; set; }

        public DateTime BirthDate { get; set; }

        public string Phone { get; set; }

        public byte Gender { get; set; }

        public string DocumentCpf { get; set; }

        public string DocumentRg { get; set; }

        public string DocumentPis { get; set; }

        public RoleResponse RoleResponse { get; set; }

        public string Email { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? FinishDate { get; set; }

        public byte Active { get; set; }

        [JsonIgnore]
        public AuthResponse AuthResponse { get; set; }

        [JsonIgnore]
        public IEnumerable<Collections> Collections { get; set; }

        public static implicit operator UserResponse(User prop)
        {
            return prop is null ? null : new UserResponse()
            {
                Id = prop.Id,
                Registration = prop.Registration,
                Name = prop.Name,
                BirthDate = prop.BirthDate,
                Phone = prop.Phone,
                Gender = prop.Gender,
                DocumentCpf = prop.DocumentCpf,
                DocumentRg = prop.DocumentRg,
                DocumentPis = prop.DocumentPis,
                RoleResponse = new RoleResponse
                {
                    Active = prop.Role.Active,
                    Description = prop.Role.Description,
                    Id = prop.Role.Id
                },
                Email = prop.Email,
                StartDate = prop.StartDate,
                FinishDate = prop.FinishDate,
                Active = prop.Active,
                AuthResponse = new AuthResponse
                {
                    Id = prop.Auth.Id,
                    Document = prop.Auth.Document
                }
            };
        }
    }
}