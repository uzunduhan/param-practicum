﻿using System.ComponentModel;

namespace PracticumHomeWork.Base.Types
{
    public enum RoleEnum
    {
        [Description(Role.Admin)]
        Admin = 1,

        [Description(Role.EditorQTNS)]
        EditorQTNS = 2,

        [Description(Role.EditorQTDA)]
        EditorQTDA = 3,

        [Description(Role.Viewer)]
        Viewer = 4
    }

    public class Role
    {
        public const string Admin = "admin";
        public const string EditorQTNS = "editor-qtns";
        public const string EditorQTDA = "editor-qtda";
        public const string Viewer = "viewer";
    }
}
