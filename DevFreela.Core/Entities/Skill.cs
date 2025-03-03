﻿using System.Collections.Generic;

namespace DevFreela.Core.Entities
{
    public class Skill : BaseEntity
    {
        public Skill()
        {
            UserSkills = [];
        }

        public Skill(string description) : base()
        {
            Description = description;

            UserSkills = [];
        }

        public string Description { get; private set; }

        public List<UserSkill> UserSkills { get; private set; }
    }
}
